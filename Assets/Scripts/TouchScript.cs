using UnityEngine;
using System.Collections;

public class TouchScript : MonoBehaviour {    

    
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
                        Debug.Log("RodillaColliderAnimaiton");
                            // Activa la animación aquí
                            // Puedes utilizar el Animator o Animation según tus preferencias anteriores
                        }
                    }
                }
            }
        }

    }

