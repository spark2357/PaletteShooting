//종스크롤 슈팅게임 몬스터 코드 참고함 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Monobehaviour
{ //몬스터에서 컬러속성 어케할건지....
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
        if (collision.gameObject.tag == "BorderBullet") //여기선 맵 끝(border bullet)에 도달시 적이 파괴되는 코드로 작성했지만 추가로 주인공에게 데미지가 들어가야함
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
