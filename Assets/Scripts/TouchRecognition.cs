using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchRecognition : MonoBehaviour
{
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, Camera.main.WorldToScreenPoint(transform.position).z));
            touchPosition.z = transform.position.z; // Maintain the object's Z position
            transform.position = touchPosition;
            rb.velocity = Vector3.zero;
        }
        else
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(transform.position).z));
            mousePosition.z = transform.position.z; // Maintain the object's Z position
            //transform.position = mousePosition;
        }
        Debug.Log(rb.velocity);
    }
}