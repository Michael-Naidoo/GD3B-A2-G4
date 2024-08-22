using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_BerryButton : MonoBehaviour
{
    [SerializeField] private GameObject p_berry;
    [SerializeField] private Transform parent;

    public void SpawnBerry()
    {
        Vector3 spawnPos = Camera.main.ScreenToWorldPoint(transform.position);
        Instantiate(p_berry,spawnPos, Quaternion.identity, parent);
    }
}
