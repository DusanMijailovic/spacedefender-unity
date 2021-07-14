using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    private Animator myAnimator;
    private Rigidbody2D myRigidBody;

    public GameObject playerBullet;
    public float bulletForce = 30f;
    public float timeBetweenShots = 0.3333f;
    private float shotTimeStamp;
    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        myRigidBody = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayAnimation.instance.gameStarted && PlayAnimation.instance.playerDied == false)
        {
            if (Time.time >= shotTimeStamp && Input.GetKeyDown(KeyCode.E)) //puca na E
            {
                myAnimator.SetBool("shoot", true);
                StartCoroutine(PlayerShootBullet(-0.1f));
                shotTimeStamp = Time.time + timeBetweenShots;
            }

            if (Input.GetKeyUp(KeyCode.E))  // prestaje da puca 
            {
                myAnimator.SetBool("shoot", false);
            }
        }
    }

    IEnumerator PlayerShootBullet(float startTime) //kako bi ispalio metak isto vreme kad i animacija
    {
        yield return new WaitForSeconds(startTime);
        Vector3 offset = new Vector3(transform.position.x, transform.position.y, 0f);
        GameObject newBullet = Instantiate(playerBullet, offset, Quaternion.Euler(0f, 0f, 0f)) as GameObject;
        newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletForce, 0f);
    }
}
