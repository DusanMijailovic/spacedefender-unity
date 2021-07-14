using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
  void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameManager.Instance.gameStartedFromMainMenu = true;
            SceneManager.LoadScene("MainScene");
        }
    }

}
