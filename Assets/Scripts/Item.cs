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

    private void Start()
    {
        playerHealth = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();
        playerFire = GameObject.FindWithTag("Player").GetComponent<PlayerFire>();
    }

    public void HealItem()
    {
        //Debug.Log("체력 증가");
        playerHealth.heal();
    }

    public void IncreaseDamage()
    {
        Debug.Log("대미지 증가");
        playerFire.bulletDamage = 30.0f;
        damageItemImage.GetComponent<DamageItemLastTime>().startItem();
    }

    public void normalizeDamage()
    {
        Debug.Log("대미지 초기화");
        playerFire.bulletDamage = 10.0f;
    }
}
