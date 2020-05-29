using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Firestore;
using Firebase;
using TMPro;
using UnityEngine.UI;
using System.Security.Cryptography.X509Certificates;
using System.Net.NetworkInformation;
using System;

public class Ranking : MonoBehaviour
{
    private FirebaseFirestore db;
    public GameObject marcador;
    private puntuacionFinal jugador;
    private int score;
    public GameObject puntosJugador;
    public TextMeshProUGUI nick;
    List<string> nicks = new List<string>();
    private bool repe = false;
    public GameObject textRepe;
    public GameObject guardar;
    public GameObject inputField;
    // Start is called before the first frame update
    void Start()
    {
        jugador = FindObjectOfType<puntuacionFinal>();
        score = jugador.puntos;
        puntosJugador.GetComponent<TextMeshProUGUI>().text = $" {score} puntos";
        textRepe.SetActive(false);



        db = FirebaseFirestore.GetInstance(FirebaseApp.Create());
        CollectionReference jugadoresRef = db.Collection("jugadores");
        Query query = jugadoresRef.OrderByDescending("puntos").Limit(5);
        ListenerRegistration listener = query.Listen(snapshot =>
        {

            string top5 = "TOP 5 \n\n";
            var cont = 1;
            foreach (DocumentSnapshot documentSnapshot in snapshot.Documents)
            {
                Dictionary<string, object> jugador = documentSnapshot.ToDictionary();
                top5 += $"{cont}-{documentSnapshot.Id}..........{jugador["puntos"]}\n";
                cont += 1;
                nicks.Add(documentSnapshot.Id.ToString());
            }
            marcador.GetComponent<TextMeshProUGUI>().text = top5;
        });

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void guardarNombre()
    {
        repe = false;
        nick = GameObject.Find("inputNick").GetComponent<TextMeshProUGUI>();

        Debug.Log(nick);

        foreach (var nic in nicks)
        {
            Debug.Log("entra en el for each");
            if (nick.text.Equals(nic))
            {
                repe = true;
            }
           
        }
        if (repe)
        {
            textRepe.SetActive(true);
        }
        else
        {
            Debug.Log("entrapara meter datos");
            DocumentReference docref = db.Collection("jugadores").Document(nick.text);
            var datos = new Dictionary<string, object> {
                        {"puntos", score }
                    };

            docref.SetAsync(datos);
            guardar.SetActive(false);
            textRepe.SetActive(false);

        }



    }
}
