using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StatsMenu : MonoBehaviour
{
    public TMP_Text total_countText;
    public TMP_Text HighScoreText;
   private int HighScore = GlobalController.global.globalVariables.currentHigh;
   private int total_count = GlobalController.global.globalVariables.total;



    public void returnToMainMenu(){
        SceneManager.LoadScene("MainMenu");
    }

    private void Start()
    {
        // Inicializar los puntajes
        showScores();

    }

    private void showScores() {
        HighScoreText.text = HighScore.ToString();
        total_countText.text = total_count.ToString();
    }

    void Update()
    {
        
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameController.controller.ReturnMenu();
        }
    }
}
