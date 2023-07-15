using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject firePosition;
    public SpriteRenderer bulletSR;

    private bool isAttackDelaying = false;
    public float attackDelay = 0.3f;

    private void FixedUpdate()
    {
        Attack();
    }

    private void Attack()
    {
        if (!isAttackDelaying && (Input.GetKey(KeyCode.Alpha1) || Input.GetKey(KeyCode.Alpha2) || Input.GetKey(KeyCode.Alpha3)))
        {
            bool r = false, g = false, b = false;
            if (Input.GetKey(KeyCode.Alpha1)) r = true;
            if (Input.GetKey(KeyCode.Alpha2)) g = true;
            if (Input.GetKey(KeyCode.Alpha3)) b = true;

            GameObject bullet = Instantiate(bulletPrefab);
            bullet.transform.position = firePosition.transform.position;
            bullet.GetComponent<Bullet>().damage = 10.0f;
            bulletSR = bullet.GetComponent<SpriteRenderer>();

            if (r && g && b)
            {
                bulletSR.color = Color.white;
            }
            else if (r && g)
            {
                bulletSR.color = new Color32(255, 255, 0, 255);
            }
            else if (r && b)
            {
                bulletSR.color = Color.magenta;
            }
            else if (g && b)
            {
                bulletSR.color = Color.cyan;
            }
            else if (r)
            {
                bulletSR.color = Color.red;
            }
            else if (g)
            {
                bulletSR.color = Color.green;
            }
            else if (b)
            {
                bulletSR.color = Color.blue;
            }

            isAttackDelaying = true;
            Invoke("delayTime", attackDelay);
        }
    }

    private void delayTime()
    {
        isAttackDelaying = false;
    }
}
