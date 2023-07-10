using UnityEngine;
using TMPro;


public class Score : MonoBehaviour
{
    public TMP_Text scoreText; // Referencia al componente Text para mostrar el puntaje
    public TMP_Text scoreGOText;
    public TMP_Text HighScoreText;

    public GameOverMenu GameOverMenu;
    private int bg_counter = 0;
    private int score = 0; // Puntaje actual
    private int HighScore;
    public BackgroundChangeScript background;
    private void Start()
    {
        // Inicializar el puntaje
        UpdateScoreText();
       
    }

    public void AddPoint()
    {
        // Sumar al puntaje
        score ++;

        // Actualizar el texto del puntaje
        UpdateScoreText();
        updateBgCounter();


    }

    private void UpdateScoreText()
    {
        // Actualizar el texto del puntaje con el valor actual
        scoreText.text = score.ToString();
    }


    public void CheckHighScore() {

        if (score > GlobalController.global.globalVariables.currentHigh)
        {
            GlobalController.global.globalVariables.currentHigh = score;
        }

    }

    public void showGameOver() {

        GameOverMenu.showGOAnimation();
        CheckHighScore();
        update_total_count();
        HighScore = GlobalController.global.globalVariables.currentHigh;
        scoreGOText.text = scoreText.text;
        HighScoreText.text = HighScore.ToString();
    }

    public void update_total_count() {
        GlobalController.global.globalVariables.total += score;

    }


    public int GetScore() {
        return score;
    
    }

    public void updateBgCounter()
    {
        if (bg_counter < 5)
        {
            bg_counter++;

        }
        else {
            background.ChangeBackground();
            bg_counter = 0;
        }

    }

}
