using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    //Switches
    public Switch Switch1;
    public Switch Switch2;
    public Switch Switch3;
    public Switch Switch4;
    public Switch Switch5;
    //Lights
    public GameObject Lights1;
    public GameObject Lights2;
    public GameObject Lights3;
    public GameObject Lights4;
    public GameObject Lights5;


    private void Update()
    {
        TurnOnLight();
    }
    public void TurnOnLight()
    {
        //Turns on light gameobject group if correlating switch is on
        //Light1
        if (Switch1.isOn)
        {
            Lights1.SetActive (true);

        }
        //Light2
        if (Switch2.isOn)
        {
            Lights2.SetActive(true);

        }
        //Light3
        if (Switch3.isOn)
        {
            Lights3.SetActive(true);

        }
        //Light4
        if (Switch4.isOn)
        {
            Lights4.SetActive(true);

        }
        //Light5
        if (Switch5.isOn)
        {
            Lights5.SetActive(true);

        }
    }
}
