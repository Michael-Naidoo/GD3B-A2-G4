using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchRecognition : MonoBehaviour
{
    private float tempMaxAngle;

    [SerializeField] private bool curveBall;

    public PokeballData PokeballData;

    // Coordinates of points A, B, and C
    public Vector2 pointA;
    public Vector2 pointB;
    public Vector2 pointC;

    public float curveMultiplier;

    private Vector3 startPosition;

    private Rigidbody rb;
    private Vector3 moveDirection;
    public float forceMultiplierX;
    public float forceMultiplierY;
    public float forwardForce;
    public int holdTimer;
    public int holdTimerMax;
    public int nodeSpawnTimer;
    public int nodeSpawnTimerMax;
    private bool beingHeld = false;
    private bool touchStart = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.touchCount == 0 && CatchManager.Instance.canTouch && !TouchUI_PC())
        {
            if (Input.GetMouseButton(0))
            {
                curveBall = false;
                PokeballData.curveBall = false;
                rb.velocity = Vector3.zero;
                Vector2 mousePos = Input.mousePosition;
                Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, Camera.main.WorldToScreenPoint(transform.position).z));
                touchPosition.z = 0; // Maintain the object's Z position
                if (!touchStart)
                {
                    startPosition = transform.position;
                    touchStart = true;
                }
                transform.position = touchPosition;
                rb.velocity = Vector3.zero;
                rb.rotation = Quaternion.identity;
                rb.angularVelocity = Vector3.zero;
                beingHeld = true;
                if (holdTimer == 0)
                {
                    moveDirection = transform.position - startPosition;
                    holdTimer = holdTimerMax;
                }

                if (nodeSpawnTimer == 0)
                {
                    pointA = pointB;
                    pointB = transform.position;
                    nodeSpawnTimer = nodeSpawnTimerMax;
                }

                holdTimer--;
                nodeSpawnTimer--;
                Debug.DrawRay(transform.position, new Vector3(0, 0, forwardForce) + new Vector3(moveDirection.x * forceMultiplierX, 0, 0) + new Vector3(0, moveDirection.y * forceMultiplierY), Color.red);
            }
            else if (Input.GetMouseButtonUp(0))
            {
                touchStart = false;
                if (beingHeld)
                {
                    rb.AddForce(new Vector3(0, 0, forwardForce) + new Vector3(0, moveDirection.y * forceMultiplierY), ForceMode.Impulse);
                    rb.AddTorque(Vector3.right * 5, ForceMode.Impulse);
                }

                float distance = PerpendicularDistance(pointA, pointB, startPosition);

                // Debug the distance and cross-product results
                //Debug.Log($"Distance: {distance}");

                // Apply the force along the X-axis using the distance
                if (distance * 1000 > 170 || distance * 1000 < -170)
                {
                    Debug.LogError("curving");
                    PokeballData.curveBall = true;
                    curveBall = true;
                }
                else
                {

                    PokeballData.curveBall = false;
                    curveBall = false;
                }

                if (curveBall)
                {
                    rb.AddForce(new Vector3(distance * curveMultiplier, 0, 0), ForceMode.Acceleration);
                    rb.AddTorque(new Vector3(1, 0, (distance > 0) ? 9000 : -9000) * 5, ForceMode.Impulse);
                }

                // Adjust max angle based on distance
                if (distance < 0 && distance * 1000 < -tempMaxAngle)
                {
                    tempMaxAngle = -distance * 1000;
                    Debug.LogError("tempMaxAngle = " + distance * 1000);
                }
                else if (distance * 1000 > tempMaxAngle)
                {
                    tempMaxAngle = distance * 1000;
                    Debug.LogError("tempMaxAngle = " + tempMaxAngle);
                }

                beingHeld = false;
                holdTimer = holdTimerMax;
            }

        }


        else if (!TouchUI() && CatchManager.Instance.canTouch)
        {
            if (Input.touchCount > 0)
            {
                curveBall = false;
                PokeballData.curveBall = false;
                rb.velocity = Vector3.zero;
                Touch touch = Input.GetTouch(0);
                Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, Camera.main.WorldToScreenPoint(transform.position).z));
                touchPosition.z = 0; // Maintain the object's Z position
                if (!touchStart)
                {
                    startPosition = transform.position;
                    touchStart = true;
                }
                transform.position = touchPosition;
                rb.velocity = Vector3.zero;
                rb.rotation = Quaternion.identity;
                rb.angularVelocity = Vector3.zero;
                beingHeld = true;
                if (holdTimer == 0)
                {
                    moveDirection = transform.position - startPosition;
                    holdTimer = holdTimerMax;
                }

                if (nodeSpawnTimer == 0)
                {
                    pointA = pointB;
                    pointB = transform.position;
                    nodeSpawnTimer = nodeSpawnTimerMax;
                }

                holdTimer--;
                nodeSpawnTimer--;
                Debug.DrawRay(transform.position, new Vector3(0, 0, forwardForce) + new Vector3(moveDirection.x * forceMultiplierX, 0, 0) + new Vector3(0, moveDirection.y * forceMultiplierY), Color.red);
            }
            else if (Input.touchCount == 0)
            {
                touchStart = false;
                if (beingHeld)
                {
                    rb.AddForce(new Vector3(0, 0, forwardForce) + new Vector3(0, moveDirection.y * forceMultiplierY), ForceMode.Impulse);
                    rb.AddTorque(Vector3.right * 5, ForceMode.Impulse);
                }

                float distance = PerpendicularDistance(pointA, pointB, startPosition);

                // Debug the distance and cross-product results
                //Debug.Log($"Distance: {distance}");

                // Apply the force along the X-axis using the distance
                if (distance * 1000 > 170 || distance * 1000 < -170)
                {
                    Debug.LogError("curving");
                    PokeballData.curveBall = true;
                    curveBall = true;
                }
                else
                {

                    PokeballData.curveBall = false;
                    curveBall = false;
                }

                if (curveBall)
                {
                    rb.AddForce(new Vector3(distance * curveMultiplier, 0, 0), ForceMode.Acceleration);
                    rb.AddTorque(new Vector3(1, 0, (distance > 0)? 9000:-9000) * 5, ForceMode.Impulse);
                }

                // Adjust max angle based on distance
                if (distance < 0 && distance * 1000 < -tempMaxAngle)
                {
                    tempMaxAngle = -distance * 1000;
                    Debug.LogError("tempMaxAngle = " + distance * 1000);
                }
                else if (distance * 1000 > tempMaxAngle)
                {
                    tempMaxAngle = distance * 1000;
                    Debug.LogError("tempMaxAngle = " + tempMaxAngle);
                }

                beingHeld = false;
                holdTimer = holdTimerMax;
            }
        }
    }

    private bool TouchUI()
    {
        if (Input.touchCount > 0)
        {
            int id = Input.GetTouch(0).fingerId;

            return EventSystem.current.IsPointerOverGameObject(id);
        }

        return false;
    }
    private bool TouchUI_PC()
    {
        return EventSystem.current.IsPointerOverGameObject();

    }

    float PerpendicularDistance(Vector2 A, Vector2 B, Vector2 C)
    {
        // Coefficients of the line equation Ax + By + C = 0
        float A_coeff = C.y - A.y;
        float B_coeff = -(C.x - A.x);
        float C_coeff = A.y * (C.x - A.x) - A.x * (C.y - A.y);

        // Perpendicular distance formula (without absolute value)
        float distance = (A_coeff * B.x + B_coeff * B.y + C_coeff) / Mathf.Sqrt(A_coeff * A_coeff + B_coeff * B_coeff);

        // Determine the sign based on the cross product
        // Vector AB = B - A
        // Vector AC = C - A
        Vector2 AB = B - A;
        Vector2 AC = C - A;
        float crossProduct = AB.x * AC.y - AB.y * AC.x;

        // If the cross product is negative, the point is to the left; otherwise, it's to the right
        if (crossProduct < 0)
        {
            distance = -Mathf.Abs(distance);
        }
        else
        {
            distance = Mathf.Abs(distance);
        }

        return distance;
    }

}