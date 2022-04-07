using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    //Reference to player script
    public Player thePlayer;
    //Reference to renderer
    public Renderer theRend;
    //Reference to Materials
    public Material cpOff;
    public Material cpOn;


    private void Start()
    {
        //Finds the player script
        thePlayer = FindObjectOfType<Player>();
    }

    //Changes material to cpOn material
    public void CheckpointOn()
    {
        //Creates array of checkpoints with objects that have this script
        Checkpoint[] checkpoints = FindObjectsOfType<Checkpoint>();
        //for each checpoint (cp) in the checkpoint array
        foreach(Checkpoint cp in checkpoints)
        {
            //Turns each checkpoint to cpOff material
            cp.CheckpointOff();
        }

        theRend.material = cpOn;
    }

    //Changes material to cpOff material
    public void CheckpointOff()
    {
        theRend.material = cpOff;

    }

    private void OnTriggerEnter(Collider other)
    {
        //If player collides with checkpoint
        if (other.tag.Equals("Player"))
        {
            //Sets new spawn point at current position of this checkpoint
            thePlayer.SetSpawnPoint(transform.position);
            //Changes the color to cpOn
            CheckpointOn();
        }
    }

   
}
