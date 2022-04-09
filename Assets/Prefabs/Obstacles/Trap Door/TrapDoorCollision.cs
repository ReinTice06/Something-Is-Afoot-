using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDoorCollision : MonoBehaviour
{
    public bool lavaEntered = false;
    public bool lavaExited = false;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Lava")
        {
            lavaEntered = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Lava")
        {
            lavaExited = true;
        }
    }
}