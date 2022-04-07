using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        //If player collides then load game over
        if (other.gameObject.tag == "Player")
        {
            //Enables cursor
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            //Loads game over scene
            SceneManager.LoadScene(2);
        }
    }
}
