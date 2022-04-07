using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Enables Cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    
    //Start Game Function
    public void startGame()
    {
        //Loads first scene
        SceneManager.LoadScene(1);
    }

    //Exit Game Function
    public void exitGame()
    {
        //Quits game
        Application.Quit();
        Debug.Log("Quitting Game");
    }
}
