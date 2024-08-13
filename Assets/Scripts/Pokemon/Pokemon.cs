using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;


[Serializable]
public class Pokemon
{
    public int id;
    public string name;


    /// <summary>
    /// 0 -> forward facing
    /// 1 -> back facing
    /// </summary>
    public Sprite[] sprites = new Sprite[2];
    public PokeStats baseStats = new PokeStats();
    private PokeStats currStats = new PokeStats();

    public void CalcCurrStats()
    {
        currStats.type = baseStats.type;
        currStats.HP = UnityEngine.Random.Range(0, baseStats.HP + 1);
        currStats.CP = UnityEngine.Random.Range(0, baseStats.CP + 1);

        currStats.weight = UnityEngine.Random.Range(baseStats.weight * 0.75f, baseStats.weight * 1.25f);
        currStats.height = UnityEngine.Random.Range(baseStats.height * 0.75f, baseStats.height * 1.25f);

        currStats.level = baseStats.level;
    }

    public PokeStats _CurrStats => currStats;
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
}

namespace Enums
{
    [Flags]
    public enum PokemonType
    {
        None = 0,
        Normal = 1 << 0,    // 0001
        Fire = 1 << 1,      // 0010
        Water = 1 << 2,     // 0100
        Electric = 1 << 3,  // 1000
        Grass = 1 << 4,     // 0001 0000
        Ice = 1 << 5,       // 0010 0000
        Fighting = 1 << 6,  // 0100 0000
        Poison = 1 << 7,    // 1000 0000
        Ground = 1 << 8,    // 0001 0000 0000
        Flying = 1 << 9,    // 0010 0000 0000
        Psychic = 1 << 10,  // 0100 0000 0000
        Bug = 1 << 11,      // 1000 0000 0000
        Rock = 1 << 12,     // 0001 0000 0000 0000
        Ghost = 1 << 13,    // 0010 0000 0000 0000
        Dragon = 1 << 14   // 0100 0000 0000 0000
    }

}
