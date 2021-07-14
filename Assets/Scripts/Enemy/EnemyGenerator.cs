using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField]
    private Transform[] enemy;

    [SerializeField]
    private Transform enemyParent;

    [SerializeField]
    private float minY, maxY, posX;

    public float timer = 3f;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(PlayAnimation.instance.playerDied == false)
        {
            if (timer <= 0)
            {
                SpawnEnemy(true);
            }
            timer -= Time.deltaTime;
        }
    }

    void SpawnEnemy(bool started)
    {
        if (started)
        {
            Vector3 enemyPosition = new Vector3(posX, Random.Range(minY, maxY), 0);
            int index = Random.Range(0, enemy.Length);
            Transform createEnemy = (Transform)Instantiate(enemy[index], enemyPosition, Quaternion.Euler(0, 0, 0));
            createEnemy.parent = enemyParent;
            timer = 5f;
        }
    }
}
