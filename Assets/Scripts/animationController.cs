using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationController : MonoBehaviour
{
    public GameObject DeathUI;
    public Animator animator;
    public Player thePlayer;

    // Start is called before the first frame update
    void Start()
    {
        
        animator = GetComponent<Animator>();
    }

    //Crouch animation
    public void crouch()
    {
        if (thePlayer.crouching == true)
        {
            animator.SetBool("crouching", true);
            //Sets speed
            thePlayer.currentSpeed = thePlayer.crouchSpeed;
            //Moves collider down
            thePlayer.controller.height = 1f;
            thePlayer.controller.center = new Vector3(0, 0.87f, 0);
        }
    }

    public void stand()
    {
        if (thePlayer.crouching == false)
        {
            animator.SetBool("crouching", false);
            //Sets speed
            thePlayer.currentSpeed = thePlayer.playerSpeed;
            //Moves player controller back up
            thePlayer.controller.height = 1.95f;
            thePlayer.controller.center = new Vector3(0, 1.06f, 0);
        }
    }


    //Functions used in animation events for death and respawn
    //Enables death UI
    public void EnableDeathUI()
    {
        DeathUI.SetActive(true);
    }
    //Disables DeathUI and starts revive animation
    public void DisableDeathUI()
    {
        animator.ResetTrigger("Death");
        DeathUI.SetActive(false);
        animator.SetTrigger("Revive");
        Debug.Log("Revive animation started");

    }
    //Clears revive animation and respawns the player
    public void respawnPlayer()
    {
        animator.ResetTrigger("Revive");
        thePlayer.Respawn();
    }

}
