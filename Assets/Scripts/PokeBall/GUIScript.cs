using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIScript : MonoBehaviour
{
    [SerializeField] private GameObject pokeball;
    public enum PokeballState
    {
        idle,
        drawAttention,
        spinninClockwise,
        spinningAnticlockwise
    }

    public PokeballState pokeballState;
    void Update()
    { /*
        switch (pokeballState)
        {
            case PokeballState.idle:
                transform.position = pokeball.transform.position;
                return;
            case PokeballState.drawAttention:
                return;
            case PokeballState.spinninClockwise:
                transform.position = pokeball.transform.position;
                return;
            case PokeballState.spinningAnticlockwise:
                transform.position = pokeball.transform.position;
                return;
            default:
                pokeballState = PokeballState.idle;
                return;
            
        }*/
    }
}
