using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenForm : MonoBehaviour
{
    public void openForm()
    {
        Application.OpenURL("https://forms.gle/r2zxjQMsyjg8b5Ny5");
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
