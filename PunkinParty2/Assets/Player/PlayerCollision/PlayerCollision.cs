using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class PlayerCollision : MonoBehaviour
{

    [SerializeField] private Candle playerHealth;
    [SerializeField] private Light2D candleLight;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other && playerHealth.health > 0)
        {

            candleLight.pointLightOuterRadius -= 5f;
            playerHealth.health -= 1;
        }
        else
        {
            Debug.Log("Youre dead");
        }
    }
}
