using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokeGUI : MonoBehaviour
{
    [SerializeField] private Sprite sprite;
    [SerializeField] private LayerMask ground;

    /// <summary>
    /// Sets the GUI pos so that its not floating in the air
    /// </summary>
    private void GetYPos()
    {
        sprite = GetComponent<SpriteRenderer>().sprite;

        float spriteHeight = sprite.rect.height/sprite.pixelsPerUnit;

        float yPos = spriteHeight * Mathf.Sin(transform.eulerAngles.x * Mathf.Deg2Rad);

        Debug.DrawLine(transform.position, transform.position-new Vector3(0, yPos, 0));

        RaycastHit[] hit = Physics.RaycastAll(transform.position, Vector3.down, 10, ground);
        float distance = hit[0].distance;

        float dif = distance - yPos;
        transform.transform.position = transform.position - new Vector3(0, dif + 0.15f, 0);

    }
}
