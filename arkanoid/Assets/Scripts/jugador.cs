using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jugador : MonoBehaviour
{
    
    public float velocidad = 20f;
    private Rigidbody2D rb;

    

    // Start is called before the first frame update
    void Awake ()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float distanciaHorizontal = Camera.main.orthographicSize * Screen.width / Screen.height;
        float limiteIzq = -1.0f * distanciaHorizontal;
        float limiteDer = 1.0f * distanciaHorizontal;
        if (Input.GetKey(KeyCode.LeftArrow))
        {

            // Nos movemos a la izquierda hasta llegar al límite para entrar por el otro lado
            if (transform.position.x > limiteIzq)
            {
                transform.Translate(Vector2.left * velocidad * Time.deltaTime);
            }
            else
            {
                transform.position = new Vector2(limiteDer, transform.position.y);
            }
        }

        // Tecla: Derecha
        if (Input.GetKey(KeyCode.RightArrow))
        {

            // Nos movemos a la derecha hasta llegar al límite para entrar por el otro lado
            if (transform.position.x < limiteDer)
            {
                transform.Translate(Vector2.right * velocidad * Time.deltaTime);
            }
            else
            {
                transform.position = new Vector2(limiteIzq, transform.position.y);
            }
        }
    }
}
