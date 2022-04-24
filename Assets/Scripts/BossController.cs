using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public bool BossOn = false;
    public Transform Target;
    public float speed = 1f;
    public bool Pause = false;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        //Turns boss on
        BossOn = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        rotateBoss();
    }

    //Rotates the boss to look at target
    public void rotateBoss()
    {
        if (BossOn)
        {
            if (!Pause)
            {
                //Define time
                float time = Time.deltaTime * speed;


                animator.SetTrigger("MoveArm");
                //Rotates towards target
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Target.rotation, speed);
            }
        }
    }
}
