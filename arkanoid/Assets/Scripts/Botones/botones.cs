using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class botones : MonoBehaviour
{
    public GameObject puntos;
    
    // Start is called before the first frame update
    public void empezar()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void reiniciar()
    {
        SceneManager.LoadScene("SampleScene");
        puntos.GetComponent<puntuacionFinal>().puntos = 0;
    }
    public void puntuaciones()
    {
        SceneManager.LoadScene("Puntuacion");
    }
    
}
