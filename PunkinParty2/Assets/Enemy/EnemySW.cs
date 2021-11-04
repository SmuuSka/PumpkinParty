using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySW : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.attachedRigidbody.CompareTag("Player"))
        {
            Debug.Log("Osuma");
            Destroy(gameObject);
        }
    }

    private void DoDamage()
    {

    }
}
