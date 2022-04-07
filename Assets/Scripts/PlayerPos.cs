using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPos : MonoBehaviour
{
    //Checkpoints
    public static Vector3 lastCheckPointPos = new Vector3(-7, 2);

    private void Awake()
    {
        GameObject.FindGameObjectWithTag("Player").transform.position = lastCheckPointPos;
    }

    public void Update()
    {
        if(Input.GetKeyDown("."))
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(0);
        }
    }
    /*public void OnControllerColliderHit(ControllerColliderHit hit)
    {
        {
            if (hit.gameObject.tag == "FallCheck")
            {
                transform.position = respawnPoint;
                Debug.Log("Fell off");
            }
            else if (hit.gameObject.tag == "Checkpoint")
            {
                respawnPoint = transform.position;
            }
        }
    }
    */


}
