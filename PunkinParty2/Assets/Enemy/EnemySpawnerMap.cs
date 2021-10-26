using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemySpawnerMap : MonoBehaviour
{
    [SerializeField] private Tilemap enemySpawnerMap;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] [Range(-180f, 180f)] float angle;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;
            Vector3Int gridPosition = enemySpawnerMap.WorldToCell(mousePosition);

            TileBase clickedTile = enemySpawnerMap.GetTile(gridPosition);

            Debug.Log("GridPos " + gridPosition + " is a" + clickedTile);
            SpawnEnemy(gridPosition);
        }
    }

    private void SpawnEnemy(Vector3Int position)
    {
        Quaternion quat = Quaternion.AngleAxis(angle, transform.forward);
        Instantiate(enemyPrefab, position, quat);
    }
}
