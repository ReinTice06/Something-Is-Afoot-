using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaFloor : MonoBehaviour
{
    public Switch[] switches;

    public GameObject point1;
    public GameObject point2;
    public GameObject point3;
    public GameObject point4;

    private Vector3 pos1;
    private Vector3 pos2;
    private Vector3 pos3;
    private Vector3 pos4;



    // Start is called before the first frame update
    void Start()
    {
        pos1 = point1.transform.position;
        pos2 = point2.transform.position;
        pos3 = point3.transform.position;
        pos4 = point4.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        SwitchCheck();
    }

    public void SwitchCheck()
    {
        if (switches[0].isOn)
        {
            transform.Translate(0, 10, 0);
        }
        
        
    }
    

}
