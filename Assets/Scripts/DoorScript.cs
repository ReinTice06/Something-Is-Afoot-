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
            light1.color = On;
        }
        //Turns on light two if switch is activated
        if (Switch2.isOn)
        {
            light2.color = On;
        }
    }
}
 