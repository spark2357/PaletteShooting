using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageItemLastTime : MonoBehaviour
{
    public Image itemImage;
    public Image itemFilter;
    public float lastTime = 7.0f;

    public GameObject itemManager;
    private Item item;

    private bool running;

    void Start()
    {
        itemFilter.fillAmount = 0;
        item = itemManager.GetComponent<Item>();
        itemImage.enabled = false;
        running = false;
    }

    public void startItem()
    {
        if (running == true)
        {
            StopCoroutine("LastTime");
            running = false;
        }
        itemFilter.fillAmount = 0;
        itemImage.enabled = true;
        StartCoroutine("LastTime");
    }

    IEnumerator LastTime()
    {
        while (itemFilter.fillAmount < 1)
        {
            itemFilter.fillAmount += 1 * Time.smoothDeltaTime / lastTime;

            yield return null;
        }

        item.normalizeDamage();
        itemImage.enabled = false;
        running = false;

        yield break;
    }
}
