using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleTriggers : MonoBehaviour
{
    public HitCircle hitCircle;
    [SerializeField] private bool isMaxCollider;

    private void OnTriggerStay(Collider other)
    {
        if (isMaxCollider)
        {
            hitCircle.maxTrigger_enter = true;
        }
        else
        {
            hitCircle.critTrigger_enter = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (isMaxCollider)
        {
            hitCircle.maxTrigger_enter = false;
        }
        else
        {
            hitCircle.critTrigger_enter = false;
        }
    }
}
