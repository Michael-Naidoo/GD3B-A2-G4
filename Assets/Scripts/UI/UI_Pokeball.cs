using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Pokeball : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private UI_PokeballManager manager;
    public PokeBallTypes pokeball_type;
    public Image image;
    public bool isCurrentBall;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (isCurrentBall)
        {
            if (manager.isOpen)
            {
                manager.animator.SetBool("isOpen", false);
                manager.isOpen = false;
            }
            else
            {
                manager.animator.SetBool("isOpen", true);
                manager.isOpen = true;
            }
        }
        else
        {
            manager.SelectPokeball(this);
        }
    }
}
