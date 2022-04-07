using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public Switch Switch1;
    public Switch Switch2;

    private void Update()
    {
        OpenDoor();
    }
    public void OpenDoor()
    {
        if (Switch1.isOn && Switch2.isOn)
        {
            Destroy(gameObject);
        }
    }

}
 