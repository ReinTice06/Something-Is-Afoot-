using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public Renderer theRend;
    public Material switchOn;
    public Material switchOff;

    public bool isOn = false;

    private void Start()
    {
        theRend.material = switchOff;
    }

    private void OnTriggerEnter(Collider other)
    {
        isOn = true;
        theRend.material = switchOn;
    }
}
