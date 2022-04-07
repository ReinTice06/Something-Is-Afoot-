using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenForm : MonoBehaviour
{
    public void openForm()
    {
        Application.OpenURL("https://forms.gle/eMW4L1Q6zvfryJxG9");
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
