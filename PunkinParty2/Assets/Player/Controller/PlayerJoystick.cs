using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJoystick : MonoBehaviour
{
    [SerializeField]private GameObject joystick;

    private void Start()
    {
        joystick.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            joystick.SetActive(true);
        }
        else
        {
            joystick.SetActive(false);
        }
    }
}
