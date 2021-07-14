using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   public static GameManager Instance { get; private set; }


    [HideInInspector]
    public int score, highscore, lives, points;

    [HideInInspector]
    public bool gameStartedFromMainMenu, gameRestarted;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }else
        {
            Destroy(gameObject);
        }
    }

}
