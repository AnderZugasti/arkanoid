using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class suelo : MonoBehaviour
{
    public Vector2 posicionInicial;
    public GameObject bola;
    void Start()
    {
        posicionInicial = bola.transform.position;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "bola")
        {
            bola.transform.position = posicionInicial;
            bola.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
