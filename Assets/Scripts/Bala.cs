using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // NO es obligatorio destrucción por tiempo
        // PERO es indispensable alguna estrategia de destrucción 
        // para objetos que se vayan a instanciar dinámicamente
        Destroy(gameObject, 3);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 5 * Time.deltaTime, 0, Space.World);
    }
}
