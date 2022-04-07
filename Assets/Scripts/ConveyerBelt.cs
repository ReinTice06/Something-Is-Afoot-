using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyerBelt : MonoBehaviour
{
    //Switches for activation
    public Switch switch1;
    public Switch switch2;

    public GameObject Player;
    public GameObject PointACheck;

    [SerializeField] Transform[] Positions;
    [SerializeField] float ConveyerSpeed;

    int NextPosIndex;
    Transform NextPos;

    public bool hasPower;
    bool onConveyer;
    public bool canMoveToNextPOS;

    private void Start()
    {
        hasPower = false;
        NextPos = Positions[0];
    }
    void FixedUpdate()
    {
        activateConveyer();
        //MoveGameObject();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Debug.Log("Player is on Conveyer");
            onConveyer = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Debug.Log("Player is off Conveyer");
            onConveyer = false;
        }
    }
    //Checks if conveyer switches are on then activates conveyer
    void activateConveyer()
    {
        if(switch1.isOn && switch2.isOn)
        {
            hasPower = true;
            MoveGameObject();
        }
    }
    void MoveGameObject()
    {
        if (onConveyer && hasPower)
        {
            //if (Player.transform.position == NextPos.position)
            //{
            //    NextPosIndex++;
            //    if (NextPosIndex >= Positions.Length)
            //    {
            //        NextPosIndex = 0;
            //    }
            //    NextPos = Positions[NextPosIndex];
            //}
            //else
            {
                Player.transform.position = Vector3.MoveTowards(Player.transform.position, Positions[1].position, ConveyerSpeed * Time.deltaTime);
                //Debug.Log(Positions[NextPosIndex]);
            }
        }
    }
}