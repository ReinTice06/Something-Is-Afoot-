using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public Switch Switch1;
    public Switch Switch2;
    public Light light1;
    public Light light2;
    public Color Off;
    public Color On;

    private void Start()
    {
        //Sets light starting color to Off color
        light1.color = Off;
        light2.color = Off;
        //Switch 1 bulbs off
        Switch1.Bulb1.material = Switch1.switchOff;
        Switch1.Bulb2.material = Switch1.switchOff;
        //Switch 2 bulbs off
        Switch2.Bulb1.material = Switch2.switchOff;
        Switch2.Bulb2.material = Switch2.switchOff;
    }
    private void Update()
    {
        OpenDoor();
        DoorLight();
    }
    public void OpenDoor()
    {
        //Checks if switches are turned on
        if (Switch1.isOn && Switch2.isOn)
        {
            //Destroys door
            Destroy(gameObject);
        }
    }
    public void DoorLight()
    {
        //Turns on light one if switch is activated
        if(Switch1.isOn)
        {
            //Turns on light 1
            light1.color = On;
            //Turns on bulb 1 for both switches
            Switch1.Bulb1.material = Switch1.switchOn;
            Switch2.Bulb1.material = Switch2.switchOn;
        }
        //Turns on light two if switch is activated
        if (Switch2.isOn)
        {
            //Turns on light 1
            light2.color = On;
            //Turns on bulb 2 for both switches
            Switch1.Bulb2.material = Switch1.switchOn;
            Switch2.Bulb2.material = Switch2.switchOn;
        }
    }
}
 