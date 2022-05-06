using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public CollectibleCounter collectible;

    private void OnTriggerEnter(Collider other)
    {
        //If player collides then load game over
        if (other.gameObject.tag == "Player")
        {
            //Enables cursor
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            //If collected all collectables show easter egg
            if (collectible.allCollectables == true)
            {
                SceneManager.LoadScene(3);
            }
            //If not collected all collectables show game over
            else
            {
                SceneManager.LoadScene(2);
            }
        }
    }
}
