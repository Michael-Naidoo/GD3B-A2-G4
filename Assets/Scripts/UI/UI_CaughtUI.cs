using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class UI_CaughtUI : MonoBehaviour
{
    public TextMeshProUGUI caughtText;

    public void SetCaughtUI(PokeStats pokemon)
    {
        List<string> _text = new List<string>();

        _text.Add("You caught a : \n \n");
        _text.Add(pokemon.pokemonName);
        _text.Add("\n \n");
        _text.Add("CP " + pokemon.CP.ToString());

        caughtText.text = string.Join("", _text);
    }
}
