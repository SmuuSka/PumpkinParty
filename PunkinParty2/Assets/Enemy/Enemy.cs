using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private void Update()
    {
        transform.position += transform.right * moveSpeed * Time.deltaTime;
    }
}
