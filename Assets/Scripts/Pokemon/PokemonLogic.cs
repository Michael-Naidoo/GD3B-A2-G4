using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokemonLogic : MonoBehaviour
{
    public Pokemon pokemon;

    public GameObject dataPanel;    //testing

    private void Start()
    {
        pokemon.CalcCurrStats();

        dataPanel.GetComponent<PokemonStatUI>().DisplayData(pokemon);
    }
}
