using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Properties;
using UnityEngine;

public class SpawnWildPokemon : MonoBehaviour
{
    [SerializeField] private GameObject p_wildPokemon;
    [SerializeField] private Transform wildPokemon_parent;
    private Transform[] spawnPoints = new Transform[0];

    [Space(10)]
    [SerializeField] private List<GameObject> activePokemon = new List<GameObject>();
    [SerializeField] private int max_activePokemon;
    [SerializeField] private Vector2 despawnTimerRange;

    [Space(10)]
    [SerializeField] private float spawnRadius;
    [SerializeField] private float spawnTime;
    [SerializeField] private float currTime;
    [SerializeField] private int pokemonEachSpawnWave;


    private Stack<Transform> spawnStack = new Stack<Transform>();

    private void Start()
    {
        GetComponent<GridSpawner>().GenerateGrid();

        ShuffleIntoStack(GetComponent<GridSpawner>().points);

        currTime = spawnTime;
    }

    private void Update()
    {
        if (activePokemon.Count < max_activePokemon)
        {
            if (currTime <= 0)
            {
                currTime = spawnTime;
                for (int i = 0; i < pokemonEachSpawnWave; i++)
                {
                    SelectSpawners();
                }
            }
            currTime -= Time.deltaTime;
        }
    }

    private void SelectSpawners()
    {
        if (spawnStack.Count <= 0) ShuffleIntoStack(spawnPoints);

        Transform spawner = spawnStack.Pop();
        Vector2 randPos = Random.insideUnitCircle * spawnRadius;
        SpawnPokemon(spawner.position + new Vector3(randPos.x, 0.5f, randPos.y));
    }

    private void SpawnPokemon(Vector3 pos)
    {
        GameObject newPokemon = Instantiate(p_wildPokemon, pos, Quaternion.identity, wildPokemon_parent);
        _PokeData[] allPokemon = Resources.LoadAll<_PokeData>("Pokemon");

        newPokemon.GetComponent<WildPokemon>().pokeData = allPokemon[Random.Range(0, allPokemon.Length)];
        newPokemon.GetComponent<WildPokemon>().SetGUI();

        activePokemon.Add(newPokemon);
        StartCoroutine(DespawnTimer(newPokemon));
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

    private IEnumerator DespawnTimer(GameObject pokemon)
    {
        float randNum = Random.Range(despawnTimerRange.x, despawnTimerRange.y);

        yield return new WaitForSeconds(randNum);

        activePokemon.Remove(pokemon);
        Destroy(pokemon);
    }
}
