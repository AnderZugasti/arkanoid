using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class jugador : MonoBehaviour
{
    public int Score = 0;
    private Text txtScore;
    private Text lvlUp;
    public float velocidad = 60f;
    public GameObject puntuacion;
    public GameObject lvlup;
    private int marca1 = 100;
    public GameObject bola;
    public Vector2 posicionInicial;
    //private Rigidbody2D rb;



    // Start is called before the first frame update
    void Awake ()
    {
       // rb = GetComponent<Rigidbody2D>();
    }
    
    void Start()
    {
       txtScore = puntuacion.GetComponent<Text>();
       lvlUp = lvlup.GetComponent<Text>();
       posicionInicial = bola.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        float distanciaHorizontal = Camera.main.orthographicSize * Screen.width / Screen.height;
        float limiteIzq = -6.7f;
        float limiteDer = 6.7f;
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
        
            txtScore.text = "Puntuación: " + Score;
            if (Score >= marca1)
        {
            lvlUp.text = "Nivel 1 superado";
            bola.transform.position = posicionInicial;
        }
        
        
        
    }
    
}
