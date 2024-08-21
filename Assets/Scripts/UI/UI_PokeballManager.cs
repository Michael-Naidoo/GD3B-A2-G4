using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_PokeballManager : MonoBehaviour
{
    public UI_Pokeball[] pokeball_buttons = new UI_Pokeball[3];
    public UI_Pokeball current_pokeball;

    public Dictionary<PokeBallTypes, Sprite> pokeball_sprites = new Dictionary<PokeBallTypes, Sprite>();

    public bool isOpen;

    public Animator animator;

    private void Start()
    {
        pokeball_sprites.Add(PokeBallTypes.Pokeball, pokeball_buttons[0].image.sprite);
        pokeball_sprites.Add(PokeBallTypes.Greatball, pokeball_buttons[1].image.sprite);
        pokeball_sprites.Add(PokeBallTypes.UltraBall, pokeball_buttons[2].image.sprite);
    }

    public void SelectPokeball(UI_Pokeball selected_pokeball)
    {
        current_pokeball.isCurrentBall = false;

        for (int i = 0; i < pokeball_buttons.Length; i++)
        {
            if (pokeball_buttons[i] == selected_pokeball)
            {
                for (int j = 0; j < pokeball_buttons.Length; j++)
                {
                    if (pokeball_buttons[j] == current_pokeball)
                    {
                        UI_Pokeball temp = pokeball_buttons[j];
                        pokeball_buttons[j] = pokeball_buttons[i];
                        pokeball_buttons[i] = temp;
                    }
                }
            }
        }

        current_pokeball = selected_pokeball;

        current_pokeball.isCurrentBall = true;

        foreach (UI_Pokeball uI_Pokeball in pokeball_buttons)
        {
            uI_Pokeball.image.sprite = pokeball_sprites[uI_Pokeball.pokeball_type];
        }

        for (int i = 0; i < pokeball_buttons.Length; ++i)
        {
            transform.GetChild(2-i).GetComponent<UI_Pokeball>().image.sprite = pokeball_buttons[i].image.sprite;

        }

    }
}
