using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PokemonHitCircles : MonoBehaviour
{
    [HideInInspector] public PokemonLogic pokemonLogic;
    [SerializeField] private GameObject circlesParent;
    public GameObject maxCircle;
    public GameObject critCircle;

    [SerializeField] private BoxCollider parentCollider;
    public bool maxTrigger_enter;
    public bool critTrigger_enter;

    [SerializeField] private float currShrinkTime;
    public float shrinkTime;

    [SerializeField] private Gradient difficultyColour;

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

        //debugging in editor
        GetCritColour();
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

    /// <summary>
    /// Sets the size of the max circle and gets the colour of the crit circle
    /// </summary>
    public void PrepareHitCircles()
    {
        maxCircle.transform.localScale = Vector3.one * pokemonLogic.pokemon.currStats.height * pokemonLogic.pokemon.heightScale;

        
        //determine pokemon catch difficulty - MATCH COLOUR TO DIFFICULTY
    }

    public void GetCritColour()
    { 
        PokeballData playerBall = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).GetComponent<TouchRecognition>().PokeballData;
        float prob = pokemonLogic.CatchProbability(pokemonLogic.Multiplier(playerBall));

        critCircle.GetComponent<SpriteRenderer>().color = difficultyColour.Evaluate(1-prob);
    }

}
