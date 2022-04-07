using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class UIDialogue
{
    //Name for person talking
    public string name;

    //Text area for inspector (min lines, max lines)
    [TextArea(3, 10)]
    //Array of sentences from inspector
    public string[] sentences;

}
