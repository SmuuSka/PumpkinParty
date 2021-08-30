using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJoystick : MonoBehaviour
{
    [SerializeField] Joystick joystick;
    [SerializeField] GameObject canvas;
    private Joystick joystickCopy;

    private Camera mainCamera;

    private Vector2 startPos;

    //private Touch touch;

    private void Awake()
    {
        mainCamera = Camera.main;
    }
    private void Update()
    {
        //JoystickLogic();
        States();
    }

    //private void JoystickLogic()
    //{ 
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        touch = Input.GetTouch(0);
    //        if (GameObject.Find("Fixed Joystick(Clone)") != null)
    //        {
    //            return;
    //        }

    //        Vector2 touchPosition = touch.position;
    //        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(touchPosition);
    //        worldPosition.z = 0f;

    //        joystick.transform.position = touchPosition;
    //        joystickCopy = Instantiate(joystick, touchPosition, Quaternion.identity);
    //        joystickCopy.transform.SetParent(canvas.transform);
    //    }
    //}

    
    private void States()
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
                    startPos = touch.position;
                    var message = "Begun ";
                    Debug.Log(message);
                    if (GameObject.Find("Fixed Joystick(Clone)") != null)
                    {
                        return;
                    }

                    Vector2 touchPosition = touch.position;
                    Vector3 worldPosition = mainCamera.ScreenToWorldPoint(touchPosition);
                    worldPosition.z = 0f;

                    joystick.transform.position = touchPosition;
                    joystickCopy = Instantiate(joystick, touchPosition, Quaternion.identity);
                    joystickCopy.transform.SetParent(canvas.transform);
                    break;

                //Determine if the touch is a moving touch
                case TouchPhase.Moved:
                    // Determine direction by comparing the current touch position with the initial one
                    var direction = touch.position - startPos;
                    message = "Moving ";
                    Debug.Log(message);
                    break;

                case TouchPhase.Ended:
                    // Report that the touch has ended when it ends
                    message = "Ending ";
                    Debug.Log(message);
                    //Destroy(GameObject.Find("Fixed Joystick(Clone)"));
                    break;
            }
        }
    }
}
