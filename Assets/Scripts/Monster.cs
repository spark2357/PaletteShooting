//몬스터 생성코드 참고

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float velocity = 5f;
    public int hp = 1;
    public SpriteRenderer enemySR;
    Rigidbody2D rigid;

    private void Awake()
    {
        SetRandomColor();
        rigid = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        rigid.velocity = new Vector2(-1, rigid, velocity.y);
    }

    private void SetRandomColor()
    {
        enemySR = enemy.GetComponent<SpriteRenderer>();
        int randomIndex = Random.Range(1, 7);
        switch (randomIndex)
        {
            case 1:
                enemySR.color = Color.red;
                break;
            case 2:
                enemySR.color = Color.blue;
                break;
            case 3:
                enemySR.color = Color.green;
                break;
            case 4:
                enemySR.color = Color.cyan;
                break;
            case 5:
                enemySR.color = Color.magenta;
                break;
            case 6:
                enemySR.color = Color.white;
                break;
            case 7:
                enemySR.color = new Color32(255, 255, 0, 255);
                break;
        }
    }
}
