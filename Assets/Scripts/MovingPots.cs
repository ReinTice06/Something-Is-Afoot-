using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPots : MonoBehaviour
{
    public int speed = 1;

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
    }


}
