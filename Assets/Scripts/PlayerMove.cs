using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            if(transform.position.y < 0)
            {
                transform.position = new Vector3(transform.position.x, 1.75f, transform.position.z);
            }
            else
            {
                transform.position = new Vector3(transform.position.x, -2.4f, transform.position.z);
            }
        }
    }
}
