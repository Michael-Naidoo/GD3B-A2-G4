using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GridSpawner : MonoBehaviour
{
    [Header("Spawn Matrix")]
    [SerializeField] private GameObject p_point;    //point prefab

    [Tooltip("The x and y sizing of the grid")]
    [SerializeField] private Vector2 matrixMetrics;

    [Tooltip("The distance between each point (size of each grid block)")]
    [SerializeField] private Vector2 matrixDistance = new Vector2(1, 1);

    private List<Vector3> spawnPoints = new List<Vector3>();
    public Transform[] points;

    [Header("Pokemon")]
    public GameObject p_pokemon;
    public Transform pokemonParent;

    //public void Init_Herd()
    //{
    //    if (destroyAfterUse) Gen_SpawnMatrix();
    //    SpawnSheepHerd();
    //    if (destroyAfterUse) DestroyMatrix();
    //}

    //public void Init_Sheep(int num)
    //{
    //    BoidsManager.Instance.AddToBoids();
    //    if (destroyAfterUse) Gen_SpawnMatrix();
    //    AddSheep(num);
    //    if (destroyAfterUse) DestroyMatrix();
    //}

    private void Start()
    {
        Gen_SpawnMatrix();
    }

    #region Matrix

    public void Gen_SpawnMatrix()
    {
        spawnPoints.Clear();
        CreateMatrix();
        CenterMatix();
        Init_Spawners();
    }

    /// <summary>
    /// Create a matrix of positions and add it to the spawnPoints list
    /// </summary>
    private void CreateMatrix()
    {
        Vector3 pos = Vector3.zero;
        for (int x = 0; x < matrixMetrics.x; x++)
        {
            for (int y = 0; y < matrixMetrics.y; y++)
            {
                spawnPoints.Add(pos);
                pos.z += matrixDistance.y;
            }
            pos.z = 0;
            pos.x += matrixDistance.x;
        }
    }

    /// <summary>
    /// Centers the matrix around the gameobjects center (0, 0, 0)
    /// </summary>
    private void CenterMatix()
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
            Gizmos.DrawWireCube(t.position, new Vector3(matrixDistance.x*0.9f, 0, matrixDistance.y*0.9f));
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
