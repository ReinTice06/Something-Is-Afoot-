using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public Renderer Bulb1;
    public Material switchOn;
    public Material switchOff;
    public Animator animator;
    public bool isOn = false;

    private void Awake()
    {
        Bulb1.material = switchOff;
    }

    //On trigger enter turn on the switch
    private void OnTriggerEnter(Collider other)
    {
        animator.SetTrigger("Pulled");
        isOn = true;
        Bulb1.material = switchOn;
    }
}
