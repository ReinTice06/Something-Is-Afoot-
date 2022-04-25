using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BootPowerMeterColor : MonoBehaviour
{
    public Boots bootScript;

    private void Start()
    {
        this.transform.SetAsFirstSibling();
    }

    // Update is called once per frame
    void Update()
    {
        if (Boots.waterBoot)
        {
            this.GetComponent<Image>().color = new Color32(0, 0, 255, 80);
        }

        else if (Boots.fireBoot)
        {
            this.GetComponent<Image>().color = new Color32(255, 0, 0, 80);
        }

        else if (Boots.baseBoot)
        {
            this.GetComponent<Image>().color = new Color32(0, 255, 0, 80);
        }
    }
}
