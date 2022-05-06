using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class Cutscene : MonoBehaviour
{
    public VideoPlayer video;
    public GameObject exitButton;


    private void LateUpdate()
    {
        if(video.isPlaying == false)
        {
            exitButton.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void exit()
    {
        SceneManager.LoadScene(2);
    }

}
