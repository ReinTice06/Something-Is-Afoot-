using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TrapDoor : MonoBehaviour
{
    public GameObject CollisionChecker;

    public Transform c0, c1;
    public float timeDuration = 1f;
    public bool startMoving = false;

    public Vector3 p01;
    public Quaternion r01;

    public bool moving = false;
    public bool movingBack = false;

    public float timeStart;
    public bool isDown = false;
    public bool stayOpen = false;

    public float uMin = 0;
    public float uMax = 1;

    public float easingMod = 2;

    void Update()
    {
        //Opens the bridge, when a bucket enters
        if (CollisionChecker.GetComponent<TrapDoorCollision>().lavaEntered)
        {
            if (stayOpen == false)
            {
                CollisionChecker.GetComponent<TrapDoorCollision>().lavaEntered = false;
                startMoving = true;
                startMoving = false;

                moving = true;
                timeStart = Time.time;
            }
            stayOpen = true;
        }

        //Close door, when no bucket is present, and one leaves
        //if (CollisionChecker.GetComponent<TrapDoorCollision>().lavaExited)
        //{
        //    if (CollisionChecker.GetComponent<TrapDoorCollision>().lavaInside == false)
        //    {
        //        //CollisionChecker.GetComponent<TrapDoorCollision>().lavaInside = false;
        //        //CollisionChecker.GetComponent<TrapDoorCollision>().lavaExited = false;
        //        //startMoving = true;
        //        //startMoving = false;

        //        movingBack = true;
        //        timeStart = Time.time;
        //    }
        //}

        //if (CollisionChecker.GetComponent<TrapDoorCollision>().lavaInside)
        //{
        //    movingBack = true;
        //}

        if (moving)
        {
            float u = (Time.time - timeStart) / timeDuration;
            if (u >= 1)
            {
                u = 1;
                moving = false;
            }

            u = EaseInOut(u);

            p01 = (1 - u) * c0.position + u * c1.position;
            r01 = Quaternion.Slerp(c0.rotation, c1.rotation, u);

            transform.position = p01;
            transform.rotation = r01;
        }

        //else if (movingBack)
        //{
        //    float u = (Time.time - timeStart) / timeDuration;
        //    if (u >= 1)
        //    {
        //        u = 1;
        //        movingBack = false;
        //    }

        //    u = EaseInOut(u);

        //    p01 = (1 - u) * c1.position + u * c0.position;
        //    r01 = Quaternion.Slerp(c1.rotation, c0.rotation, u);

        //    transform.position = p01;
        //    transform.rotation = r01;
        //}
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
}