//몬스터 생성코드 참고

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{ //몬스터에서 컬러속성 어케할건지....
    public float velocity;
    public int hp = 1;
    public int color;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = new Vector(-1,rigid,velocity.y);
    }

    void OnHit(int color)
    {
        if (color==this.color)
        {
            hp -= 1;
            if (hp <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
};
