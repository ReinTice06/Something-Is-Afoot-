using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaFloor : MonoBehaviour
{
    //Array of switches assigned in inspector
    public Lever[] switches;
    //Points for object to move to
    public GameObject point1;
    public GameObject point2;
    public GameObject point3;
    public GameObject point4;
    //Vector3 of points
    private Vector3 pos1;
    private Vector3 pos2;
    private Vector3 pos3;
    private Vector3 pos4;
    //Next pos vector3
    private Vector3 nextPos;
    //Speed lava moves at
    private float speed = 4;
    //Check to allow switch count to increase once per activated switch
    private bool atPos1 = false;
    private bool atPos2 = false;
    private bool atPos3 = false;
    //Switch count activated
    private int switchCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        //Assign points a vector 3
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
    //Checks if any switches are activated then moves the lava
    public void SwitchCheck()
    {
        //If switch 0 is pressed
        if (switches[0].isOn)
        {
            //Check hasnt ran yet
            if (!atPos1)
            {
                atPos1 = true;
                //Increase activated switch count by one
                switchCount += 1;
            }
            //Moves the lava
            MoveLava();

        }
        //If switch 1 is pressed
        if (switches[1].isOn)
        {
            //Check hasnt ran yet
            if (!atPos2)
            {
                atPos2 = true;
                //Increase activated switch count by one
                switchCount += 1;
            }
            //Moves the lava
            MoveLava();
        }
        //If switch 2 is pressed
        if (switches[2].isOn)
        {
            //Check hasnt ran yet
            if (!atPos3)
            {
                atPos3 = true;
                //Increase activated switch count by one
                switchCount += 1;
            }
            //Moves the lava
            MoveLava();
        }
        
    }
    //Funtion to move the lava if switches are activated
    public void MoveLava()
    {
        //One switch is on
        if (switchCount == 1)
        {
            //Assign next position
            nextPos = pos2;
            //Moves the lava
            transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
        }
        //Two switches are on
        if (switchCount == 2)
        {
            //Assign next position
            nextPos = pos3;
            //Moves the lava
            transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
        }
        //Three switches are on
        if (switchCount == 3)
        {
            //Assign next position
            nextPos = pos4;
            //Moves the lava
            transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
        }
    }
}
