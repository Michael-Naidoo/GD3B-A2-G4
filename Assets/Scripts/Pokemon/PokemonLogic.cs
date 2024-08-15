using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokemonLogic : MonoBehaviour
{
    public Pokemon pokemon;
    [SerializeField] private _PokeData[] allPokemon;

    public GameObject dataPanel;    //testing

    private void Start()
    {
        allPokemon = Resources.LoadAll<_PokeData>("Pokemon");
        pokemon.CalcCurrStats();

        dataPanel.GetComponent<PokemonStatUI>().DisplayData(pokemon);
        Debug.Log(allPokemon.Length);
        foreach (_PokeData d in allPokemon)
        {
            Debug.Log(d.name);
        }
    }

    public void RandomisePokemon()
    {

    }
}
