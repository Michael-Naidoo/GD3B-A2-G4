using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class playerGUI : MonoBehaviour
{
    // Start is called before the first frame update
    public NavMeshAgent agent;
    void Start()
    {
        agent.updateRotation = false;
    }
}
