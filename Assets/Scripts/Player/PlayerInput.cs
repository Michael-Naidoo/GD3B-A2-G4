using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private LayerMask pokemonLayer;
    [SerializeField] private LayerMask groundLayer;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetTargetPos(Input.mousePosition);
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                GetTargetPos(touch.position);
            }
        }
    }
    private void GetTargetPos(Vector2 pos)
    {
        Ray ray = Camera.main.ScreenPointToRay(pos);
        RaycastHit hit;

        //check if it hits a pokemon then if it hits the ground 

        if (Physics.Raycast(ray, out hit, 100, pokemonLayer))
        {
            // Game Manager transfer data over to other scene
            GameManager.Instance.pokeData = hit.transform.GetComponent<WildPokemon>().pokeData;

            // play little cut scene
            // go to next scene
            GameManager.Instance.SwitchStates(GameManager.Instance.catchState);

        }
        else if (Physics.Raycast(ray, out hit, 100, groundLayer))
        {
            agent.SetDestination(hit.point);
        }
    }

}
