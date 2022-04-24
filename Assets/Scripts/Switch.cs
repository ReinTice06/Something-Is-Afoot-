using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public Renderer Bulb1;
    public Renderer Bulb2;
    public Material switchOn;
    public Material switchOff;
    public bool isOn = false;

    //On trigger enter turn on the switch
    private void OnTriggerEnter(Collider other)
    {
        isOn = true;        
    }

}

