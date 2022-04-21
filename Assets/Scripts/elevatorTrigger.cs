using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevatorTrigger : MonoBehaviour
{
    public bool playerInside;
    public bool elevatorReachedBottom;

    // Start is called before the first frame update
    void Start()
    {
        playerInside = false;
        elevatorReachedBottom = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            playerInside = true;
            
            if (other.gameObject.CompareTag("ElevatorEnd"))
            {
                elevatorReachedBottom = true;
            }

            if (other.gameObject.CompareTag("ElevatorEnd"))
            {
                elevatorReachedBottom = false;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInside = false;
        }
    }
}
