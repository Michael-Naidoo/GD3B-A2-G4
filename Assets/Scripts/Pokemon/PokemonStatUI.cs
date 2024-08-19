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
    public TextMeshProUGUI dateCaught;

    /// <summary>
    /// This sets all the data on the UI
    /// </summary>
    /// <param name="currPokemon">The Pokemon to display on the stats</param>
    /// 
    public void DisplayData(PokeStats currPokemon)
    {
        CPValue.text = $"CP {currPokemon.CP}";

        CPScale.maxValue = currPokemon.maxCP;
        CPScale.value = currPokemon.CP;

        pokemonSprite.sprite = currPokemon.sprite;

        pokemonName.text = currPokemon.pokemonName;

        HPScale.maxValue = currPokemon.HP;
        HPScale.value = currPokemon.HP;

        weight.text = currPokemon.weight.ToString("0.00") + "kg";

        types.text = currPokemon.type.ToString();

        height.text = currPokemon.height.ToString("0.00") + "m";

        dateCaught.text = currPokemon.dateCaught;
    }
}
