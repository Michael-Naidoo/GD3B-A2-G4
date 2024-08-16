using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PokemonLogic : MonoBehaviour
{
    public Pokemon pokemon;
    public SpriteRenderer GUI;

    public _CPMultLevels CPMultLevels;
    public GameObject dataPanel;    //testing

    private void Start()
    {
        _PokeData[] allPokemon = Resources.LoadAll<_PokeData>("Pokemon");

        pokemon.base_pokedata = allPokemon[Random.Range(0,allPokemon.Length)];
        pokemon.CalcCurrStats();

        //dataPanel.GetComponent<PokemonStatUI>().DisplayData(pokemon);
        GUI.sprite = pokemon.base_pokedata.sprite;
    }

    public void CatchPokemon()
    {
        
    }

    private float CatchProbability()
    {
        float failChance_preMultipliers = 1-(pokemon.base_pokedata.baseCaptureRate / (2 * CPMultLevels.CPMult[(int)pokemon.currStats.level - 1]));

        float multipliers = 0;  // work this out in a function

        float failChance = Mathf.Pow(failChance_preMultipliers, multipliers);
        float probability = 1 - failChance;
        return probability;
    }

    //private float Multiplier()
    //{

    //}
}
