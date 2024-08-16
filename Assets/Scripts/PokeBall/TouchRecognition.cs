using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchRecognition : MonoBehaviour
{
    // Coordinates of points A, B, and C
    public Vector2 pointA;
    public Vector2 pointB;
    public Vector2 pointC;

    public float curveMultiplier;

    private Vector3 previousPosition;
    
    private Rigidbody rb;
    private Vector3 moveDirection;
    public float forceMultiplier;
    public float forwardForce;
    public int holdTimer;
    public int nodeSpawnTimer;
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
            previousPosition = transform.position;
            transform.position = touchPosition;
            rb.velocity = Vector3.zero;
            beingHeld = true;
            if (holdTimer == 0)
            {
                moveDirection = previousPosition - transform.position;
                holdTimer = 5;
            }

            if (nodeSpawnTimer == 0)
            {
                pointA = pointB;
                pointB = transform.position;
                nodeSpawnTimer = 5;
            }

            holdTimer--;
            nodeSpawnTimer--;
        }
        else if (Input.touchCount == 0 && beingHeld == true)
        {
            rb.AddForce((moveDirection.normalized + new Vector3(0, 0, -forwardForce)) * forceMultiplier * -1, ForceMode.Impulse);
            float distance = PerpendicularDistance(pointA, pointB, previousPosition);
            rb.AddForce(new Vector3(distance * curveMultiplier, 0, 0), ForceMode.Acceleration);
            Debug.Log(distance);
            beingHeld = false;
            holdTimer = 5;
        }
    }
    
    float PerpendicularDistance(Vector2 A, Vector2 B, Vector2 C)
    {
        // Coefficients of the line equation Ax + By + C = 0
        float A_coeff = C.y - A.y;
        float B_coeff = -(C.x - A.x);
        float C_coeff = A.y * (C.x - A.x) - A.x * (C.y - A.y);

        // Perpendicular distance formula
        float distance = Mathf.Abs(A_coeff * B.x + B_coeff * B.y + C_coeff) / Mathf.Sqrt(A_coeff * A_coeff + B_coeff * B_coeff);

        return distance;
    }
}