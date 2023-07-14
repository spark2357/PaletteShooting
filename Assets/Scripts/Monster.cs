//몬스터 생성코드 참고

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    private float velocity = 5f;
    public SpriteRenderer enemySR;
    Rigidbody2D rigid;
    

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        enemySR = GetComponent<SpriteRenderer>();
        SetRandomColor();
        
    }
    private void FixedUpdate()
    {
        rigid.velocity = new Vector2(-1*velocity, rigid.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Monster_Delete")
        {
            Destroy(gameObject);
            Debug.Log("몬스터 제거 실패! 플레이어 생명깎임 추가");
        }
    }

    private void SetRandomColor()
    {
        
        int randomIndex = Random.Range(1, 8);
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
