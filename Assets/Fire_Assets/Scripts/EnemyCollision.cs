using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            SpriteRenderer bulletSR = collision.gameObject.GetComponent<SpriteRenderer>();
            SpriteRenderer enemySR = gameObject.GetComponent<SpriteRenderer>();

            Debug.Log(bulletSR.color);
            Debug.Log(enemySR.color);

            if(bulletSR.color == enemySR.color)
            {
                Destroy(collision.gameObject);
                // 대미지 받기
                Destroy(gameObject);
            }
        }
    }
}
