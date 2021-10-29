using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemySpawnerMap : MonoBehaviour
{
    [SerializeField] private Tilemap enemySpawnerMap;
    [SerializeField] private GameObject enemyPrefab;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;
            Vector3Int gridPosition = enemySpawnerMap.WorldToCell(mousePosition);
            TileBase clickedTile = enemySpawnerMap.GetTile(gridPosition);

            Debug.Log("GridPos " + gridPosition + " is a" + clickedTile);
            Vector3 pos = new Vector3(gridPosition.x, 0, gridPosition.z);
            Instantiate(enemyPrefab,pos,Quaternion.identity);
        }
    }
}
