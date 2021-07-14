using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public GameObject enemyBullet;
    public float timer = 3f;
    public float enemyBulletForce = 30f;
    private Animator myAnimator;
    [HideInInspector]
    public bool canFly; 

    public GameObject playerEffect;

    void Start()
    {
        myAnimator = GetComponent<Animator>();
        canFly = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canFly)
        {
            myAnimator.SetBool("flying", true);
        }
        if(timer <= 0)
        {
            EnemyShoot();
            timer = 3f;
        }
        timer -= Time.deltaTime;

        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            Instantiate(playerEffect, PlayAnimation.instance.transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(col.gameObject);
            PlayAnimation.instance.playerDied = true;
        }

        if(col.tag == "PlayerBullet")
        {
            GameObject effect = Instantiate(playerEffect, transform.position, Quaternion.identity) as GameObject;
            Destroy(gameObject);
            Destroy(col.gameObject);
            Destroy(effect, 0.7f);
        }
    }

    void EnemyShoot()
    {
        if(PlayAnimation.instance.playerDied == false)
        {
            Vector3 offset = new Vector3(transform.position.x, transform.position.y, 0f);
            GameObject newBullet = Instantiate(enemyBullet, offset, Quaternion.Euler(0f,0f,0f)) as GameObject;
            newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(-enemyBulletForce, 0f);
        }
    }
}
