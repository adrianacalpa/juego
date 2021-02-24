using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comportamiento_pista : MonoBehaviour
{
    // Definición de variables
    bool var;
    int cont=0;
    //--------------------------------------------------------
    private void Start()
    {
        
    }
    //--------------------------------------------------------
    void Update()
    {   
        if (var==true)
        {
            Debug.Log(1);
            cont += 1;
            var = false;
        }
    }
    //--------------------------------------------------------
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Función que finaliza el juego e identifica al jugador ganador
       
        if(other.name=="player1")
        {
            carroScript carro = other.GetComponent<carroScript>();

            if (carro != null)
            {
                carro.fMeta ();
            }
        }
        else if(other.name == "player2")
        {
            player2Script player2 = other.GetComponent<player2Script>();

            if (player2 != null)
            {
                player2.fMeta();
            }
        }
        //Debug.Log("Se ha colisionado con: " + other.name);

        //Comunicacion entre scripts
        //Usar el nombre de la clase con la que me quiero comunicar
        //Crear un nuevo objeto que herede los atributos de navescript, llamar a la variables disparo triple y destruir el game object de powerUp
        
        

    }
}
