using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapScript : MonoBehaviour
{
    [SerializeField] private GameObject map;
    [SerializeField] private Button mapButtonOn, mapButtonOff;
    [SerializeField] private GameObject playerRefe;


    private void Awake()
    {
        mapButtonOff.gameObject.SetActive(false);
    }

    private void Update()
    {
        map.transform.position = playerRefe.transform.position;
        mapButtonOn.onClick.AddListener(MapOn);
        mapButtonOff.onClick.AddListener(MapOff);
    }

    private void MapOn()
    {
        map.SetActive(true);
        mapButtonOn.gameObject.SetActive(false);
        mapButtonOff.gameObject.SetActive(true);
        playerRefe.GetComponent<PlayerMoveController>().canMove = false;
    }
    private void MapOff()
    {
        map.SetActive(false);
        mapButtonOn.gameObject.SetActive(true);
        mapButtonOff.gameObject.SetActive(false);
        playerRefe.GetComponent<PlayerMoveController>().canMove = true;
    }
}
