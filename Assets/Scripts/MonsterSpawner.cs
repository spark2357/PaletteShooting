using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject spawnableObject;
    public float spawnInterval = 5f;

    private float timer = 0f;
    void Update()
    {
        if (timer <= 0f)
        {
            timer = spawnInterval;          //������ ������ ������Ʈ�� ������ ����
            Instantiate(spawnableObject, transform.position, Quaternion.identity); //���� ������ ���� ���ڵ�
        }
        timer -= Time.deltaTime;
    }
}