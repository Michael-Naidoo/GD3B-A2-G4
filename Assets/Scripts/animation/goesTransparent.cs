using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goesTransparent : MonoBehaviour
{
    private Color theComp;
    private Color myColor;
    // Start is called before the first frame update
    void Start()
    {
       theComp= GetComponent<SpriteRenderer>().color;
       myColor= theComp;
    }

    // Update is called once per frame
    void Update()
    {
        myColor.a -= 0.03f;
        GetComponent<SpriteRenderer>().color = myColor;
        //Debug.Log (myColor.a);
    }
}
