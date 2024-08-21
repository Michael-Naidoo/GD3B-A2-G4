using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
[Serializable]
// This is a ScriptableObject of the Players Pokemon
public class _Pokemon : ScriptableObject
{
    public List<PokeStats> player_pokemon = new List<PokeStats>();
    //here
}
