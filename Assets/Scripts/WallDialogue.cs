using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDialogue : MonoBehaviour
{
    //When Player collides with Collectible it dissapears and shows up on the UI
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            this.GetComponent<MeshRenderer>().enabled = true;
            //Debug.Log("Did I get in here?");
        }
    }

    //Gets rid of the text once you leave the sphere
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            this.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
