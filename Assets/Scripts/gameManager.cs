using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class gameManager : MonoBehaviour
{
    // Start is called before the first frame update
    bool Gameover = false;
    public void EndGame(string jugador)
    {
        if(Gameover==false)
        {
            Gameover = true;
            Debug.Log("GAME OVER" + jugador);
            if(jugador == "1") SceneManager.LoadScene("GameOver");
            if(jugador == "2") SceneManager.LoadScene("GameOver2");
            //Restart();
        }
        
    }

    void Restart()
    {
        SceneManager.LoadScene("Escena1"); // Aqui ponemos la escena de inicio
    }

    // Update is called once per frame
}
