using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puntuacionFinal : MonoBehaviour
{   
    public int puntos= 0;
   
    public static puntuacionFinal punto;
    void Awake()
    {
        
        if (punto == null)
        {
            punto = this;
            DontDestroyOnLoad(gameObject);
        }
        else 
        {
            Destroy(gameObject);

        }
    }
    void Start()
    {
        puntos = 0;
    }

    // Update is called once per frame
    void Update()
    {
       

    }
    
   
}
