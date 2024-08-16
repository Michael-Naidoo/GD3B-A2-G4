using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PokemonLogic))]
public class HitCircle : MonoBehaviour
{
    private PokemonLogic pokemonLogic;
    public GameObject maxCircle;
    public GameObject critCircle;

    public float heightScale = 1;

    public float shrinkSpeed;

    private void Awake()
    {
        pokemonLogic = GetComponent<PokemonLogic>();
    }
}
