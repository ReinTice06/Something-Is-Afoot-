using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistonCollider : MonoBehaviour
{
    public bool killPlayer = false;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PistonCollider"))
        {
            killPlayer = true;
        }
        if (other.gameObject.CompareTag("PistonCollider2"))
        {
            killPlayer = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("PistonCollider"))
        {
            killPlayer = false;
        }
        if (other.gameObject.CompareTag("PistonCollider2"))
        {
            killPlayer = false;
        }
    }
}
