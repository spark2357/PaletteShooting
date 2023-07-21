using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
   public Transform exitpotal;
   void OntriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "Player") {
            other.transform.position = exitpotal.position;

        }
   }

    }

