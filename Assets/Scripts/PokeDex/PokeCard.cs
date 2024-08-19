using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PokeCard : MonoBehaviour, IPointerClickHandler
{
    public PokeStats pokeStats;
    public Image image;
    public TextMeshProUGUI title;

    public void OnPointerClick(PointerEventData eventData)
    {
        PokedexManager.Instance.ActiveStatsPanel(pokeStats);
    }
}
