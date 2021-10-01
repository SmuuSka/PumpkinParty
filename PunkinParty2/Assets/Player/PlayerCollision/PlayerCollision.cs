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
        if (other.tag == "Enemy")
        {
            TakeDamage();
        }
        else if (other.tag == "Health")
        {
            MoreHealth();
        }
    }
    private void TakeDamage()
    {
        if (playerHealth.health > 0)
        {
            candleLight.pointLightOuterRadius -= 5f;
            playerHealth.health -= 1;
        }
        else
        {
            Debug.Log("Youre dead");
        }
    }
    private void MoreHealth()
    {
        if (playerHealth.health > 0 && playerHealth.health < 3)
        {
            playerHealth.health += 1;
            candleLight.pointLightOuterRadius += 5f;
        }
    }
}
