using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    public float speed = 10.0f;
    public float flyingTime = 2.5f;
    public Vector2 dir = Vector2.right;

    private void Start()
    {
        Invoke("destroySelf", flyingTime);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + Vector2.right * speed * Time.fixedDeltaTime);
    }

    private void destroySelf()
    {
        Destroy(this.gameObject);
    }
}