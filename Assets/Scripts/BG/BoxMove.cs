using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMove : MonoBehaviour
{
    

    public float boxSpeed = 3f;
    void Start()
    {
            
        
    }

    
    void Update()
    {
        if (PlayAnimation.instance.playerDied == false) {
            StartCoroutine(ObstacleMove());
        }else
        {
            boxSpeed = 0f;
        }
        
        
    }

    IEnumerator ObstacleMove(){
        yield return new WaitForSeconds(0.9f);
        transform.Translate(Vector3.left * Time.deltaTime * boxSpeed);
    }
}
