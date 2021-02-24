using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2Script : MonoBehaviour
{
    // Defición de variables

    public float velocidad = 3.0f;
    public float torque = -150.0f;

    public bool velocidadMax = false;
    public bool velocidadMin = false;
    public float velMax = 8.0f;
    public float velMin = 1.0f;

    public float factor = 0.9f;
    public float facrapidez = 0.1f;
    public float rapMax = 2.5f;
    public int nVueltas = 0;

    public int maxVueltas;

    public bool bandera1 = false;
    public bool bandera2 = false;
    public bool bandera3 = false;
    public bool aux1 = false;
    public bool aux2 = false;
    public bool aux3 = false;

    //---------------------------------------------
    void Start()
    {
        // Posición predeterminada del auto al iniciar el juego
        transform.position = new Vector3(1.66f, 8.63f, 0);
        maxVueltas = 3;
    }

    //---------------------------------------------
    void Update()
    {

        movimientoAuto();
    }
    //---------------------------------------------
    void movimientoAuto()
    {

        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        float auxfactor = factor;
        if (velDerecha().magnitude > rapMax)
        {
            auxfactor = facrapidez;
        }


        //-- VELOCIDAD DEL MOVIMIENTO PARA EL AUTO 2  --

        //--- Acelerar con la tecla F --
        if (velocidadMax == false && velocidadMin == false && Input.GetKey(KeyCode.F))
        {
            rb.AddForce(transform.up * velocidad);
        }
        else if (velocidadMax == true && velocidadMin == false && Input.GetKey(KeyCode.F))
        {
            rb.AddForce(transform.up * velMax);
        }
        else if (velocidadMax == false && velocidadMin == true && Input.GetKey(KeyCode.F))
        {
            rb.AddForce(transform.up * velMin);
        }

        float t = Mathf.Lerp(0, torque, rb.velocity.magnitude / 2);


        rb.angularVelocity = (Input.GetAxis("Vertical2") * torque);
    }

    //-----Control de velocidad ---------
    Vector2 velAdelante()
    {
        return transform.up * Vector2.Dot(GetComponent<Rigidbody2D>().velocity, transform.up);
    }
    //--
    Vector2 velDerecha()
    {
        return transform.up * Vector2.Dot(GetComponent<Rigidbody2D>().velocity, transform.right);
    }

    //--
    //==============FUNCIONES VELOCIDAD PODERES============
    public void VelMaxEncendido()
    {
        velocidadMax = true;
        velocidadMin = false;
        StartCoroutine(poderVelMax());
    }
    //----------------------------------------------------
    public IEnumerator poderVelMax()
    {
        yield return new WaitForSeconds(5.0f);
        velocidadMax = false; //  Terminar poder velocidad máxima
    }
    //----------------------------------------------------
    public void VelMinEncendido()
    {
        velocidadMin = true;
        velocidadMax = false;
        StartCoroutine(poderVelMin());
    }

    //----------------------------------------------------
    public IEnumerator poderVelMin()
    {
        yield return new WaitForSeconds(5.0f);
        velocidadMin = false; //  Terminar poder velocidad mínima

    }
    //============= FUNCIONES META ==================
    //--
    public void fMeta()
    {
        if (bandera1 == true && bandera2 == true && bandera3 == true)
        {

            FindObjectOfType<gameManager>().EndGame();
            Debug.Log("Fin juego gana: jugador 2");
        }
        else if (aux1 == true && aux2 == true && aux3 == true)
        {
            aux1 = false;
            aux2 = false;
            aux3 = false;

        }

    }
    //------------------------------------------------------
    public void banderaUno()
    {
        Debug.Log("aux1" + aux1);
        if (nVueltas == maxVueltas - 1)
        {
            bandera1 = true;

        }
        else { aux1 = true; }
        Debug.Log("aux1 " + aux1);
    }
    //--
    public void banderaDos()
    {
        Debug.Log("bandera2 " + nVueltas);
        Debug.Log("aux2 " + aux2);
        if (nVueltas == maxVueltas - 1 && bandera1 == true)
        {
            bandera2 = true;
            Debug.Log("ban2 " + bandera2);
        }
        else if (nVueltas != maxVueltas && aux1 == true)
        {
            aux2 = true;
        }
        else
        {
            transform.position = new Vector3(1.78f, 4.26f, 0); // Regresa al carro a la bandera 1
            transform.rotation = Quaternion.Euler(2.31f, -8.5f, -282f);
        }
        Debug.Log("aux2" + aux2);
    }
    //--
    public void banderaTres()
    {
        Debug.Log("bandera3" + bandera3);
        Debug.Log("aux3" + aux3);

        if (nVueltas == maxVueltas- 1 && bandera1 == true && bandera2 == true)
        {
            bandera3 = true;
            Debug.Log("ban3 " + bandera3);
        }
        else if (nVueltas != maxVueltas - 1 && aux1 == true && aux2 != true)
        {
            transform.position = new Vector3(1.66f, 7.87f, 0); // Regresa al carro a la posición inicial
            aux1 = false;
        }
        else if (nVueltas != maxVueltas && aux1 == true && aux2 == true)
        {
            nVueltas += 1;
            Debug.Log("vueltas:" + nVueltas);
            aux3 = true;
        }
        Debug.Log("aux3" + aux3);

    }

}
