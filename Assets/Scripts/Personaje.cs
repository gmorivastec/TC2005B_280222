using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Personaje : MonoBehaviour
{

    // atributos públicos que sean primitivos o serializables 
    // se pueden exponer al editor
    // primitivo - tipo de dato básico que se traduce directamente a bytes en memoria
    // serializable - objeto representable en texto y viceversa

    // ¿por qué exponer valores hacia el editor?
    // - facilidad de cambio de comportamiento sin meterse al código
    public float velocidad = 5;
    public float dummy;

    // cuando expongamos un objeto
    // que esperemos nos manden del editor 
    // hay posibilidad que sea nulo
    public Text textito;

    // vamos a empezar a clonar (instanciar) objetos
    // es clon y NECESITAMOS un original
    public GameObject original;
    public Transform referenciaDePosicion;

    // CICLO DE VIDA! 
    // - existen métodos que se ejecutan en momentos específicos 
    // en la vida de un script

    // idioms - estándares de escritura en lenguaje
    
    // se ejecuta al inicio de la vida del script
    // 1 sola vez
    void Awake(){
        print("AWAKE");
    }

    // Se ejecuta 1 vez después que corren TODOS los Awakes pendientes
    void Start(){

        Debug.Log("START");

        textito.fontSize = 18;
        textito.fontStyle = FontStyle.Italic;
        textito.text = "HOLA A TODOS";
    }

    // loop del engine
    // corre cada loop (procesar lógica, desplegar gráficos)
    // depende de la combinanción hardware + software es la frecuencia de ejecución
    // realtime - al menos 30 fps (frame per seconds, cuadros por segundo)
    // deseable - 60 fps + 
    void Update(){
        //print("UPDATE");
        
        // QUÉ QUEREMOS AQUÍ:
        // - manejo de entrada de jugador: que el juego se sienta responsivo
        // - operaciones espaciales (traslación, escala, etc): movimiento suave


        // utilizar un objeto que ya existe 
        // transform - referencia al componente en el mismo GO
        // Transform - nombre de la clase que define al componente

        // IMPORTANTE RECORDAR - MANEJO DE CAMBIOS DE FRECUENCIA
        // Time.deltaTime - cantidad de tiempo en segundos que transcurrió
        // entre el cuadro anterior y el actual
        // transform.Translate(1 * Time.deltaTime, 0, 0);

        // manejo de entrada 
        // polling vs events

        // polling directo a dispositivo

        if(Input.GetKeyDown(KeyCode.Space)){

            // detona cuando
            // cuadro anterior está libre
            // cuadro actual está presionado
            print("KEY DOWN");

            // para clonar utilizamos el método instantiate
            //Instantiate(original);
            Instantiate(
                original, 
                referenciaDePosicion.position, 
                referenciaDePosicion.rotation
            );
        }

        if(Input.GetKey(KeyCode.Space)){

            // detona cuando
            // cuadro anterior estaba presionado
            // cuadro actual está presionado
            print("KEY");
        }

        if(Input.GetKeyUp(KeyCode.Space)){

            // detona cuando
            // cuando anterio estaba presionado
            // cuadro actual está libre
            print("UP");
        }

        if(Input.GetMouseButtonDown(0)){
            print(Input.mousePosition);
        }


        // limitante del sistema anterior
        // lógica está asociada directamente con un elemento físico

        // podemos usar ejes (axes)

        // ejes sirven para abstraer input
        // valores en rango [-1, 1]
        //float horizontal = Input.GetAxisRaw("Horizontal");
        float horizontal = Input.GetAxis("Horizontal");        
        float vertical = Input.GetAxis("Vertical");

        //print(horizontal);
        transform.Translate(
            velocidad * horizontal * Time.deltaTime, 
            velocidad * vertical * Time.deltaTime, 
            0,
            Space.World
        );
    }

    // late update - corre cada frame
    // después de TODOS los updates
    void LateUpdate(){
        //print("LATE UPDATE");
    }

    // fixed - "arreglado" 
    // fixed - más bien fijo
    void FixedUpdate(){
        //print("FIXED UPDATE");
    }

    // DETECCIÓN DE COLISIONES (con motor de física)
    // 1 - todos los involucrados tienen componente collider
    // 2 - al menos 1 tiene rigidbody (y se debe mover)

    // 3 momentos en la vida de la colisión
    void OnCollisionEnter(Collision c){
        // Collision tiene info detallada de la colisión
        print("ENTER " + c.contacts[0]);
        print(c.transform.name);
    }
    void OnCollisionStay(Collision c){
        print("STAY");
    }

    void OnCollisionExit(Collision c){
        print("EXIT");
    }

    // cuando un involucrado en la colisión es trigger
    // el engine de física ya no lo toma en cuenta para movimiento

    // la colisión con trigger tiene su propio juego de métodos para detección

    void OnTriggerEnter(Collider c) {
        // collider NO tiene info de la física
        // es sólo referencia al collider del objeto con el que chocamos
        print("TRIGGER ENTER " + c.transform.name);
        print("TAG: " + c.transform.tag);
        print("LAYER: " + c.gameObject.layer);

        // destroy - destruye un gameobject completo
        // O un componente
        Destroy(c.gameObject);
    }

    void OnTriggerStay(Collider c) {
        //print("TRIGGER STAY");
    }

    void OnTriggerExit(Collider c) {
        print("TRIGGER EXIT");
    }
}
