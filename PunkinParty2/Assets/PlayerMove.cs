using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] PlayerJoystick joystick;

    private void Update()
    {
        transform.Translate(new Vector3(joystick.mouse.transform.position.x, joystick.mouse.transform.position.y, 0f) * Time.deltaTime);
    }
}
