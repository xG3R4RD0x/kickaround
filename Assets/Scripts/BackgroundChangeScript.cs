using UnityEngine;
using System.Collections;

public class BackgroundChangeScript : MonoBehaviour {

    public SpriteRenderer fondo;

    int n = 0;

    public Sprite[] fondos; 

    public void ChangeBackground()
    {
        n++;
        if (n < fondos.Length)
        {
            fondo.sprite = fondos[n];
        }
        else {
            n = 0;
        }
    } 
	
}
