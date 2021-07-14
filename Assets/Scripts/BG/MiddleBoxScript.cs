using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleBoxScript : MonoBehaviour
{
   void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "PlayerBullet")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
