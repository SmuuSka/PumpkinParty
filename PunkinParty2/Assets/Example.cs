using UnityEngine;
using UnityEngine.EventSystems;

public class Example : MonoBehaviour
{
    [SerializeField] private PlayerJoystick joystick;
    [SerializeField] private float speed;
    private Rigidbody2D playerRb;
    private Vector3 movement, m_EulerAngleVelocity;
  



    private void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        playerRb.MoveRotation(playerRb.rotation + joystick.angle * Time.fixedDeltaTime);
    }
}
//    [SerializeField] private PlayerJoystick joystick;
//    Vector3 m_StartPosition, m_StartForce;
//    Rigidbody2D m_Rigidbody;
//    //Use Enum for easy switching between direction states
//    MoveDirection m_MoveDirection;

//    //Use these Vectors for moving Rigidbody components
//    Vector3 m_ResetVector;
//    Vector3 m_UpVector;
//    Vector3 m_RightVector;
//    const float speed = 3f;

//    void Start()
//    {
//        //You get the Rigidbody component attached to the GameObject
//        m_Rigidbody = GetComponent<Rigidbody2D>();
//        //This starts with the Rigidbody not moving in any direction at all
//        m_MoveDirection = MoveDirection.None;

//        //These are the GameObjectís starting position and Rigidbody position
//        m_StartPosition = transform.position;
//        m_StartForce = m_Rigidbody.transform.position;

//        //This Vector is set to 1 in the y axis (for moving upwards)
//        m_UpVector = Vector3.up;
//        //This Vector is set to 1 in the x axis (for moving in the right direction)
//        m_RightVector = Vector3.right;
//        //This Vector is zeroed out for when the Rigidbody should not move
//        m_ResetVector = Vector3.zero;
//    }

//    void Update()
//    {
       
//    }

//    private void FixedUpdate()
//    {
//        //This switches the direction depending on button presses
//        switch (m_MoveDirection)
//        {
//            //The starting state which resets the object
//            case MoveDirection.None:
//                //Reset to the starting position of the GameObject and Rigidbody
//                //transform.position = m_StartPosition;
//                //m_Rigidbody.transform.position = m_StartForce;
//                //This resets the velocity of the Rigidbody
//                joystick.goingDown = false;
//                joystick.goingLeft = false;
//                joystick.goingRight = false;
//                joystick.goingUp = false;
//                m_Rigidbody.velocity = Vector2.zero;
//                break;

//            //This is for moving in an upwards direction
//            case MoveDirection.Up:
//                //Change the velocity so that the Rigidbody travels upwards
//                m_Rigidbody.velocity = m_UpVector * speed;
//                break;

//            //This is for moving left
//            case MoveDirection.Left:
//                //This moves the Rigidbody to the left (minus right Vector)
//                m_Rigidbody.velocity = -m_RightVector * speed;
//                break;

//            //This is for moving right
//            case MoveDirection.Right:
//                //This moves the Rigidbody to the right
//                m_Rigidbody.velocity = m_RightVector * speed;
//                break;

//            //This is for moving down
//            case MoveDirection.Down:
//                //This moves the Rigidbody down
//                m_Rigidbody.velocity = -m_UpVector * speed;
//                break;
//        }
//    }
//    void OnGUI()
//    {
//        //Press the reset Button to switch to no mode
//        //if (GUI.Button(new Rect(100, 0, 150, 30), "Reset"))
//        //{
//        //    //Switch to start/reset case
//        //    m_MoveDirection = MoveDirection.None;
//        //}
//        if (joystick.touchEnd)
//        {
//            //Switch to start/reset case
//            m_MoveDirection = MoveDirection.None;
//        }
//        else if (!joystick.touchEnd && joystick.goingRight)
//        {
//            //Switch to the right direction
//            m_MoveDirection = MoveDirection.Right;
//        }
//        else if (!joystick.touchEnd && !joystick.goingRight && joystick.goingLeft)
//        {
//            //Switch to the left direction
//            m_MoveDirection = MoveDirection.Left;
//        }
//        else if (!joystick.touchEnd && !joystick.goingRight && !joystick.goingLeft && joystick.goingUp)
//        {
//            //Switch to the up direction
//            m_MoveDirection = MoveDirection.Up;
//        }
//        else if (!joystick.touchEnd && !joystick.goingRight && !joystick.goingLeft && !joystick.goingUp && joystick.goingDown)
//        {
//            //Switch to the up direction
//            m_MoveDirection = MoveDirection.Down;
//        }

//        //Press the Left button to switch the Rigidbody direction to the left
//        //if (GUI.Button(new Rect(100, 30, 150, 30), "Move Left"))
//        //{
//        //    //Switch to the left direction
//        //    m_MoveDirection = MoveDirection.Left;
//        //}


//        //else if (!joystick.touchEnd && joystick.mouse.transform.localPosition.y > 0)
//        //{
//        //    //Switch to the up direction
//        //    m_MoveDirection = MoveDirection.Up;
//        //}
//        //else if (!joystick.touchEnd && joystick.mouse.transform.localPosition.y < 0)
//        //{
//        //    //Switch to the down direction
//        //    m_MoveDirection = MoveDirection.Down;
//        //}

//        ////Press the Up button to switch the Rigidbody direction to upwards
//        //if (GUI.Button(new Rect(100, 60, 150, 30), "Move Up"))
//        //{
//        //    //Switch to Up Direction
//        //    m_MoveDirection = MoveDirection.Up;
//        //}

//        ////Press the Down button to switch the direction to down
//        //if (GUI.Button(new Rect(100, 90, 150, 30), "Move Down"))
//        //{
//        //    //Switch to Down Direction
//        //    m_MoveDirection = MoveDirection.Down;
//        //}

//        ////Press the right button to switch to the right direction
//        //if (GUI.Button(new Rect(100, 120, 150, 30), "Move Right"))
//        //{
//        //    //Switch to Right Direction
//        //    m_MoveDirection = MoveDirection.Right;
//        //}
//    }
//}
