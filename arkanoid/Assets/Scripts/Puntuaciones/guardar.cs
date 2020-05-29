using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class guardar : MonoBehaviour
{
    
   
    public GameObject rank;
    
    public void recibirNombre()
    {

        
        rank.GetComponent<Ranking>().guardarNombre();

    }
    
}
