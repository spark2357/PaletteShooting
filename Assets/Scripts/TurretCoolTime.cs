using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretCoolTime : MonoBehaviour
{
    public Image itemImage;
    public Image itemFilter;
    public GameObject turret;
    
    public float lastTime;

    public GameObject bulletPrefab;
    private bool isAttackDelaying = false;
    public float attackDelay = 0.5f;
    public float bulletDamage = 5.0f;
    public GameObject firePosition;

    private bool running;

    void Start()
    {
        itemFilter.fillAmount = 0;
        itemImage.enabled = false;
        itemFilter.enabled = false;
        running = false;
        turret.SetActive(false);
    }

    private void FixedUpdate()
    {
        if(itemImage.enabled == true)
        {
            Attack();
        }
    }

    private void Attack()
    {
        if (!isAttackDelaying)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.transform.position = firePosition.transform.position;
            bullet.GetComponent<Bullet>().damage = 5.0f;
            SpriteRenderer bulletSR = bullet.GetComponent<SpriteRenderer>();
            bulletSR.color = Color.black;

            bullet.tag = "Bullet_Black";

            isAttackDelaying = true;
            Invoke("delayTime", attackDelay);
        }
    }

    private void delayTime()
    {
        isAttackDelaying = false;
    }

    public void startTurret()
    {
        if (running == true)
        {
            StopCoroutine("TurretLastTime");
            running = false;
        }
        itemFilter.fillAmount = 0;
        itemImage.enabled = true;
        itemFilter.enabled = true;
        turret.SetActive(true);
        StartCoroutine("TurretLastTime");
    }

    IEnumerator TurretLastTime()
    {
        while (itemFilter.fillAmount < 1)
        {
            itemFilter.fillAmount += 1 * Time.smoothDeltaTime / lastTime;

            yield return null;
        }

        itemImage.enabled = false;
        itemFilter.enabled = false;
        turret.SetActive(false);
        running = false;

        yield break;
    }
}
