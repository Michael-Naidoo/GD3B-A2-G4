using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private LayerMask pokemonLayer;
    [SerializeField] private LayerMask groundLayer;

    private void Update()
    {
        if (!TouchUI())
        {
            if (Input.GetMouseButtonDown(0))
            {
                GetTargetPos_Tap(Input.mousePosition);
            }
            else if (Input.GetMouseButton(0))
            {
                GetTargetPos_Cont(Input.mousePosition);
            }

            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    GetTargetPos_Tap(touch.position);
                }
                else if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
                {
                    GetTargetPos_Cont(touch.position);
                }
            }
        }
    }

    private bool TouchUI()
    {
        if (Input.touchCount > 0)
        {
            int id = Input.GetTouch(0).fingerId;

            return EventSystem.current.IsPointerOverGameObject(id);
        }

        return false;
    }
    private void GetTargetPos_Cont(Vector2 pos)
    {
        Ray ray = Camera.main.ScreenPointToRay(pos);
        RaycastHit hit;

        //check if it hits a pokemon then if it hits the ground 

        if (Physics.Raycast(ray, out hit, 1000, groundLayer))
        {
            agent.SetDestination(hit.point);
        }
    }
    private void GetTargetPos_Tap(Vector2 pos)
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
    }

}
