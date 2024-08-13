using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokemonLogic : MonoBehaviour
{
    public PokeData data;
    public Pokemon pokemon;
    public PokeStats currStats;


    private void Start()
    {
        pokemon.name = data.name;
        pokemon.baseStats.type = data.pokemon_evolutions[0].baseStats.type;
        pokemon.baseStats.HP = data.pokemon_evolutions[0].baseStats.HP;
        pokemon.baseStats.CP = data.pokemon_evolutions[0].baseStats.CP;
        pokemon.baseStats.weight = data.pokemon_evolutions[0].baseStats.weight;
        pokemon.baseStats.height = data.pokemon_evolutions[0].baseStats.height;
        pokemon.CalcCurrStats();

        currStats.type = pokemon.baseStats.type;
        currStats.HP = pokemon._CurrStats.HP;
        currStats.CP = pokemon._CurrStats.CP;
        currStats.weight = pokemon._CurrStats.weight;
        currStats.height = pokemon._CurrStats.height;
    }
}
