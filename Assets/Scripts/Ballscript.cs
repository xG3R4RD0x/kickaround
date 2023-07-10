using UnityEngine;
using System.Collections;

public class Ballscript : MonoBehaviour
{

    public static Ballscript ball;

    public float ballImpulse = 15;

    int finalRotation = 10;
    public float rotateTime = 0.1F;
    public float hitPowerKnee;
    public float hitPowerFoot;
    public AudioClip kick;
    public float volume = 1;
    public Score Score;

    
    void Awake()
    {
        ball = this;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("rodilla_collider_tag"))
        {
            Debug.Log("AddPoint");
            // Realiza las acciones necesarias cuando la pelota es golpeada
            Score.AddPoint();
           
            GolpearBalon(hitPowerKnee);
            // Puedes aplicar una fuerza o cambiar la dirección de movimiento de la pelota
            
        }
        if (collision.gameObject.CompareTag("pie_collider_tag"))
        {
            Debug.Log("AddPoint");
            // Realiza las acciones necesarias cuando la pelota es golpeada
            Score.AddPoint();
         
            GolpearBalon(hitPowerFoot);
            // Puedes aplicar una fuerza o cambiar la dirección de movimiento de la pelota
            GameController.controller.CalcWait(true);
        }

        if (collision.gameObject.CompareTag("ground_collider_tag"))
        {
            Debug.Log("GroundColliderTag");
            Score.showGameOver();


        }
    }

    public void GolpearBalon(float power)
    {
        Rigidbody2D balon = gameObject.GetComponent<Rigidbody2D>();
        balon.velocity = (new Vector2(0, ballImpulse * power));
        AudioSource.PlayClipAtPoint(kick, transform.position, volume);
    }

    IEnumerator RotarBalon()
    {
        for (int i = 0; i < finalRotation; i++)
        {
            transform.Rotate(Vector3.forward * -2);
            yield return new WaitForSeconds(rotateTime);
        }

    }
}
