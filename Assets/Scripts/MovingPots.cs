using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPots : MonoBehaviour
{
    public int speed = 1;

    //public GameObject Player;

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("KillPots"))
        {
            Destroy(this.gameObject);
        }

        if (other.gameObject.tag == "Player")
        {
            other.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.SetParent(null);
        }
    }
}
