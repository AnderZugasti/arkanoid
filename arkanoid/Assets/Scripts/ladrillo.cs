using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class ladrillo : MonoBehaviour
{
    public GameObject bola;
    public GameObject puntoscant;
    public GameObject SonidoRoto;
    private GameObject jugador;
    
    // Start is called before the first frame update
    void Start()
    {
        jugador = GameObject.Find("jugador");  
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "bola")
        {
            jugador.GetComponent<jugador>().Score += 100;
            puntoscant.GetComponent<puntuacionFinal>().puntos += 100;
            Destroy(gameObject);
            Instantiate(SonidoRoto);


        }
    }
}
