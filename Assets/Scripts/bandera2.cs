using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bandera2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.name == "player1")
        {
            carroScript carro = other.GetComponent<carroScript>();

            if (carro != null)
            {
                carro.banderaDos();
            }

        }
        else if (other.tag == "player2")
        {
            player2Script player2 = other.GetComponent<player2Script>();
            if (player2 != null)
            {
                player2.banderaDos();
            }
        }

    }
}
