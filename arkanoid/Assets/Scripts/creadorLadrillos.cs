using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creadorLadrillos : MonoBehaviour
{
    // Start is called before the first frame update
    // Publicamos la variable para conectarla desde el editor
    public Rigidbody2D prefabladrillo;
    // Referencia para guardar una matriz de objetos
    private Rigidbody2D[,] ladrillos;

    private const int FILAS = 6;
    private const int COLUMNAS = 15;

    // Enumeración para expresar el sentido del movimiento
    private enum direccion { IZQ, DER };

    

    // Límites de la pantalla
    private float limiteIzq;
    private float limiteDer;

    void Start()
    {
        // Rejilla de 4x7 aliens
        generarLadrillos(FILAS, COLUMNAS, 0.7f, 0.6f);

        // Calculamos la anchura visible de la cámara en pantalla
        float distanciaHorizontal = Camera.main.orthographicSize * Screen.width / Screen.height;

        // Calculamos el límite izquierdo y el derecho de la pantalla (añadimos una unidad a cada lado como margen)
        limiteIzq = -1.0f * distanciaHorizontal + 5;
        limiteDer = 1.0f * distanciaHorizontal - 5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void generarLadrillos(int filas, int columnas, float espacioH, float espacioV, float escala = 1.0f)
    {
        /* Creamos una rejilla de aliens a partir del punto de origen
		 * 
		 * Ejemplo (2,5):
		 *   A A A A A
		 *   A A O A A
		 */

        // Calculamos el punto de origen de la rejilla
        Vector2 origen = new Vector2(transform.position.x - (columnas) * espacioH , transform.position.y);

        // Instanciamos el array de referencias
        ladrillos = new Rigidbody2D[filas, columnas];

        // Fabricamos un alien en cada posición del array
        for (int i = 0; i < filas; i++)
        {
            for (int j = 0; j < columnas; j++)
            {

                // Posición de cada alien
                Vector2 posicion = new Vector2(origen.x + (espacioH * j), origen.y + (espacioV * i));

                // Instanciamos el objeto partiendo del prefab
                Rigidbody2D ladrillo = (Rigidbody2D)Instantiate(prefabladrillo, posicion, transform.rotation);

                // Guardamos el alien en el array
                ladrillos[i, j] = ladrillo;

                // Escala opcional, por defecto 1.0f (sin escala)
                // Nota: El prefab original ya está escalado a 0.2f
                ladrillo.transform.localScale = new Vector2(1.0f * escala, 1.0f * escala);
            }
        }

    }
}
