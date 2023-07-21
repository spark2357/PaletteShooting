using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public PlayerFire playerFire;

    public float DamageItemTime = 7.0f;
    public Image damageItemImage;
    public Image turretImage;

    private void Start()
    {
        playerHealth = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();
        playerFire = GameObject.FindWithTag("Player").GetComponent<PlayerFire>();
    }

    public void HealItem()
    {
        playerHealth.heal();
    }

    public void IncreaseDamage()
    {
        playerFire.bulletDamage = 30.0f;
        damageItemImage.GetComponent<DamageItemLastTime>().startItem();
    }

    public void normalizeDamage()
    {
        playerFire.bulletDamage = 10.0f;
    }

    public void turret()
    {
        turretImage.GetComponent<TurretCoolTime>().startTurret();
    }
}
