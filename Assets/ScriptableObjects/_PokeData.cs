using Enums;
using System;
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
    public Vector2 level;
    [Space(10)]
    public int evolutionStage;
    public _PokeData[] evolutions;
}
