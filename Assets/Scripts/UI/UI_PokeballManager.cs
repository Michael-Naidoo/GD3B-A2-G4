using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_PokeballManager : MonoBehaviour
{
    public bool isOpen;
    public TouchRecognition pokeball;
    public PokeBallTypes currentPokeball;
    [SerializeField] private Sprite[] pokeball_sprites;
    [SerializeField] private Material[] pokeball_materials;

    [SerializeField] private GameObject pokeball_GUI;
    [SerializeField] private Image currentPokeball_icon;
    [SerializeField] private Animator animator;

    private void Start()
    {
        SetPokeballType(PokeBallTypes.Pokeball);
    }

    public void OpenCloseUI()
    {
        if (isOpen)
        {
            animator.SetBool("isOpen", false);
            isOpen = false;
        }
        else
        {
            animator.SetBool("isOpen", true);
            isOpen = true;
        }
    }

    public void SetPokeballType(PokeBallTypes newType)
    {
        currentPokeball = newType;
        pokeball.PokeballData.pokeball_type = newType;

        switch (newType)
        {
            case PokeBallTypes.Pokeball:
                currentPokeball_icon.sprite = pokeball_sprites[0];
                pokeball_GUI.GetComponent<MeshRenderer>().material = pokeball_materials[0];
                break;
            case PokeBallTypes.Greatball:
                currentPokeball_icon.sprite = pokeball_sprites[1];
                pokeball_GUI.GetComponent<MeshRenderer>().material = pokeball_materials[1];
                break;
            case PokeBallTypes.UltraBall:
                currentPokeball_icon.sprite = pokeball_sprites[2];
                pokeball_GUI.GetComponent<MeshRenderer>().material = pokeball_materials[2];
                break;
        }
        //change GUI
    }
}