using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PokemonStatUI : MonoBehaviour
{
    /// <summary>
    /// Add all the UI Elements here PLEASEEEEE
    /// </summary>
    public TextMeshProUGUI CPValue;
    public Slider CPScale;
    public Image pokemonSprite;
    public TMP_InputField pokemonName;
    public Slider HPScale;
    public TextMeshProUGUI weight;
    public TextMeshProUGUI types;
    public TextMeshProUGUI height;

    /// <summary>
    /// This sets all the data on the UI
    /// </summary>
    /// <param name="currPokemon">The Pokemon to display on the stats</param>
    public void DisplayData(Pokemon currPokemon)
    {
        CPValue.text = $"CP {currPokemon.currStats.CP}";

        CPScale.maxValue = currPokemon.base_pokedata.max_CP;
        CPScale.value = currPokemon.currStats.CP;

        //pokemonSprite.sprite = currPokemon.sprites[0];

        pokemonName.text = currPokemon.base_pokedata.name;

        HPScale.maxValue = currPokemon.currStats.HP;
        HPScale.value = currPokemon.currStats.HP;

        weight.text = currPokemon.currStats.weight.ToString("0.00") + "kg";

        types.text = currPokemon.currStats.type.ToString();

        height.text = currPokemon.currStats.height.ToString("0.00") + "m";
    }
}
