using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{

    public void StartGame()
    {
        SceneManager.LoadScene("GameStart");
    }

    public void QuitGame() {

        Debug.Log("QuitGame");
        Application.Quit();
    }

    public void ShowHighScores()
    {
        SceneManager.LoadScene("HighScoreMenu");
    }

}
