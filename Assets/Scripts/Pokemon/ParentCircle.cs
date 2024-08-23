using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentCircle : MonoBehaviour
{
    public PokemonHitCircles hitCircle;
    private void OnCollisionEnter(Collision collision)
    {
        if (hitCircle.critTrigger_enter)
        {
            //Debug.Log("CRIT HIT");
            hitCircle.pokemonLogic.critHit = true;
        }
        else
        {
            //Debug.Log("Hit");
            hitCircle.pokemonLogic.critHit = false;
        }

        bool caught = hitCircle.pokemonLogic.CatchPokemon(collision.gameObject.GetComponent<TouchRecognition>().PokeballData, hitCircle);

        if (caught)
        {
            hitCircle.pokemonLogic.pokemon.AddCatchDate();
            hitCircle.pokemonLogic.playerPokemon.player_pokemon.Add(hitCircle.pokemonLogic.pokemon.currStats);

            CatchManager.Instance.CatchSuccess();
        }
        else
        {
            CatchManager.Instance.CatchFail();
        }
    }
}
