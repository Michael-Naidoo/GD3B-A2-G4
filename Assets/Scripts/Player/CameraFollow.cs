using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform player;
    private Vector3 offset;
    public float lerpMultiplier;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        offset = transform.position - player.position;
    }

    private void LateUpdate()
    {
        Vector3 targetPos = player.position + offset;

        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * lerpMultiplier);

    }
}
