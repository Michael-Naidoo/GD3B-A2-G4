using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokemonLogic : MonoBehaviour
{
    public PokeData data;
    public Pokemon pokemon;


    private void Start()
    {
        pokemon.CalcCurrStats();
        Debug.Log(pokemon._CurrStats.HP);
    }
}
