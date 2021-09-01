using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerJoystick : MonoBehaviour
{
    [SerializeField] private GameObject point;
    [HideInInspector]
    public Vector2 touchPositionCurrent;
    [HideInInspector]
    public Vector3 startPosition, currentPosition;
    [HideInInspector]
    private Vector2 direction;
    [HideInInspector]
    public GameObject mouse;
    [HideInInspector]
    public bool touchEnd;
    [HideInInspector]
    public float distance;
    [HideInInspector]
    public float angle;
    [HideInInspector]
    private float sign = 1;
    private float offset = 0;

    private void Update()
    {
        DetectedTouch();
    }

    private void DetectedTouch()
    {
        if (Input.touchCount > 0)
        {

            Touch touch = Input.GetTouch(0);

            // Handle finger movements based on TouchPhase
            switch (touch.phase)
            {
                //When a touch has first been detected, change the message and record the starting position
                case TouchPhase.Began:
                    OnStartTouch();
                    break;

                //Determine if the touch is a moving touch
                case TouchPhase.Moved:
                    OnMoveTouch();
                    touchEnd = false;
                    break;

                case TouchPhase.Ended:
                    // Report that the touch has ended when it ends
                    OnEndTouch();
                    break;
            }
        }
        else
        {
            touchEnd = true;
        }
    }

    private void OnStartTouch()
    {
        Vector2 touchPosition = Input.GetTouch(0).position;
        startPosition = Camera.main.ScreenToWorldPoint(touchPosition);
        startPosition.z = 0f;
        point.transform.position = startPosition;
    }
    private void OnMoveTouch()
    {

        touchPositionCurrent = new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y);
        currentPosition = Camera.main.ScreenToWorldPoint(touchPositionCurrent);
        currentPosition.z = 0f;
        mouse.transform.position = currentPosition;
        distance = Vector2.Distance(startPosition, currentPosition);
        if (distance < 0.5f)
        {
            return;
        }
        else
        {
            direction = mouse.transform.position - startPosition;

            sign = (direction.y >= 0) ? 1 : -1;
            offset = (sign >= 0) ? 0 : 360;

            angle = Vector2.Angle(Vector2.right, direction) * sign + offset;
        }
        Debug.DrawLine(startPosition, currentPosition, Color.green, 5f);
    }

    private void OnEndTouch()
    {
        distance = 0f;
        mouse.transform.position = point.transform.position;
        touchEnd = true;
        
    }
}
