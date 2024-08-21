using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_PokeballManager : MonoBehaviour
{
    public UI_Pokeball[] pokeball_buttons;

    public Dictionary<PokeBallTypes, Sprite> pokeball_sprites;

    public bool isOpen;

    public Animator animator;

    private void Start()
    {
        pokeball_sprites.Add(PokeBallTypes.Pokeball, pokeball_buttons[0].image.sprite);
        pokeball_sprites.Add(PokeBallTypes.Greatball, pokeball_buttons[1].image.sprite);
        pokeball_sprites.Add(PokeBallTypes.UltraBall, pokeball_buttons[2].image.sprite);
    }
}
