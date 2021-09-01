using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerJoystick : MonoBehaviour
{
    [SerializeField] private GameObject point;
    [SerializeField] private Transform target;

    public Vector2 touchPositionCurrent;

    public GameObject mouse;
    public Vector3 startPosition, currentPosition;
    private Vector2 dragVector;
    public bool touchEnd, goingRight, goingLeft, goingUp, goingDown;
    public Vector2 direction;
    public float distance;
    private Vector3 velocity = Vector3.zero;
    public float angle;
    private float sign = 1;
    private float offset = 0;

    private void Update()
    {


        if (Input.touchCount > 0)
        {

            Touch touch = Input.GetTouch(0);
            
            // Handle finger movements based on TouchPhase
            switch (touch.phase)
            {
                //When a touch has first been detected, change the message and record the starting position
                case TouchPhase.Began:
                    // Record initial touch position.
                    OnStartTouch();
                    break;

                //Determine if the touch is a moving touch
                case TouchPhase.Moved:
                    OnMoveTouch();
                    touchEnd = false;
                    // Determine direction by comparing the current touch position with the initial one
                    //var direction = point.transform.position - startPosition;

                    //Debug.Log("Moving");
                    //Debug.Log(direction.normalized);
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
        //Debug.Log("Began");
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
            //angle = Mathf.Atan2(mouse.transform.localPosition.x, mouse.transform.localPosition.y) * Mathf.Rad2Deg;
            direction = mouse.transform.position - startPosition;

            sign = (direction.y >= 0) ? 1 : -1;
            offset = (sign >= 0) ? 0 : 360;

            angle = Vector2.Angle(Vector2.right, direction) * sign + offset;
            //Debug.Log(angle);

        }

        

        Debug.Log(distance);
        Debug.DrawLine(startPosition, currentPosition, Color.green, 5f);

        


        //var target = new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 0f) - startPosition;
        //var newDirection = startDirection + new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 0f);
        //var mouseStartPos = new Vector3(mouse.transform.localPosition.x, mouse.transform.localPosition.y,0f);
        //mouse.transform.position = Camera.main.ScreenToWorldPoint(target);


        ////mouse.transform.position = Camera.main.ScreenToWorldPoint(startDirection);
        //if (mouse.transform.localPosition.x - mouseStartPos.x > 0)
        //{
        //    goingRight = true;
        //    Debug.Log("Going right");
        //}
        //if (mouse.transform.localPosition.x - mouseStartPos.x < 0)
        //{
        //    goingRight = false;
        //    goingLeft = true;
        //    Debug.Log("Going right");
        //}
        //if (mouse.transform.localPosition.y - mouseStartPos.y > 0)
        //{
        //    goingRight = false;
        //    goingLeft = false;
        //    goingUp = true;
        //    Debug.Log("Going up");
        //}
        //if (mouse.transform.localPosition.y - mouseStartPos.y < 0)
        //{
        //    goingRight = false;
        //    goingLeft = false;
        //    goingUp = false;
        //    goingDown = true;
        //    Debug.Log("Going up");
        //}

        //else if (mouse.transform.position.x > 0)
        //{
        //    Debug.Log("Going left");
        //}
        //else if (mouse.transform.position.y > 0)
        //{
        //    Debug.Log("Going up");
        //}
        //else if (mouse.transform.position.y < 0)
        //{
        //    Debug.Log("Going down");
        //}
        //Debug.Log(mouse.transform.localPosition);
    }

    private void OnEndTouch()
    {
        mouse.transform.position = point.transform.position;
        touchEnd = true;
        Debug.Log("Ending");
    }
}
