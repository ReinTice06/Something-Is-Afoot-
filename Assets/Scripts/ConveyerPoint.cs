using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyerPoint : MonoBehaviour
{
    public GameObject ConveyerBelt;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            ConveyerBelt.GetComponent<ConveyerBelt>().canMoveToNextPOS = true;
        }
    }
}