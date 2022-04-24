using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseBossArm : MonoBehaviour
{
    public BossController bossController;

    public void pauseArm()
    {
        bossController.Pause = true;
    }
    public void playArm()
    {
        bossController.Pause = false;
    }
}
