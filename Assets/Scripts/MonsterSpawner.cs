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
            timer = spawnInterval;          //위에서 설정한 오브젝트를 생성할 간격
            Instantiate(spawnableObject, transform.position, Quaternion.identity); //스폰 정보에 대한 인자들
        }
        timer -= Time.deltaTime;
    }
}