using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
           var enemy = Instantiate(enemyPrefab, new Vector3(transform.position.x, transform.position.y -0.75f),Quaternion.identity);
            Destroy(enemy, 5f);
        }
        
    }
}
