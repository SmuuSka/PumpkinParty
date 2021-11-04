using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Candle : MonoBehaviour
{
    [SerializeField] private List<Image> candleIcons = new List<Image>();
    public int health;

    private void Start()
    {
        health = 2;
    }

    private void Update()
    {
        Health();
    }

    public void Health()
    {
        if (health == 2)
        {
            candleIcons[0].enabled = true;
            candleIcons[1].enabled = false;
            candleIcons[2].enabled = false;
        }
        else if (health == 1)
        {
            candleIcons[0].enabled = false;
            candleIcons[1].enabled = true;
            candleIcons[2].enabled = false;
        }
        else if (health == 0)
        {
            candleIcons[0].enabled = false;
            candleIcons[1].enabled = false;
            candleIcons[2].enabled = true;
            SceneManager.LoadScene(0);
        }
    }
}
