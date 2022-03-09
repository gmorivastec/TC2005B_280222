using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCasting : MonoBehaviour
{

    [SerializeField]
    private Camera camara;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // ray casting
        // emisión de rayos 
        // verificación de colisión entre un "rayo" y un objeto en escena (collider)
        // requisito para ser detectable por rayito:
        // 1. tener collider
        // 2. no pertener a la layer ignoreRaycast

        // 2 casos comunes - 
        // 1. desde el puntero del mouse
        // 2. entre objetos en el mundo


        if(Input.GetMouseButtonDown(0)){

            // DESDE EL PUNTERO DEL MOUSE
            // hacer un rayito
            //Ray rayito = Camera.main.ScreenPointToRay(Input.mousePosition);
            Ray rayito = camara.ScreenPointToRay(Input.mousePosition);

            // out parameters 
            // hay manera de mandar un parámetro para que sea "rellenado" en el método

            RaycastHit hit;

            if(Physics.Raycast(rayito, out hit)){

                //print("HUBO COLISIÓN! " + hit.transform.name + " " + hit.point);
            } else {

                //print("NO HUBO COLISIÓN :( ");
            }
        }

        RaycastHit hit2;

        if(Physics.Raycast(transform.position, transform.forward, out hit2)){

            print("ESTOY VIENDO A: " + hit2.transform.name);
        } else {

            print("NO VEO A NADIE :(");
        }
    }

    // métodos de conveniencia para interacción con mouse
    // TODOS sujetos a las reglas de raycast
    void OnMouseEnter(){

        // el cuadro en el que el puntero empieza a estar "sobre" el objeto
        print("ENTER");
    }
    
    void OnMouseOver(){

        // cuadros donde el mouse esté sobrepuesto al objeto y ya estaba así 
        // en cuadro anterior
        // print("OVER");
    }

    void OnMouseExit(){

        // cuadro en donde el puntero deja de estar sobre el objeto
        // y en el anterior sí estaba
        print("EXIT");
    }
    
    
    

    void OnMouseDown(){
        // detonado cuando damos click sobre el objeto
        // sólo el cuadro donde hubo click
        print("DOWN");
    }

    void OnMouseDrag(){
        // detonado todos los frames en donde dimos click originalmente al objeto
        // y posteriormente desplazamos el puntero
        print("DRAG");
    }

    void OnMouseUp(){
        // detonado al soltar el click después de un down exitoso
        print("UP");
    }

    void OnMouseUpAsButton(){
        // casi como up PERO tienes que soltar SOBRE el objeto
        print("UP AS BUTTON");
    }

    void OnDrawGizmos(){

        // GIZMOS
        // elementos gráficos visibles sólo en editor
        // cuyo fin es informar a los devs 

        // para dibujar primero especificamos color
        Gizmos.color = Color.red;

        // y luego dibujamos!
        //Gizmos.DrawWireSphere(transform.position, 3);

        //Gizmos.DrawRay(transform.position, transform.forward);
        Gizmos.DrawLine(
            transform.position, 
            transform.position + transform.forward * 10
            );

    }

    void OnDrawGizmosSelected(){

        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position, new Vector3(3, 3, 3));
    }
}
