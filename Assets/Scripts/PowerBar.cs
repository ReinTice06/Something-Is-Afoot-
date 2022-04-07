using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerBar : MonoBehaviour
{
    public Slider powerSlider;
    public Gradient gradient;
    public  Image fill;

    public void SetMaxPower(float power)
    {
        powerSlider.maxValue = power;
        powerSlider.value = power;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetPower(float power)
    {
        powerSlider.value = power;

        fill.color = gradient.Evaluate(powerSlider.normalizedValue);
    }

}
