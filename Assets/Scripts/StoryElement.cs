using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryElement : MonoBehaviour
{
    //Attatch this script to triggers in order to give a sequence of dialog on the UI
    
    //Ref to Dialogue Manager
    private DialogueManager dialogueManager;
    //Ref to UIDialogue
    public UIDialogue dialogue;


    private void Start()
    {
        //Find Dialogue Manager
        dialogueManager = FindObjectOfType<DialogueManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            //Turns on UI Panel and displays dialogue
            dialogueManager.DialoguePanel.SetActive(true);
            TriggerDialogue();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Turns of UI panel
            dialogueManager.DialoguePanel.SetActive(false);
        }
    }

    public void TriggerDialogue()
    {
        //Finds the dialogue script and starts (dialogue)
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
