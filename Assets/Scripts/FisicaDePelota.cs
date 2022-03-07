using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// esta es la manera de informar a Unity que es REQUERIDO
// este otro componente. Si no existe no va a servir.
[RequireComponent(typeof(Rigidbody))]
public class FisicaDePelota : MonoBehaviour
{
    // vamos a obtenerlo internamente PERO
    // les pongo esto para el futuro
    [SerializeField]
    private float fuerzaDeDisparo = 10;
    private Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        // COSA NUEVA
        // obtener referencia a un componente en el mismo gameobject
        // GetComponent en start o awake
        rb = GetComponent<Rigidbody>();
        print(transform.up);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            // nota 1 de addforce: el vector de fuerza está en 
            // espacio de mundo

            // 3 vectores que nos sirven para tomar en cuenta orientación local
            // en espacio global
            // * transform.up
            // * transform.right
            // * transform.forward

            // vector está normalizado (tamaño 1)
            // unit vector - vector unitario
            // sirve para expresar dirección y sentido

            rb.AddForce(transform.up * fuerzaDeDisparo, ForceMode.Impulse);
        }
    }
}
