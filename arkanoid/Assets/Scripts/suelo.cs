using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class suelo : MonoBehaviour
{
    public Vector2 posicionInicial;
    private float fuerza = 0.5f;
    public GameObject bola;
    public Rigidbody2D b;
    void Start()
    {
        posicionInicial = bola.transform.position;
    }
    void OnCollisionEnter2D(Collision2D other)
    {
       if (other.gameObject.tag == "bola")
        {
            bola.transform.position = posicionInicial;
            bola.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            b.AddForce(Vector2.up * fuerza, ForceMode2D.Impulse);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
