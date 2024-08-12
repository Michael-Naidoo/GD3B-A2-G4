using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;


[Serializable]
public class Pokemon
{
    public int id;
    public string name;
    public PokemonType type;
    public int level;
    public int experience;
    /// <summary>
    /// 0 -> forward facing
    /// 1 -> back facing
    /// </summary>
    public Sprite[] sprites = new Sprite[2];
    public PokeStats stats = new PokeStats();
}

[Serializable]
public struct PokeStats
{
    public int HP;
    public int Attack;
    public int Defence;
    public int Speed;
    public int Special;
}

namespace Enums
{
    [Flags]
    public enum PokemonType
    {
        None = 0,
        Normal = 1 << 0,    // 0001
        Fire = 1 << 1,      // 0010
        Water = 1 << 2,     // 0100
        Electric = 1 << 3,  // 1000
        Grass = 1 << 4,     // 0001 0000
        Ice = 1 << 5,       // 0010 0000
        Fighting = 1 << 6,  // 0100 0000
        Poison = 1 << 7,    // 1000 0000
        Ground = 1 << 8,    // 0001 0000 0000
        Flying = 1 << 9,    // 0010 0000 0000
        Psychic = 1 << 10,  // 0100 0000 0000
        Bug = 1 << 11,      // 1000 0000 0000
        Rock = 1 << 12,     // 0001 0000 0000 0000
        Ghost = 1 << 13,    // 0010 0000 0000 0000
        Dragon = 1 << 14   // 0100 0000 0000 0000
    }

}
