using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public GameObject DialoguePanel;

    //Collection of dialogue
    private Queue<string> sentences;

    // Start is called before the first frame update
    void Start()
    {
        //Initialize collection of dialogue
        sentences = new Queue<string>();
    }

    private void Update()
    {
        //Press Q to continue with dialogue
        if (Input.GetKeyDown(KeyCode.Q))
        {
            DisplayNextSentence();
        }
    }

    //Start dialogue
    public void StartDialogue(UIDialogue dialogue)
    {
        Debug.Log("Starting conversation with " + dialogue.name);

        //Changes UI name text to "name" in inspector
        nameText.text = dialogue.name;

        //Clears previous sentences
        sentences.Clear();

        //for each sentence in the inspector dialogue
        foreach(string sentence in dialogue.sentences)
        {
            //Add sentences to queue
            sentences.Enqueue(sentence);
        }

        //Display first sentence
        DisplayNextSentence();
        
    }

    public void DisplayNextSentence()
    {
        //Check if more sentences in queue
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        //Get next sentence if more left
        string sentence = sentences.Dequeue();
        //Ensures TypeSentence is ended before starting a new one
        StopAllCoroutines();
        //Displays the sentence one letter at a time
        StartCoroutine(TypeSentence(sentence));
    }

    //Corutine for writing out the sentence 
    IEnumerator TypeSentence (string sentence)
    {
        //Set dialogue text to empty string
        dialogueText.text = "";

        //Move through each letter in the sentence
        foreach (char letter in sentence.ToCharArray())
        {
            //Apppend letter to the end of the string
            dialogueText.text += letter;
            //Wait time after each letter
            yield return new WaitForSeconds(0.05f);
        }
    }

    //End Dialogue
    void EndDialogue()
    {
        //Disables UI 
        DialoguePanel.SetActive(false);
        Debug.Log("End of conversation");
    }

}
