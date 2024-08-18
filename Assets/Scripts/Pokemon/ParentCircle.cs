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
            hitCircle.critCircle.GetComponent<SpriteRenderer>().color = Color.green;
            StartCoroutine(ChangeColour());
        }
        else
        {
            Debug.Log("Hit");
            hitCircle.critCircle.GetComponent<SpriteRenderer>().color = Color.yellow;
            StartCoroutine(ChangeColour());
        }

        hitCircle.pokemonLogic.CatchPokemon(collision.gameObject.GetComponent<TouchRecognition>().PokeballData, hitCircle);
    }

    private IEnumerator ChangeColour()
    {
        yield return new WaitForSeconds(1);
        hitCircle.critCircle.GetComponent<SpriteRenderer>().color = Color.red;
    }
}
