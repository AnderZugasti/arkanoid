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
    private int marca2 = 700;
    public GameObject bola;
    public Vector2 posicionInicial;
    //private Rigidbody2D rb;
    private GameObject lvl2;
    int cont = 0;


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
        lvlUp.text = "Nivel 1 ";
        lvl2 = GameObject.Find("GameObject");

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
            
            if (Score == marca1 && cont ==0)
        {
            lvlUp.text = "Nivel 2";
            cont = 1;
            lvl2.GetComponent<creadorLadrillos>().generarLadrillos(5,15,0.7f,0.6f);
        }
        if (Score == marca2 && cont == 1)
        {
            lvlUp.text = "Nivel 3";
            cont = 2;
            lvl2.GetComponent<creadorLadrillos>().generarLadrillos(7, 15, 0.7f, 0.6f);
        }


    }
    
}
