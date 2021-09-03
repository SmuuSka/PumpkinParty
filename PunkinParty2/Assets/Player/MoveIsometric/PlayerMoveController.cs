using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 1f;
    [SerializeField] private PlayerJoystick joystick;
    private IsometricCharacterRenderer isoRenderer;
    private Rigidbody2D playerRb;

    public Vector2 movement;
    private Vector2 inputVector;

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
        isoRenderer = GetComponentInChildren<IsometricCharacterRenderer>();
    }
    void FixedUpdate()
    {
        Vector2 currentPos = playerRb.position;
        //float horizontalInput = Input.GetAxisRaw("Horizontal");
        //float verticalInput = Input.GetAxisRaw("Vertical");
        var inputH = joystick.horizontalInput;
        var inputV = joystick.verticalInput;
        if (inputH != 0 && inputV != 0)
        {
           float inputVer = (float)inputV / 2;
            Debug.Log("input V: " + inputVer);
           inputVector = new Vector2(inputH, inputVer);
        }
        else
        {
            inputVector = new Vector2(inputH, inputV);
        }
        //inputVector = new Vector2(inputH, inputV);
        //Vector2 inputVector = new Vector2(joystick.horizontalInput,joystick.verticalInput);
        Debug.Log(inputVector);
        //transform.eulerAngles = new Vector3(0, 0, joystick.angle);
        //transform.Translate(Vector2.right * movementSpeed * Time.deltaTime, Space.Self);

        inputVector = Vector2.ClampMagnitude(inputVector, 1);
        movement = inputVector * movementSpeed;
        Vector2 newPos = currentPos + movement * Time.fixedDeltaTime;
        isoRenderer.SetDirection(movement);
        playerRb.MovePosition(newPos);


    }
}
