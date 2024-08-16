using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PokemonLogic : MonoBehaviour
{
    public Pokemon pokemon;
    public SpriteRenderer GUI;

    public GameObject dataPanel;    //testing

    private void Start()
    {
        _PokeData[] allPokemon = Resources.LoadAll<_PokeData>("Pokemon");

        pokemon.base_pokedata = allPokemon[Random.Range(0,allPokemon.Length)];
        pokemon.CalcCurrStats();

        //dataPanel.GetComponent<PokemonStatUI>().DisplayData(pokemon);
        GUI.sprite = pokemon.base_pokedata.sprite;
    }


}
