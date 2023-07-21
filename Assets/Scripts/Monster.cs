//몬스터 생성코드 참고

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public float velocity = 10f;
    public SpriteRenderer enemySR;
    Rigidbody2D rigid;

    public float maxHealth;
    public float health;
    public HealthBar healthBar;

    private void Awake()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
        enemySR = gameObject.GetComponent<SpriteRenderer>();
        SetRandomColor();
        health = maxHealth;
        healthBar.setMaxHealth(maxHealth);
    }
    private void FixedUpdate()
    {
        rigid.MovePosition(rigid.position + Vector2.left * velocity * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Monster_Delete")
        {
            Destroy(gameObject);
            GameObject player = GameObject.FindWithTag("Player");
            player.GetComponent<PlayerHealth>().getDamage();
        }
    }

    private void SetRandomColor()
    {
        
        int randomIndex = Random.Range(1, 8);
        switch (randomIndex)
        {
            case 1:
                enemySR.color = Color.red;
                break;
            case 2:
                enemySR.color = Color.blue;
                break;
            case 3:
                enemySR.color = Color.green;
                break;
            case 4:
                enemySR.color = Color.cyan;
                break;
            case 5:
                enemySR.color = Color.magenta;
                break;
            case 6:
                enemySR.color = Color.white;
                break;
            case 7:
                enemySR.color = new Color32(255, 255, 0, 255);
                break;
        }
    }

    public void getDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            healthBar.setHealth(maxHealth);
            die();
        }
        else
        {
            healthBar.setHealth(health);
        }
    }

    public void die()
    {
        Destroy(this.gameObject);

        // 랜덤 아이템 드롭
        int healItem = Random.Range(0, 100);
        if(healItem <= 10)
        {
            GameObject.FindWithTag("GameController").GetComponent<Item>().HealItem();
        }

        int damageItem = Random.Range(0, 100);
        if (damageItem <= 20)
        {
            GameObject.FindWithTag("GameController").GetComponent<Item>().IncreaseDamage();
        }

        int turret = Random.Range(0, 100);
        if(turret <= 5)
        {
            GameObject.FindWithTag("GameController").GetComponent<Item>().turret();
        }
    }
}
