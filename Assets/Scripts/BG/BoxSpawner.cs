using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    
    public GameObject[] box;

    public  float timer;
    
    public float boxPos;

    [HideInInspector]
    public bool canSpawn;
    void Start()
    {
        
    }

    
    void Update()
    {
        if(canSpawn && PlayAnimation.instance.playerDied == false){
            if(timer <= 0){
            Spawner();
             }
            timer -= Time.deltaTime;
         }
    }

    void Spawner(){
        int index = Random.Range(0, box.Length);
        Instantiate(box[index], new Vector3(boxPos,0,0), Quaternion.Euler(0,0,0));
        timer = 5f;
    }
}
