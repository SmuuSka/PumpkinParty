using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerJoystick : MonoBehaviour
{
    [SerializeField] private GameObject point, mouse;

    private Vector3 startPosition;
    private Vector2 dragVector;
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
                    Vector2 touchPosition = Input.GetTouch(0).position;
                    startPosition = Camera.main.ScreenToWorldPoint(touchPosition);
                    startPosition.z = 0f;
                    point.transform.position = startPosition;
                    Debug.Log("Began");
                    break;

                //Determine if the touch is a moving touch
                case TouchPhase.Moved:
                    var direction = new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y,0f) - startPosition;
                    Debug.Log(direction.normalized);
                    
                    mouse.transform.position = Camera.main.ScreenToWorldPoint(direction);
                    // Determine direction by comparing the current touch position with the initial one
                    //var direction = point.transform.position - startPosition;

                    //Debug.Log("Moving");
                    //Debug.Log(direction.normalized);
                    break;

                case TouchPhase.Ended:
                    // Report that the touch has ended when it ends
                    Debug.Log("Ending");
                    break;    
            }
        }
    }
}
