using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePlayManager : MonoBehaviour

{

    private Text scoreText, highScoreText, liveText ;

    private Text gameOverScoreText;


    public static GamePlayManager instance;

    private int lives, score;
    [SerializeField]
    private GameObject gameOver;


    // Start is called before the first frame update
    void Awake()
    {
        MakeInstance();
        scoreText = GameObject.Find("Score").GetComponent<Text>();
        highScoreText = GameObject.Find("HighScore").GetComponent<Text>();
        liveText = GameObject.Find("Lifes").GetComponent<Text>();
        gameOverScoreText = GameObject.Find("ScoreText").GetComponent<Text>();

        lives = 3;
        score = 0;

        gameOver.SetActive(false);

    }
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoadedEvent;
    }
    void onDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoadedEvent;
    }

    void MakeInstance()
    {
        if(instance == null)
        {
            instance = this; 
        }
    }

    void OnSceneLoadedEvent(Scene scene, LoadSceneMode mode)
    {
        if(scene.name == "MainScene")
        {
            if (GameManager.Instance.gameStartedFromMainMenu)
            {
                GameManager.Instance.gameStartedFromMainMenu = false;
                lives = 3;
            } else if (GameManager.Instance.gameRestarted)
            {
                GameManager.Instance.gameRestarted = false;
                lives = GameManager.Instance.lives;
                score = GameManager.Instance.score;
            }
            liveText.text = "Tries: " + lives.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if(PlayAnimation.instance.playerDied == false)
        //{
        //    IncrementScore();
        //} else if(GameManager.Instance.score > GameManager.Instance.highscore && PlayAnimation.instance.playerDied == true)
        //{
        //    GameManager.Instance.highscore = GameManager.Instance.score;
        //    highScoreText.text = "Highcore: " + GameManager.Instance.highscore.ToString();
        //}
        
    }

    public void IncrementScore()
    {
        score++;

        scoreText.text = "Score: " + GameManager.Instance.score.ToString();
    }

    public void PlayerTakeDamage()
    {
        lives--;

        if (lives > 0)
        {
            StartCoroutine(GameReload("MainScene"));
            liveText.text = "Tries: " + lives.ToString();
        } else
        {
            StartCoroutine(WaitBeforeReplay());
        }


    }

    IEnumerator GameReload(string sceneName)
    {
        GameManager.Instance.lives = lives;
        GameManager.Instance.gameRestarted = true;
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(sceneName);
    }


    IEnumerator WaitBeforeReplay()
    {
        yield return new WaitForSeconds(2f);
        liveText.text = "Tries: " + 0;
        gameOver.SetActive(true);
            }

    public void PlayAgain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainScene");
    }


}
