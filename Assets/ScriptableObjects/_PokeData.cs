using Enums;
using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
[Serializable]
public class _PokeData : ScriptableObject
{
    public int id;
    public string pokeName;
    public PokemonType type;
    public Sprite sprite;
    public int max_HP;
    public int max_CP;
    public float ave_weight;
    public float ave_height;
    public Vector2Int level;
    [Space(10)]
    public int evolutionStage;
    public _PokeData[] evolutions;
    [Space(10)]
    public float baseCaptureRate;
    public float baseFleeRate;
}

[CreateAssetMenu]
[Serializable]
public class _Pokemon : ScriptableObject
{
    public List<PokeStats> player_pokemon = new List<PokeStats>();
}
