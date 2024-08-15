using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GridSpawner))]
public class SpawnPokemon : MonoBehaviour
{
    protected GridSpawner gridSpawner;
    public GameObject p_pokemon;        //pokemon prefab

    private void Start()
    {
        gridSpawner = GetComponent<GridSpawner>();

        gridSpawner.GenerateGrid();
    }
}
