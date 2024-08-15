using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GridSpawner))]
public class SpawnPokemon : MonoBehaviour
{
    protected GridSpawner gridSpawner;
    public GameObject p_pokemon;        //pokemon prefab
    public Transform pokemonParent;

    private void Start()
    {
        gridSpawner = GetComponent<GridSpawner>();

        gridSpawner.GenerateGrid();
        PokemonSpawn();
    }

    private void PokemonSpawn()
    {
        int randNum = Random.Range(0, gridSpawner.points.Length);

        GameObject pokemon = Instantiate(p_pokemon, gridSpawner.points[randNum].position, Quaternion.identity, pokemonParent);
        pokemon.transform.position += new Vector3(0, 1, 0);
        
    }
}
