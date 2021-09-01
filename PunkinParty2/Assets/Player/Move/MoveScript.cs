using UnityEngine;
using UnityEngine.EventSystems;

public class MoveScript : MonoBehaviour
{
    [SerializeField] private PlayerJoystick joystick;
    [SerializeField] float moveSpeed;

    Rigidbody2D playerRb;
   
    private void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Move();
    }
    private void Move()
    {
        moveSpeed = joystick.distance;
        transform.eulerAngles = new Vector3(0, 0, joystick.angle);
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime, Space.Self);
    }
}

