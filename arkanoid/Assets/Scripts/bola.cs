using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bola : MonoBehaviour
{
    public float velocidad = 40f;
    private float fuerza = 0.5f;
    public Rigidbody2D b;
    // Start is called before the first frame update
    void Start()
    {
        b.AddForce(Vector2.up * fuerza, ForceMode2D.Impulse);
    }

    // Update is called once per frame
   
    
}
