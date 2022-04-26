using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool isPaused = false;
    public GameObject PauseMenuUI;
    public GameObject OptionsMenuUI;
    public CameraController cameraScript;
    public Animator animator;
    public GameObject theplayer;

    // Update is called once per frame
    void Update()
    {
        pauseGame();
    }

    void pauseGame()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                //Resumes game if game is already paused
                Resume();
            }
            //Pauses game
            else
            {
                Pause();
            }
        }
    }

    //Resume Game Function
    public void Resume()
    {
        //Enable Camera Movement
        cameraScript.GetComponent<CameraController>().enabled = true;
        //Turn off Pause Menu UI
        PauseMenuUI.SetActive(false);
        //Un-freeze time
        Time.timeScale = 1f;
        isPaused = false;
        //Disables cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    //Pause Game Function
    public void Pause()
    {
        //Disable Camera Movement
        cameraScript.GetComponent<CameraController>().enabled = false;
        //Turn on Pause Menu UI
        PauseMenuUI.SetActive(true);
        //Stop Time
        Time.timeScale = 0f;
        isPaused = true;
        //Enables cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    //Menu Funtion
    public void menu()
    {
        //Loads menu scene
        SceneManager.LoadScene(0);
        //Ensures pause menu UI is off
        PauseMenuUI.SetActive(false);
        //Un-freeze time
        Time.timeScale = 1f;
        isPaused = false;
    }
    //Exit Game Function
    public void exitGame()
    {
        //Quits game
        Application.Quit();
        Debug.Log("Quitting Game");
    }
    //Options Window
    public void options()
    {
        //Turns off pause menu ui
        PauseMenuUI.SetActive(false);
        //Turns on options menu ui
        OptionsMenuUI.SetActive(true);
    }
    //Back to Pause Menu UI
    public void back()
    {
        //Turns off options menu ui
        OptionsMenuUI.SetActive(false);
        //Turns on pause menu ui
        PauseMenuUI.SetActive(true);
    }
    //Respawn Function
    public void respawn()
    {
        Resume();
        theplayer.GetComponent<Player>().playerDied = true;
        theplayer.GetComponent<Player>().Respawn();
    }
}
