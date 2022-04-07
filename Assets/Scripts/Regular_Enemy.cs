using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Regular_Enemy : MonoBehaviour
{
    //Speed of enemy
    public int speed;

    //Game Objects
    public GameObject leftPoint;
    public GameObject rightPoint;
    public GameObject forwardPoint;
    public GameObject backPoint;

    //Vector 3s
    private Vector3 leftPos;
    private Vector3 rightPos;
    private Vector3 forwardPos;
    private Vector3 backPos;

    //Bool for X axis
    public bool goingXAxis;

    //Bool for Z axis
    public bool goingZAxis;

    //Bool for going left to right or front to back
    private bool goingLeft;
    private bool goingRight;
    private bool goingForward;
    private bool goingBack;

    // Start is called before the first frame update
    void Start()
    {
        leftPos = leftPoint.transform.position;
        rightPos = rightPoint.transform.position;
        forwardPos = forwardPoint.transform.position;
        backPos = backPoint.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    //Moves enemy between the points
    private void Move()
    {
        if (goingXAxis == true)
        {
            if (goingLeft == true)
            {
                if (transform.position.x <= leftPos.x)
                {
                    goingLeft = false;
                }
                else
                {
                    transform.position += Vector3.left * Time.deltaTime * speed;
                }
            }
            else
            {

                if (transform.position.x >= rightPos.x)
                {
                    goingLeft = true;
                    goingRight = false;
                }
                else
                {
                    goingRight = true;
                    transform.position += Vector3.right * Time.deltaTime * speed;
                }
            }
            if (goingLeft == false)
            {
                if (transform.position.x <= rightPos.x)
                {
                    goingLeft = false;
                }
                else
                {

                    transform.position += Vector3.right * Time.deltaTime * speed;
                }

            }
        }

        //Move front to back
        if (goingZAxis == true)
        {
            if (goingForward == true)
            {
                if (transform.position.z >= forwardPos.z)
                {
                    goingForward = false;

                }
                else
                {
                    transform.position += Vector3.forward * Time.deltaTime * speed;

                }
            }
            else
            {
                if (transform.position.z <= backPos.z)
                {
                    goingForward = true;
                    goingBack = false;

                }
                else
                {
                    goingBack = true;
                    transform.position += Vector3.back * Time.deltaTime * speed;

                }
            }
            if (goingForward == false)
            {
                if (transform.position.z >= backPos.z)
                {
                    goingForward = false;

                }
                else
                {
                    transform.position += Vector3.back * Time.deltaTime * speed;

                }
            }
        }

    }

    //On Trigger Enter
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            print("Player attacked Regular Enemy");
            Destroy(gameObject);
        }
    }

    //On Collision Enter
    public void OnCollisionEnter(Collision collision)
    {
        //Switches directions if hitting a wall
        if (collision.gameObject.tag == "Wall")
        {
            if (goingLeft == true)
            {
                print("hit left wall");
                goingLeft = false;
            }
            if (goingRight == true)
            {
                print("hit right wall");
                goingLeft = true;
                goingRight = false;
            }
            if (goingForward == true)
            {
                print("hit front wall");
                goingForward = false;
            }
            if (goingBack == true)
            {
                print("hit back wall");
                goingForward = true;
                goingBack = false;
            }
        }
    }
}

