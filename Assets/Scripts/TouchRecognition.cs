using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchRecognition : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 moveDirection;
    public float forceMultiplier;
    public float forwardForce;
    public int holdTimer;
    private bool beingHeld = false;

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
            touchPosition.z = 0; // Maintain the object's Z position
            Vector3 previousPosition = transform.position;
            transform.position = touchPosition;
            rb.velocity = Vector3.zero;
            beingHeld = true;
            if (holdTimer == 0)
            {
                moveDirection = previousPosition - transform.position;
                holdTimer = 5;
            }

            holdTimer--;
        }
        else if (Input.touchCount == 0 && beingHeld == true)
        {
            rb.AddForce((moveDirection.normalized + new Vector3(0, 0, -forwardForce)) * forceMultiplier * -1, ForceMode.Impulse);
            Debug.Log(moveDirection.normalized * forceMultiplier);
            beingHeld = false;
            holdTimer = 5;
        }
    }
}