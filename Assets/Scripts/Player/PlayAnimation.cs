using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimation : MonoBehaviour
{
    
    private Animator myAnim;
    private Rigidbody2D myRigidbody;

    [HideInInspector]

    public bool gameStarted;

    private ScrollBg bgScroller;

    private ScrollFloor groundScroller;

    private BoxSpawner boxSpawner;

    public LayerMask groundLayer;

    public float jump = 10f;

    public Transform groundCheckPos;
    public float radius = 0.5f;
    public bool isGrounded;



    [SerializeField]
    private BoxCollider2D boxCollider;
    [SerializeField]
    private PolygonCollider2D polygonCollider;

    public GameObject playerDiedEffect;
    [HideInInspector]
    public bool playerDied;

    public static PlayAnimation instance;

    void Awake(){
        myAnim = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        bgScroller = GameObject.Find("Background").GetComponent<ScrollBg>();
        groundScroller = GameObject.Find("Floor").GetComponent<ScrollFloor>();
        boxSpawner = GameObject.Find("BoxSpawner").GetComponent<BoxSpawner>();

        Physics2D.IgnoreCollision(boxCollider, polygonCollider, true);
    }
    void Start()
    {
        MakeInstance();
        StartCoroutine(StartGame());
        
        
    }

    void MakeInstance()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    void PlayerGrounded(){
        isGrounded = Physics2D.OverlapCircle(groundCheckPos.position, radius, groundLayer);
        Debug.Log(isGrounded);
    }

    
    void FixedUpdate()
    {
        if(gameStarted && playerDied == false){
            myAnim.SetFloat("walk", 1f);
            PlayerGrounded();
        }
        PlayerJump();
    }

    void PlayerJump(){
        if(Input.GetKeyDown(KeyCode.Space)){
           if(gameStarted && isGrounded){
               myAnim.SetBool("jump", true);
               myRigidbody.AddForce(new Vector3(0, jump, 0));
           } 
        } else {
            myAnim.SetBool("jump", false);
        }
    }

    IEnumerator StartGame(){
        yield return new WaitForSeconds(3f);
        gameStarted = true;
        bgScroller.canScroll = true;
        groundScroller.groundScroll = true;
        boxSpawner.canSpawn = true;
    }

    void OnCollisionEnter2D(Collision2D target)
    {
        if(target.gameObject.tag == "Box")
        {
            DiedThroughCollision();

        }
        if(target.gameObject.tag == "EnemyBullet")
        {
            GamePlayManager.instance.PlayerTakeDamage();
            Vector3 effectPosition = transform.position;
            Instantiate(playerDiedEffect, effectPosition, Quaternion.identity);
            Destroy(gameObject);
            Destroy(target.gameObject);
            playerDied = true;
        }
    }

    void DiedThroughCollision()
    {
        GamePlayManager.instance.PlayerTakeDamage();
        Vector3 effectPosition = transform.position;
        Instantiate(playerDiedEffect, effectPosition, Quaternion.identity);
        Destroy(gameObject);
        playerDied = true;
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Box")
        {
            GamePlayManager.instance.PlayerTakeDamage();
            Vector3 effectPosition = transform.position;
            Instantiate(playerDiedEffect, effectPosition, Quaternion.identity);
            Destroy(gameObject);
            Destroy(col.gameObject);
            playerDied = true;
        }
    }


}
