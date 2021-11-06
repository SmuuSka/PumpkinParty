using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Candle : MonoBehaviour
{
    [SerializeField] private List<Image> candleIcons = new List<Image>();
    [SerializeField] private PlayerCollision player;
    
    public float candleTimer;
    public int health;

    private void Start()
    {
        health = 2;
        candleTimer = 120f;
    }

    private void Update()
    {
        Health();
        CandleTimer();
    }

    public void Health()
    {
        if (health == 2 && candleTimer > 60f)
        {
            candleIcons[0].enabled = true;
            candleIcons[1].enabled = false;
            candleIcons[2].enabled = false;
        }
        else if (health == 1 && candleTimer < 60f && candleTimer > 1f)
        {
            candleIcons[0].enabled = false;
            candleIcons[1].enabled = true;
            candleIcons[2].enabled = false;
        }
        else if (health == 0 || candleTimer < 1f)
        {
            candleIcons[0].enabled = false;
            candleIcons[1].enabled = false;
            candleIcons[2].enabled = true;
            SceneManager.LoadScene(0);
        }
    }

    private void CandleTimer()
    {
        candleTimer -= Time.deltaTime;
        if (candleTimer < 60f && health == 2)
        {
            player.TimeRunning();
            return;
        }
        else if (candleTimer < 1f && health == 1)
        {
            player.TimeRunning();
            return;
        }
    }
}
