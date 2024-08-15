using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GridSpawner : MonoBehaviour
{
    [Header("Spawn Matrix")]
    [SerializeField] private GameObject p_point;    //point prefab

    [Tooltip("The x and y sizing of the grid")]
    [SerializeField] private Vector2 gridSize;

    [Tooltip("The distance between each point (size of each grid block)")]
    [SerializeField] private Vector2 gridDistance = new Vector2(1, 1);

    private List<Vector3> spawnPoints = new List<Vector3>();
    public Transform[] points;

    private void Start()
    {
        GenerateGrid();
    }

    #region Matrix

    /// <summary>
    /// generates the grid
    /// </summary>
    public void GenerateGrid()
    {
        spawnPoints.Clear();
        CreateGrid();
        CenterGrid();
        Init_Spawners();
    }

    /// <summary>
    /// Create a matrix of positions and add it to the spawnPoints list
    /// </summary>
    private void CreateGrid()
    {
        Vector3 pos = Vector3.zero;
        for (int x = 0; x < gridSize.x; x++)
        {
            for (int y = 0; y < gridSize.y; y++)
            {
                spawnPoints.Add(pos);
                pos.z += gridDistance.y;
            }
            pos.z = 0;
            pos.x += gridDistance.x;
        }
    }

    /// <summary>
    /// Centers the matrix around the gameobjects center (0, 0, 0)
    /// </summary>
    private void CenterGrid()
    {
        float halfX = spawnPoints[spawnPoints.Count - 1].x / 2;
        float halfZ = spawnPoints[spawnPoints.Count - 1].z / 2;

        for (int i = 0; i < spawnPoints.Count; i++)
        {
            spawnPoints[i] -= new Vector3(halfX, 0, halfZ);
        }
    }

    /// <summary>
    /// Instantiate the spawners on the spawnPoints
    /// </summary>
    private void Init_Spawners()
    {
        List<Transform> spawners = new List<Transform>();
        foreach (Vector3 spawnPoint in spawnPoints)
        {
            GameObject initSpawn = Instantiate(p_point, Vector3.zero, Quaternion.identity, transform);
            initSpawn.transform.localPosition = spawnPoint;
            spawners.Add(initSpawn.transform);
        }
        points = spawners.ToArray();

    }

    /// <summary>
    /// destroys the current matrix to free up memory
    /// </summary>
    private void DestroyMatrix()
    {
        for (int i = 0; i < points.Length; i++)
        {
            Destroy(points[i].gameObject);
        }

    }

    private void OnDrawGizmos()
    {
        foreach (Transform t in points)
        {
            Gizmos.DrawWireCube(t.position, new Vector3(gridDistance.x*0.9f, 0, gridDistance.y*0.9f));
        }

    }

    #endregion

    #region Sheep Spawning

    //public void AddSheep(int num)
    //{
    //    for (int i = 0; i < num; i++)
    //    {
    //        GameObject sheep = Instantiate(p_pokemon, pokemonParent);
    //        SpriteManager.Instance.SpriteUpdate(sheep);
    //        BoidsManager.Instance.boids.Add(sheep);

    //        List<GameObject> newSheep = activeSheep.ToList();
    //        newSheep.Add(sheep);
    //        activeSheep = newSheep.ToArray();
    //    }

    //    // SpawnSheepHerd();

    //}
    //public void SpawnSheepHerd()
    //{

    //    spawnedSheep = new bool[sheepSpawnPoints.Count];

    //    foreach (GameObject sheep in activeSheep)
    //    {
    //        FindPos(sheep);
    //    }

    //}
    //private bool FindPos(GameObject sheep)
    //{
    //    int x = Random.Range(0, points.Length - 1);
    //    if (!spawnedSheep[x])
    //    {
    //        sheep.transform.position = points[x].position;
    //        spawnedSheep[x] = true;
    //        return true;
    //    }
    //    else
    //    {
    //        return FindPos(sheep);
    //    }
    //}

    #endregion
}
