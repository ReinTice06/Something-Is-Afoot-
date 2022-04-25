using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class conveyerBeltEnd : MonoBehaviour
{
    public GameObject conveyerMain;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

        }
    }
}
