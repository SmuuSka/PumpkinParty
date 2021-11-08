using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySW : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D enemyRb;

    private Vector3 direction;

    private void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        GetMovementDirection();
    }

    private void GetMovementDirection()
    {
        direction = new Vector3(-1f, -0.5f);
        transform.position += direction * moveSpeed * Time.deltaTime;
    }
}
