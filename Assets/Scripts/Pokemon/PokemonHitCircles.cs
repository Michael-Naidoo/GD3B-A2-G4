using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PokemonLogic))]
public class PokemonHitCircles : MonoBehaviour
{
    private PokemonLogic pokemonLogic;
    public GameObject circlesParent;
    public GameObject maxCircle;
    public GameObject critCircle;

    public BoxCollider parentCollider;
    public bool maxTrigger_enter;
    public bool critTrigger_enter;

    public float heightScale = 1;

    [SerializeField] private float currShrinkTime;
    public float shrinkTime;

    private void Awake()
    {
        pokemonLogic = GetComponent<PokemonLogic>();
    }

    private void Update()
    {
        parentCollider.enabled = maxTrigger_enter;

        if (currShrinkTime <= 0)
        {
            currShrinkTime = shrinkTime;
            critCircle.transform.localScale = maxCircle.transform.localScale;
        }
        else
        {
            currShrinkTime -= Time.deltaTime;
            critCircle.transform.localScale = maxCircle.transform.localScale * (currShrinkTime/ shrinkTime);
        }


    }



}
