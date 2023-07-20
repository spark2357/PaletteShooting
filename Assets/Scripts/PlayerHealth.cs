using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public HealthBar healthBar;

    public float maxHealth = 100f;
    public float health;
    public float damage = 10f;

    void Start()
    {
        health = maxHealth;
        healthBar.setMaxHealth(maxHealth);
    }
    
    public void getDamage()
    {
        health -= damage;
        if (health <= 0)
        {
            healthBar.setHealth(0);
            #if UNITY_EDITOR
                        UnityEditor.EditorApplication.isPlaying = false;
            #elif UNITY_WEBPLAYER
                    Application.OpenURL(webplayerQuitURL);
            #else
                    Application.Quit();
            #endif
        }
        else
        {
            healthBar.setHealth(health);
        }
    }
}
