using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuboEnemigo : MonoBehaviour
{
    GameObject jugador;

    // Start is called before the first frame update
    void Start()
    {

        // PROBLEMA:
        // obtener dinámicamente una referencia a un objeto en escena

        // la fácil:
        jugador = GameObject.Find("Jugador");
        // si lo usan usenlo en START!           
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
