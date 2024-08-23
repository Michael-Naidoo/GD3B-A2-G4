using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class WildPokemon : MonoBehaviour
{
    public _PokeData pokeData;
    [SerializeField] private GameObject GUI;
    [SerializeField] private LayerMask ground;
    [SerializeField] private SphereCollider sphere_collider;


    public void SetGUI()
    {
        GUI.GetComponent<SpriteRenderer>().sprite = pokeData.sprite;
        Sprite sprite = pokeData.sprite;
        float spriteHeight = sprite.rect.height / sprite.pixelsPerUnit;

        float yPos = spriteHeight * Mathf.Sin(GUI.transform.eulerAngles.x * Mathf.Deg2Rad);

        RaycastHit[] hit = Physics.RaycastAll(GUI.transform.position, Vector3.down, 10, ground);
        float distance = hit[0].distance;

        float dif = distance - yPos;
        GUI.transform.transform.position = GUI.transform.position - new Vector3(0, dif + 0.25f, 0);
        sphere_collider.radius = (float)pokeData.evolutionStage/2;
    }
}
