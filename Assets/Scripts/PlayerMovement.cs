using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //GetTargetPos(Camera.main.ScreenToViewportPoint(Input.mousePosition));
            GetTargetPos(Input.mousePosition);
        }
    }
    private void GetTargetPos(Vector2 pos)
    {
        Ray ray = Camera.main.ScreenPointToRay(pos);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit) )
        {
            agent.SetDestination(hit.point);
        }
    }
}
