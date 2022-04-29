using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileKiller : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Lava")
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Water")
        {
            Destroy(other.gameObject);
        }
    }
}
