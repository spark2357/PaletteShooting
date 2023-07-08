//����ũ�� ���ð��� ���� �ڵ� ������ 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Monobehaviour
{ //���Ϳ��� �÷��Ӽ� �����Ұ���....
    public float speed;
    public int health;
    public int color;
    public Sprite[] sprites;

    Rigidbody2D rigid;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = Vector2.right * speed;
    }

    void OnHit(int color)
    {
        if (0)
        {
            health -= 1;
            spriteRenderer.sprite = sprites[1];
            invoke("ReturnSprite", 0.1f);

            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
    void ReturnSprite()
    {
        spriteRenderer.sprite = sprites[0];
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BorderBullet") //���⼱ �� ��(border bullet)�� ���޽� ���� �ı��Ǵ� �ڵ�� �ۼ������� �߰��� ���ΰ����� �������� ������
        {
            Destroy(gameObject);
        }
        elseif(collision.gameObject.tag == "PlayerBullet"){
            Bullet bullet = collision.gameObject.GetComponent<bullet>();
            OnHit(bullet.dmg);
            Destroy(collision.gameObject);
        }
    }

};
