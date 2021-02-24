using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bandera1 : MonoBehaviour
{
    void Start()
    {

    }
    //-----------------------------------------------------------
    void Update()
    {

    }
    //-----------------------------------------------------------
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.name == "player1")
        {
            carroScript carro = other.GetComponent<carroScript>();

            if (carro != null)
            {
                carro.banderaUno();
            }

        }
        else if (other.tag == "player2")
        {
            player2Script player2 = other.GetComponent<player2Script>();
            if (player2 != null)
            {
                player2.banderaUno();
            }
        }

    }
}
