using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(PokemonHitCircles))]
public class PokemonLogic : MonoBehaviour
{
    private PokemonHitCircles pokemonHitCircles;

    public Pokemon pokemon;
    public SpriteRenderer GUI;

    public _CPMultLevels CPMultLevels;
    public GameObject dataPanel;    //testing
    public BerryTypes BerryEffect;

    private void Start()
    {
        pokemonHitCircles = GetComponent<PokemonHitCircles>();

        pokemon.base_pokedata = GameManager.Instance.pokeData;
        pokemon.CalcCurrStats();

        //dataPanel.GetComponent<PokemonStatUI>().DisplayData(pokemon);
        GUI.sprite = pokemon.base_pokedata.sprite;
    }

    public void CatchPokemon(PokeballData pokeball, PokemonHitCircles hitCircles)
    {
        float multiplier = Multiplier(pokeball, hitCircles);
        float probability = CatchProbability(multiplier);

        float randNum = Random.Range(0, 1f);

        Debug.Log("Rand Num: "+ randNum);

        if(randNum <= probability)
        {
            //pokemon caught!
            Debug.Log("Pokemon Caught");

            _Pokemon playerPokemon = Resources.Load<_Pokemon>("PlayerPokemon");
            pokemon.StorePokemon();
            playerPokemon.player_pokemon.Add(pokemon.currStats);

            Destroy(gameObject);
        }
        else
        {
            //choose random tick (0-2)
            Debug.Log("Failed...");
        }
    }

    /// <summary>
    /// calculated the catch probability based off ball, throw and pokemon
    /// </summary>
    /// <param name="multipliers">extra multiplie based on the ball, throw or berries eaten</param>
    /// <returns></returns>
    public float CatchProbability(float multipliers)
    {
        float failChance_preMult, failChance, probability;

        failChance_preMult = 1 - (pokemon.base_pokedata.baseCaptureRate / (2 * CPMultLevels.CPMult[(int)pokemon.currStats.level - 1]));
        failChance = Mathf.Pow(failChance_preMult, multipliers);
        probability = 1 - failChance;

        //Debug.Log("Prob: " + probability + "  " + "Radius: " + pokemonHitCircles.maxCircle.transform.localScale.x + " vs " + pokemonHitCircles.critCircle.transform.localScale.x);


        return probability;
    }

    /// <summary>
    /// Calculates the multiplers applied to the catch probability
    /// </summary>
    /// <param name="pokeball">the pokeball that hit the pokemon</param>
    /// <param name="hitCircles">the hit circles of the current pokemon</param>
    /// <returns></returns>
    public float Multiplier(PokeballData pokeball, PokemonHitCircles hitCircles)
    {
        float ball, curve, berry, throwCalc;

        ball = (float)pokeball.pokeball_type / 10;

        Debug.Log("Ball: " + ball);

        curve = pokeball.curveBall ? 1.7f : 1f;
        berry = (float)BerryEffect / 10;
        throwCalc = 1 + (hitCircles.critCircle.transform.localScale.x / hitCircles.maxCircle.transform.localScale.x);

        Debug.Log("Mult: " + ball * curve * berry * throwCalc);

        return ball * curve * berry * throwCalc;
    }
    public float Multiplier(PokeballData pokeball)
    {
        float ball, curve, berry, throwCalc;

        ball = (float)pokeball.pokeball_type / 10;

        //Debug.Log("Ball: " + ball);

        curve = pokeball.curveBall ? 1.7f : 1f;
        berry = (float)BerryEffect / 10;
        throwCalc = 1.5f;

        //Debug.Log("Mult: " + ball * curve * berry * throwCalc);

        return ball * curve * berry * throwCalc;
    }
}
