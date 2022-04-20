using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public GameObject playerCollisionChecker;


    public Transform startPos, endPos;
    public float timeDuration = 1f;
    public bool startMoving = false;

    public Vector3 p01;
    public Quaternion r01;

    public bool movingDown = false;
    public bool movingUp = false;

    public bool atBottom = false;
    public bool atTop = false;

    public float timeStart;
    //public bool isDown = false;

    public float uMin = 0;
    public float uMax = 1;
    public float easingMod = 2;

    private void Start()
    {
        atTop = true;
        //startMoving = false;

        //movingDown = true;
        //timeStart = Time.time;
    }


    void Update()
    {
        if (playerCollisionChecker.GetComponent<elevatorTrigger>().playerInside == true && atTop == true)
        {
            playerCollisionChecker.GetComponent<elevatorTrigger>().playerInside = false;
            atTop = false;
            //playerCollisionChecker.GetComponent<elevatorTrigger>().playerInside = false;
            //startMoving = true;
            //startMoving = false;

            movingDown = true;
            timeStart = Time.time;
        }

        if (playerCollisionChecker.GetComponent<elevatorTrigger>().playerInside == true && atBottom == true)
        {
            playerCollisionChecker.GetComponent<elevatorTrigger>().playerInside = false;
            atBottom = false;
            //startMoving = true;
            //startMoving = false;

            movingUp = true;
            timeStart = Time.time;
        }

        //This should check to see if a button was pressed so that it will either go down or back up again
        //Or maybe it should just go down and the player won;t be allowed to go back up?

        //if (atTop)
        //{
        //    movingUp = false;
        //    startMoving = true;
        //    startMoving = false;
        //    movingDown = true;
        //    timeStart = Time.time;
        //}

        //if (atBottom)
        //{
        //    movingDown = false;
        //    movingUp = true;
        //    startMoving = true;
        //    startMoving = false;
        //    timeStart = Time.time;
        //}

        if (movingDown)
        {
            float u = (Time.time - timeStart) / timeDuration;
            if (u >= 1)
            {
                u = 1;
                movingDown = false;
                atBottom = true;
            }

            u = EaseInOut(u);

            p01 = (1 - u) * startPos.position + u * endPos.position;
            r01 = Quaternion.Slerp(startPos.rotation, endPos.rotation, u);

            transform.position = p01;
            transform.rotation = r01;
        }

        if (movingUp)
        {
            float u = (Time.time - timeStart) / timeDuration;
            if (u >= 1)
            {
                u = 1;
                movingUp = false;
                atTop = true;
            }

            u = EaseInOut(u);

            p01 = (1 - u) * endPos.position + u * startPos.position;
            r01 = Quaternion.Slerp(endPos.rotation, startPos.rotation, u);

            transform.position = p01;
            transform.rotation = r01;
        }
    }

    private float EaseInOut(float u)
    {
        float u2 = u;
        if (u <= 0.5f)
        {
            u2 = 0.5f * Mathf.Pow(u * 2, easingMod);
        }
        else
        {
            u2 = 0.5f + 0.5f * (1 - Mathf.Pow(1 - (2 * (u - 0.5f)), easingMod));
        }
        return u2;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ElevatorEnd"))
        {
            atBottom = true;
        }
        else if (other.CompareTag("ElevatorStart"))
        {
            atTop = true;
        }
    }
}
