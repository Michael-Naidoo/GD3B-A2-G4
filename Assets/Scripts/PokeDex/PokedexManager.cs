using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PokedexManager : MonoBehaviour
{
    [SerializeField] private GameObject pokemonCard;
    [SerializeField] private Transform pokemonCardParent;

    private void Start()
    {
        CreatePokeDex();
    }

    private void CreatePokeDex()
    {
        _Pokemon player = Resources.Load<_Pokemon>("PlayerPokemon");
        
        foreach (var pokemon in player.player_pokemon)
        {
            CreateCard(pokemon);
        }
    }

    private void CreateCard(PokeStats pokemon)
    {
        GameObject newCard = Instantiate(pokemonCard, pokemonCardParent);
        newCard.GetComponent<PokeCard>().image.sprite = pokemon.sprite;
        newCard.GetComponent<PokeCard>().title.text = pokemon.pokemonName;   
    }
}
