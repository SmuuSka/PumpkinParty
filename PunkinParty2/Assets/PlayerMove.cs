using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] PlayerJoystick joystick;
    private Rigidbody2D playerRb;
    [SerializeField] private float moveSpeed;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        if (!joystick.touchEnd)
        {
            Move();
        }
    }

    private void Move()
    {
        //playerRb.MovePosition();
    }
}
