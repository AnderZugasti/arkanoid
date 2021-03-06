﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class suelo : MonoBehaviour
{
    public Vector2 posicionInicial;
    private float fuerza = 0.5f;
    public GameObject bola;
    public GameObject vida1;
    public GameObject vida2;
    public GameObject vida3;
    public Rigidbody2D b;
    private int vidas = 3;
    private Text gameOvertxt;
    public GameObject over;
    public GameObject SonidoCaida;
    public GameObject SonidoFinal;
    public GameObject fin;
    
   
    void Start()
    {
        posicionInicial = bola.transform.position;
        gameOvertxt = over.GetComponent<Text>();
        posicionInicial = bola.transform.position;
        fin.SetActive(false);

    }
    void OnCollisionEnter2D(Collision2D other)
    {
       if (other.gameObject.tag == "bola")
        {
            bola.transform.position = posicionInicial;
            bola.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            b.AddForce(Vector2.up * fuerza, ForceMode2D.Impulse);
            
            if (vidas == 3)
            {
                Destroy(vida1);
                vidas = 2;
                Instantiate(SonidoCaida);
            }
            else if(vidas == 2)
            {
                Destroy(vida2);
                vidas = 1;
                Instantiate(SonidoCaida);
            }
            else if(vidas == 1)
            {
                Destroy(vida3);
                vidas = 0;
                Instantiate(SonidoFinal);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (vidas == 0)
        {
            gameOvertxt.text = "Game\nOver";
            bola.transform.position = posicionInicial;
            fin.SetActive(true);
        }
    }
}
