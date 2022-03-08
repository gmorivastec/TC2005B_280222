using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corrutinas : MonoBehaviour
{
    private IEnumerator ejemplo2a;
    private Coroutine ejemplo2b;

    // Start is called before the first frame update
    void Start()
    {
        // las corrutinas pertenecen a un componente
        IEnumerator corrutinita = Ejemplo1(); 
        StartCoroutine(corrutinita);
        
        ejemplo2a = Ejemplo2();
        StartCoroutine(ejemplo2a);
        // OJO - se pueden iniciar varias corrutinas
        // utilizando el mismo método
        StartCoroutine(Ejemplo2());
    }

    // método se adhiere al loop principal
    // dijimos que aquí van 2 cosas:
    // 1. entrada 
    // 2. movimiento
    void Update()
    {
        
        // cómo detener corrutinas 
        // 2 cosas 
        // 1. detener todas 
        // 2. detener alguna en particular

        if(Input.GetKeyDown(KeyCode.A)) {

            StopAllCoroutines();
        }

        if(Input.GetKeyDown(KeyCode.S)){

            // detener corrutina en particular
            // REQUISITO: referencia a la corrutina
            StopCoroutine(ejemplo2a);
        }
    }

    // qué pasa con las cosas que requieren suceder con cierta frecuencia
    // que NO son ni entrada ni movimiento?!

    // CORRUTINA
    // pseudohilo
    // pseudoconcurrencia
    IEnumerator Ejemplo1() {

        // ceder el paso
        yield return new WaitForSeconds(2);

        // cuando hacemos esto de arriba
        // NO se termina la ejecución del método
        print("ESTO SE IMPRIMIO DESPUÉS DE 2 SEGUNDOS");
    }

    // otro ejemplo:
    // loop con frecuencia distinta a update
    IEnumerator Ejemplo2() {

        while(true) {
            print("HOLA!");
            yield return new WaitForSeconds(1);            
        }
    }
}
