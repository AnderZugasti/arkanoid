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
    public GameObject nick;
    List<string> nicks = new List<string>();
    private bool repe = false;
    public GameObject textRepe;
    public GameObject  guardar;
    // Start is called before the first frame update
    void Start()
    {
        jugador = FindObjectOfType<puntuacionFinal>();
        score = jugador.puntos;
        puntosJugador.GetComponent<TextMeshProUGUI>().text =$" {score}";
        textRepe.SetActive(false);
            
        

        db = FirebaseFirestore.GetInstance(FirebaseApp.Create());
        CollectionReference jugadoresRef = db.Collection("jugadores");
        Query query = jugadoresRef.OrderByDescending("puntos");
        ListenerRegistration listener = query.Listen(snapshot =>
        {
            string top5 = "TOP 5 \n\n";
            var cont = 1;
            foreach (DocumentSnapshot documentSnapshot in snapshot.Documents)
            {
                Dictionary<string, object> jugador = documentSnapshot.ToDictionary();
                top5 += $"{cont}-{documentSnapshot.Id}..........{jugador["puntos"]}\n";
                cont += 1;
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
       
        var nombre = nick.GetComponent<guardar>().nick;
        if (!nombre.Equals(""))
        {
            foreach (var nic in nicks)
            {
                if (nombre.Equals(nic))
                {
                    repe = true;
                }
                else
                {
                    DocumentReference docref = db.Collection("jugadores").Document();
                    var datos = new Dictionary<string, int>();
                    datos.Add(nombre, score);
                    docref.SetAsync(datos);
                    guardar.SetActive(false);

                }


            }
            if (repe)
            {
                textRepe.SetActive(true);
            }


        }
    }
}
