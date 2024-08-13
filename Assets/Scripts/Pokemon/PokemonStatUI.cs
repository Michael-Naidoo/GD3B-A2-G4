using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PokemonStatUI : MonoBehaviour
{
    public TextMeshProUGUI CPValue;
    public Slider CPScale;
    public Image pokemonSprite;
    public TMP_InputField pokemonName;
    public Slider HPScale;
    public TextMeshProUGUI weight;
    public TextMeshProUGUI types;
    public TextMeshProUGUI height;


    public void SetData(Pokemon currPokemon, PokeStats currStats, Pokemon basePokemon)
    {
        CPValue.text = $"CP {currStats.CP}";

        CPScale.maxValue = basePokemon.baseStats.CP;
        CPScale.value = currStats.CP;

        //pokemonSprite.sprite = currPokemon.sprites[0];

        pokemonName.text = currPokemon.name;

        HPScale.maxValue = currStats.HP;
        HPScale.value = currStats.HP;

        weight.text = currStats.weight.ToString("0.00") + "kg";

        types.text = currStats.type.ToString();

        height.text = currStats.height.ToString("0.00") + "m";
    }
}
