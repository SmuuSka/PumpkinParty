using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefabSE, enemyPrefabSW, enemyPrefabNW, enemyPrefabNE;
    [SerializeField] private GameObject[] spawnerSE = new GameObject[0];
    [SerializeField] private GameObject[] spawnerSW = new GameObject[0];
    [SerializeField] private GameObject[] spawnerNW = new GameObject[0];
    [SerializeField] private GameObject[] spawnerNE = new GameObject[0];
    private float timer;

    private void Start()
    {
        timer = 3f;
    }
    void Update()
    {
        //if (Input.GetMouseButtonDown(1))
        //{
        //    int i = Random.Range(0, spawnerSE.Length);
        //    //var enemy = Instantiate(enemyPrefab, new Vector3(transform.position.x, transform.position.y -0.75f),Quaternion.identity);
        //    var enemy = Instantiate(enemyPrefab, new Vector3(spawnerSE[i].transform.position.x, spawnerSE[i].transform.position.y - 0.75f), Quaternion.identity);
        //    Destroy(enemy, 20f);
        //}
        timer -= Time.deltaTime;
        while (timer < .1f)
        {
            SpawnEnemySE();
            SpawnEnemySW();
            SpawnEnemyNE();
            SpawnEnemyNW();
            timer = 3f;
            break;
        }
    }

    private void SpawnEnemySE()
    {
        int i = Random.Range(0, spawnerSE.Length);
        //var enemy = Instantiate(enemyPrefab, new Vector3(transform.position.x, transform.position.y -0.75f),Quaternion.identity);
        var enemy = Instantiate(enemyPrefabSE, new Vector3(spawnerSE[i].transform.position.x, spawnerSE[i].transform.position.y - 0.75f), Quaternion.identity);
        enemy.GetComponent<EnemySE>().moveSpeed = Random.Range(1, 4);
        Destroy(enemy, 20f);
    }

    private void SpawnEnemySW()
    {
        int i = Random.Range(0, spawnerSW.Length);
        //var enemy = Instantiate(enemyPrefab, new Vector3(transform.position.x, transform.position.y -0.75f),Quaternion.identity);
        var enemy = Instantiate(enemyPrefabSW, new Vector3(spawnerSW[i].transform.position.x, spawnerSW[i].transform.position.y - 0.75f), Quaternion.identity);
        enemy.GetComponent<EnemySW>().moveSpeed = Random.Range(1, 4);
        Destroy(enemy, 20f);
    }
    private void SpawnEnemyNW()
    {
        int i = Random.Range(0, spawnerNW.Length);
        //var enemy = Instantiate(enemyPrefab, new Vector3(transform.position.x, transform.position.y -0.75f),Quaternion.identity);
        var enemy = Instantiate(enemyPrefabNW, new Vector3(spawnerNW[i].transform.position.x, spawnerNW[i].transform.position.y - 0.75f), Quaternion.identity);
        enemy.GetComponent<EnemyNW>().moveSpeed = Random.Range(1, 4);
        Destroy(enemy, 20f);
    }
    private void SpawnEnemyNE()
    {
        int i = Random.Range(0, spawnerNE.Length);
        //var enemy = Instantiate(enemyPrefab, new Vector3(transform.position.x, transform.position.y -0.75f),Quaternion.identity);
        var enemy = Instantiate(enemyPrefabNE, new Vector3(spawnerNE[i].transform.position.x, spawnerNE[i].transform.position.y - 0.75f), Quaternion.identity);
        enemy.GetComponent<EnemyNE>().moveSpeed = Random.Range(1, 4);
        Destroy(enemy, 20f);
    }
}
