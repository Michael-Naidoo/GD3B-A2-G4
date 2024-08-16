using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PokemonLogic))]
public class PokemonHitCircles : MonoBehaviour
{
    private PokemonLogic pokemonLogic;
    [SerializeField] private GameObject circlesParent;
    [SerializeField] private GameObject maxCircle;
    public GameObject critCircle;

    [SerializeField] private BoxCollider parentCollider;
    public bool maxTrigger_enter;
    public bool critTrigger_enter;

    [SerializeField] private float currShrinkTime;
    public float shrinkTime;

    private void Awake()
    {
        pokemonLogic = GetComponent<PokemonLogic>();
    }
    private void Start()
    {
        PrepareHitCircles();
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

    public void PrepareHitCircles()
    {
        maxCircle.transform.localScale = Vector3.one * pokemonLogic.pokemon.currStats.height * pokemonLogic.pokemon.heightScale;
    }


}
