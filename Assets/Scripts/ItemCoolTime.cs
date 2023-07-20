using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageItemCoolTime : MonoBehaviour
{
    public Image itemImage;
    public Image itemFilter;
    public float lastTime = 7.0f;

    void start()
    {
        itemFilter.fillAmount = 0;
    }

    public void startItem()
    {
        // 아이콘 보여주기
        StopCoroutine("Cooltime");
        itemFilter.fillAmount = 0;
        StartCoroutine("Cooltime");
    }

    IEnumerator Cooltime()
    {
        while (itemFilter.fillAmount <= 1)
        {
            itemFilter.fillAmount += 1 * Time.smoothDeltaTime / lastTime;

            yield return null;
        }

        // 아이콘 숨기기

        yield break;
    }
}
