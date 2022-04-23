using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDoorCollision : MonoBehaviour
{
    public bool lavaEntered = false;
    public bool lavaExited = false;
    public bool lavaInside = false;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Lava")
        {
            lavaEntered = true;
            lavaInside = true;
            lavaExited = false;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Lava")
        {
            lavaInside = false;
            lavaEntered = false;
            lavaExited = true;
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Lava")
        {
            lavaInside = true;
        }
    }
}