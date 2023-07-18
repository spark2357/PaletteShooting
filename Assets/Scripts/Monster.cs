//몬스터 생성코드 참고

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public float velocity = 10f;
    public SpriteRenderer enemySR;
    Rigidbody2D rigid;

    public float maxHealth = 30.0f;
    public float health;
    public MonsterHealthBar healthBar;


    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        enemySR = GetComponent<SpriteRenderer>();
        SetRandomColor();
        health = maxHealth;
        healthBar.setMaxHealth(health);
    }
    private void FixedUpdate()
    {
        rigid.velocity = new Vector2(-1*velocity, rigid.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Monster_Delete")
        {
            Destroy(gameObject);
            Debug.Log("몬스터 제거 실패! 플레이어 생명깎임 추가");
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
            healthBar.setHealth(0);
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
    }
}
