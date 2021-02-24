using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class gameManager : MonoBehaviour
{
    // Start is called before the first frame update
    bool Gameover = false;
    public void EndGame()
    {
        if(Gameover==false)
        {
            Gameover = true;
            Debug.Log("GAME OVER");
            SceneManager.LoadScene("GameOver");
            //Restart();
        }
        
    }

    void Restart()
    {
        SceneManager.LoadScene("Escena1"); // Aqui ponemos la escena de inicio
    }

    // Update is called once per frame
}
