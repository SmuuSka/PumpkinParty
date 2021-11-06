using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject map;
    [SerializeField] private Button mapButtonOn, mapButtonOff;
    [SerializeField] private GameObject playerRefe;
    [SerializeField] private GameObject joystick;


    private void Awake()
    {
        mapButtonOff.gameObject.SetActive(false);
        joystick.SetActive(true);
    }

    private void Update()
    {
        map.transform.position = playerRefe.transform.position;
        mapButtonOn.onClick.AddListener(MapOn);
        mapButtonOff.onClick.AddListener(MapOff);
    }

    private void MapOn()
    {
        joystick.SetActive(false);
        map.SetActive(true);
        mapButtonOn.gameObject.SetActive(false);
        mapButtonOff.gameObject.SetActive(true);
        playerRefe.GetComponent<PlayerMoveController>().canMove = false;
        PauseGame();
    }
    private void MapOff()
    {
        joystick.SetActive(true);
        map.SetActive(false);
        mapButtonOn.gameObject.SetActive(true);
        mapButtonOff.gameObject.SetActive(false);
        playerRefe.GetComponent<PlayerMoveController>().canMove = true;
        ResumeGame();
    }
    void PauseGame()
    {
        Time.timeScale = 0;
    }

    void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
