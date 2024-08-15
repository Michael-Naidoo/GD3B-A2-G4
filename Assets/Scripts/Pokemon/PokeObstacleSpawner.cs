using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GridSpawner))]
public class PokeObstacleSpawner : MonoBehaviour
{
    private GridSpawner gridSpawner;

    [Header("Pokemon")]
    public GameObject p_pokemon;        //pokemon prefab
    public Transform pokemonParent;

    [Header("Obstacle")]
    [SerializeField] int maxObstacles;
    public GameObject[] p_obstacles;
    public Transform[] obstaclePoints;

    private void Start()
    {
        gridSpawner = GetComponent<GridSpawner>();

        gridSpawner.GenerateGrid();
        PokemonSpawn();

        SpawnObstacles();
    }

    private void PokemonSpawn()
    {
        int randNum = Random.Range(0, gridSpawner.points.Length);

        GameObject pokemon = Instantiate(p_pokemon, gridSpawner.points[randNum].position, Quaternion.identity, pokemonParent);
        pokemon.transform.position += new Vector3(0, 1, 0);
        
    }

    public void GetObstaclePoints(Transform[] points)
    {
        List<Transform> obstaclePts = new List<Transform>();
        foreach (Transform t in points)
        {
            obstaclePts.Add(t.GetChild(0));
        }
        obstaclePoints = obstaclePts.ToArray();
    }

    public void SpawnObstacles()
    {
        GetObstaclePoints(gridSpawner.points);

        int randNum = Random.Range(1, maxObstacles);

        for(int i = 0; i < randNum; i++)
        {
            Transform obstaclePts = obstaclePoints[Random.Range(0, obstaclePoints.Length)];
            GameObject obstacle = p_obstacles[Random.Range(0, p_obstacles.Length)];

            Instantiate(obstacle, obstaclePts.position, Quaternion.identity, obstaclePts);
        }
    }
}
