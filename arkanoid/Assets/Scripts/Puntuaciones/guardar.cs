using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class guardar : MonoBehaviour
{
    public string nick;
    public GameObject inputField;
    public GameObject rank;
    
    public void recibirNombre()
    {

        nick = inputField.GetComponent<Text>().text;
        rank.GetComponent<Ranking>().guardarNombre();

    }
    
}
