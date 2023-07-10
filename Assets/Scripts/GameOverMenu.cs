using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOverMenu : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
       
    }

    public void StartGame()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void MainMenu()
    {

        SceneManager.LoadScene("MainMenu");

    }
    public void showGOAnimation() {

        animator.Play("showGameOver");
    
    }

}
