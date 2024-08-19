using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PokedexManager : MonoBehaviour
{
    public static PokedexManager Instance { get; private set; }

    [SerializeField] private GameObject pokemonCard;
    [SerializeField] private Transform pokemonCardParent;
    [SerializeField] private GameObject pokeStatsPanel;

    private void Awake()
    {
        Instance = this;
    }
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
        PokeCard card = newCard.GetComponent<PokeCard>();

        card.pokeStats = pokemon;
        card.image.sprite = pokemon.sprite;
        card.title.text = pokemon.pokemonName;   
    }

    public void ActiveStatsPanel(PokeStats pokemon)
    {
        pokeStatsPanel.SetActive(true);
        pokeStatsPanel.GetComponent<PokemonStatUI>().DisplayData(pokemon);
    }

    public void CloseStatPanel() => pokeStatsPanel.SetActive(false);
}
