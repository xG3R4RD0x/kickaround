using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameController : MonoBehaviour
{

    //Variables
    public static GameController controller;

    public int points;


    public GameObject gameOverPanel;



    TouchScript touch;


    int n = 5;


   
    public AudioClip whistle;

    public float volume = 1;


    bool ball = false;
  

    public TMP_Text finalScore;
    public TMP_Text HighScore;
    public int nLeg;
    public int nFoot;
    public float adding;

    public Ballscript BallController;


    void Awake()
    {
        controller = this;
        touch = gameObject.GetComponent<TouchScript>();
        
       

 
    }

    public void StartGame()
    {
        
        Ballscript.ball.GolpearBalon(40F);
        Ballscript.ball.gameObject.GetComponent<Rigidbody2D>().gravityScale = 120;
        nLeg = 0;
        nFoot = 0;
        AudioSource.PlayClipAtPoint(whistle, transform.position, volume);
    }
   
    public void CalcWait(bool foot)
    {
        if (foot)
        {
            nLeg--;
            nFoot++;
            if (nLeg < 0 || nFoot > 2)
            {
                nLeg = 0;
            }
        }
        else
        {
            nLeg++;
            nFoot--;
            if (nFoot < 0 || nLeg > 2)
            {
                nFoot = 0;
            }
        }
    }



    public void ReturnMenu()
    {
    //    AdsCallScript.adsCall.bannerView.Destroy();
        Application.LoadLevel("MainMenu");
    }

   

    // Update is called once per frame
    void Update()
    {
        
    }
}
