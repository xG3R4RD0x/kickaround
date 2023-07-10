using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RodillaController : MonoBehaviour
{


    public float cooldown = 0.05F;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                Vector2 touchPosition = touch.position;
                Ray ray = Camera.main.ScreenPointToRay(touchPosition);

                // Realiza el raycast y verifica si golpea un objeto deseado
                RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

                if (hit.collider != null)
                {
                    // Verifica si el objeto tocado tiene la capa correcta para activar la animación
                    if (hit.collider.gameObject.layer == LayerMask.NameToLayer("RodillaColliderLayer"))
                    {
                        Debug.Log("rodillaColliderTouch");
                        // Activa la animación aquí
                        // Puedes utilizar el Animator o Animation según tus preferencias anteriores
                    }
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            Debug.Log("flecha arriba");
            GameController.controller.CalcWait(false);
            StartCoroutine(KneeCooldown());
            //GameController.controller.ManageBar();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("flecha abajo");
            GameController.controller.CalcWait(true);
            StartCoroutine(FootCooldown());
            //GameController.controller.ManageBar();
        }
    }

     IEnumerator KneeCooldown()
    {
        Debug.Log("rodillaColliderTouch");
        int nLeg = GameController.controller.nLeg;
        yield return new WaitForSeconds(nLeg * cooldown);
        animator.Play("knee");
    }
     IEnumerator FootCooldown()
    {
        Debug.Log("pieColliderTouch");
        int nFoot = GameController.controller.nFoot;

        yield return new WaitForSeconds(nFoot * cooldown);
        animator.Play("foot");
    }



}
