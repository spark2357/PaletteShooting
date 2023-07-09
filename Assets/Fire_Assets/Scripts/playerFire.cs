using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerFire : MonoBehaviour
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
            bulletSR = bullet.GetComponent<SpriteRenderer>();

            if (r && g && b)
            {
                bulletSR.material.color = Color.white;
            }
            else if (r && g)
            {
                bulletSR.material.color = Color.yellow;
            }
            else if (r && b)
            {
                bulletSR.material.color = Color.magenta;
            }
            else if (g && b)
            {
                bulletSR.material.color = Color.cyan;
            }
            else if (r)
            {
                bulletSR.material.color = Color.red;
            }
            else if (g)
            {
                bulletSR.material.color = Color.green;
            }
            else if (b)
            {
                bulletSR.material.color = Color.blue;
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
