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
            Debug.Log("CRIT HIT");
            hitCircle.pokemonLogic.critHit = true;
        }
        else
        {
            Debug.Log("Hit");
            hitCircle.pokemonLogic.critHit = false;
        }

        hitCircle.pokemonLogic.CatchPokemon(collision.gameObject.GetComponent<TouchRecognition>().PokeballData, hitCircle);
    }
}
