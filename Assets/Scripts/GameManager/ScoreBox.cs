using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBox : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D target)
    {
        if(target.gameObject.tag == "Player" && PlayAnimation.instance.playerDied == false)
        {
            GamePlayManager.instance.IncrementScore();
        }
    }


}
