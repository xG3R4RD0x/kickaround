using UnityEngine;
using System.Collections;

public class TapToStartScript : MonoBehaviour {
 
    void Update()
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Ended && touch.tapCount == 1)
            {
                GameController.controller.StartGame();
 
                this.enabled = false;
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            GameController.controller.StartGame();
            this.enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameController.controller.ReturnMenu();
        }
    }
}
