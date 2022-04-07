using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargingStation : MonoBehaviour
{

    private float maxBattery;
    public float currentBattery;
    public Boots bootScript;
    Coroutine chargeBoots;

    // Start is called before the first frame update
    void Start()
    {
        maxBattery = 100;
        currentBattery = maxBattery;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Hazard Check")
        {
            if (currentBattery > 0)
            {
                //Starts corutine to charge boots
                chargeBoots = StartCoroutine(ChargeBoots());
                
            }
            
        }
    }

    public void OnTriggerExit(Collider other)
    {
        //Stop taking water power damage
        if (other.name == "Hazard Check")
        {
            if (chargeBoots != null)
            {
                //Ends corutine when stepping off charging station
                StopCoroutine(chargeBoots);
                Debug.Log("Stopped Charging Boots");
            }
        }
    }

    //Coroutine for Charging Boots every 1 second
    IEnumerator ChargeBoots()
    {
        while (currentBattery > 0)
        {
            //Charges boots
            bootScript.ChargeCurrentBoot();
            //Reduces charging station battery
            currentBattery -= 5;
            yield return new WaitForSeconds(1);
        }
        yield return null;
        Debug.Log("Station ran out of power");
    }
    
}
