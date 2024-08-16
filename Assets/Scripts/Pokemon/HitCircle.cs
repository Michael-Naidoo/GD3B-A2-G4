using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PokemonLogic))]
public class HitCircle : MonoBehaviour
{
    private PokemonLogic pokemonLogic;
    public GameObject circlesParent;
    public GameObject maxCircle;
    public GameObject critCircle;

    public BoxCollider parentCollider;
    public bool maxTrigger_enter;
    public bool critTrigger_enter;

    public float heightScale = 1;

    public float shrinkSpeed;

    private void Awake()
    {
        pokemonLogic = GetComponent<PokemonLogic>();
    }

    private void Update()
    {
        parentCollider.enabled = maxTrigger_enter;

    }



}
