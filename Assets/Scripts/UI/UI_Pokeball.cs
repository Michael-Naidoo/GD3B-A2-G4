using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Pokeball : MonoBehaviour
{
    public UI_PokeballManager manager;
    public PokeBallTypes buttonType;

    public void SetCurrentToThis()
    {
        manager.SetPokeballType(buttonType);
        manager.OpenCloseUI();
    }
}
