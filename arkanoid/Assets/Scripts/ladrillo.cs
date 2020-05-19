using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static jugador;


public class ladrillo : MonoBehaviour
{
    public GameObject bola;
    private GameObject jugador;
    public GameObject SonidoRoto;
    
    
    // Start is called before the first frame update
    void Start()
    {
        jugador =GameObject.Find("jugador");
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
            Destroy(gameObject);
            Instantiate(SonidoRoto);


        }
    }
}
