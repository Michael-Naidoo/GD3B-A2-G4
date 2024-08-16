using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;


[Serializable]
public class Pokemon
{

    public _PokeData base_pokedata;                 //this is the base stats of the specific pokemon "species"
    public PokeStats currStats = new PokeStats();   //a struct of THIS pokemons stats
    public float heightScale;
    [SerializeField] private float[] heightScales;

    /// <summary>
    /// Calculates the stats of the current pokemon based off the base stats
    /// </summary>
    public void CalcCurrStats()
    {
        currStats.type = base_pokedata.type;
        currStats.HP = UnityEngine.Random.Range(0, base_pokedata.max_HP + 1);
        currStats.CP = UnityEngine.Random.Range(0, base_pokedata.max_CP + 1);

        currStats.weight = UnityEngine.Random.Range(base_pokedata.ave_weight * 0.75f, base_pokedata.ave_weight * 1.25f);
        currStats.height = UnityEngine.Random.Range(base_pokedata.ave_height * 0.75f, base_pokedata.ave_height * 1.25f);

        currStats.level = UnityEngine.Random.Range(base_pokedata.level.x, base_pokedata.level.y);

        heightScale = heightScales[base_pokedata.evolutionStage];
    }
}

[Serializable]
public struct PokeStats
{
    public PokemonType type;

    public int HP;
    public int CP;

    public float weight;
    public float height;

    public float level;

    public string dateCaught;
}

namespace Enums
{
     /*  Bit-Shifting Explination
         Bit-shifting the enums so that a pokemon can have more than one type
     
         Assigns an each ***ENUM TYPE*** to a bit-position i.e. 0001, 0010, 0100, 1000
         A ***ENUM VALUE*** (consisting of 32 or 64 bits - dependant on computer) has empty bits
         the ***ENUM VALUE*** can have multiple ***ENUM TYPES***

         i.e.    0110 = Fire (0010) & Water (0100)
                 1100 = Electric (1000) & Water (0100)
                 1000 0100 = Poison (1000 0000) & Water (0000 0100)
     */
    [Flags]

    public enum PokemonType
    {
        None        = 0,
        Normal      = 1 << 0,   // 0001
        Fire        = 1 << 1,   // 0010
        Water       = 1 << 2,   // 0100
        Electric    = 1 << 3,   // 1000
        Grass       = 1 << 4,   // 0001 0000
        Ice         = 1 << 5,   // 0010 0000
        Fighting    = 1 << 6,   // 0100 0000
        Poison      = 1 << 7,   // 1000 0000
        Ground      = 1 << 8,   // 0001 0000 0000
        Flying      = 1 << 9,   // 0010 0000 0000
        Psychic     = 1 << 10,  // 0100 0000 0000
        Bug         = 1 << 11,  // 1000 0000 0000
        Rock        = 1 << 12,  // 0001 0000 0000 0000
        Ghost       = 1 << 13,  // 0010 0000 0000 0000
        Dragon      = 1 << 14   // 0100 0000 0000 0000
    }

}
