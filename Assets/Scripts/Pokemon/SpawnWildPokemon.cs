using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnWildPokemon : MonoBehaviour
{
    public Transform[] spawnPoints = new Transform[0];

    private Stack<Transform> spawnStack = new Stack<Transform>();

    private void Start()
    {
        GetComponent<GridSpawner>().GenerateGrid();

        ShuffleIntoStack(GetComponent<GridSpawner>().points);
    }

    private void ShuffleIntoStack(Transform[] pointArray)
    {
        List<Transform> points = pointArray.ToList();

        while (points.Count > 0)
        {
            int randInt = Random.Range(0, points.Count);
            spawnStack.Push(points[randInt]);
            points.RemoveAt(randInt);
        }

        spawnPoints = spawnStack.ToArray();
    }
}
