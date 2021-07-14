using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDestroyer : MonoBehaviour
{
   
    void OnCollisionEnter2D(Collision2D other) {
           if(other.gameObject.tag == "Box")
        {
            Destroy(other.gameObject);
            Destroy(other.transform.parent.gameObject); //uništava parent object
        }

        if (other.gameObject.tag == "EnemyBullet")
        {
            Destroy(other.gameObject);
            
        }
    }
   
}
