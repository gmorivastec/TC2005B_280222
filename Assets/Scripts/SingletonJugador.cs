using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonJugador : MonoBehaviour
{
    
    // properties
    public static SingletonJugador Instance {
        get; // si no pongo modificador se hereda de afuera
        private set; // si pongo modificador Y es más restrictivo se sobreescribe
    }

    // Start is called before the first frame update
    void Start()
    {
        // verificar si ya hay una instancia
        if(Instance != null){

            // si hubiera pues destruimos este objeto
            Destroy(gameObject);
        } else {

            Instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
