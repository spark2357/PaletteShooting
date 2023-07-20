using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            SpriteRenderer bulletSR = collision.gameObject.GetComponent<SpriteRenderer>();
            SpriteRenderer enemySR = gameObject.GetComponent<SpriteRenderer>();

            if (bulletSR.color == enemySR.color)
            {
                Destroy(collision.gameObject);
                gameObject.GetComponent<Monster>().getDamage(collision.gameObject.GetComponent<Bullet>().damage);
            }
        }

        else if(collision.gameObject.tag == "Bullet_Black")
        {
            Destroy(gameObject);
        }
    }
}
