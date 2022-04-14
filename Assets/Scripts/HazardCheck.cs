using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardCheck : MonoBehaviour
{
    Coroutine baseBootDamage;
    Coroutine fireBootDamage;
    Coroutine waterBootDamage;
    

    public bool runBoost = false;

    Boots bootScript;


    

    public void OnTriggerEnter(Collider other)
    {
        //If not wearing water boots deplete all power
        if (Boots.waterBoot == false)
        {
            //Is touching water
            if (other.gameObject.tag == "Water")
            {
                //Lose all power
                GetComponent<Boots>().losePower(100);
                GetComponent<Boots>().powerBar.SetPower(Boots.currentPower);
                Debug.Log("Player Touched Water Without Water Boots");
            }

        }
        //If wearing water boots
        else
        {
            //Is touching water
            if (other.gameObject.tag == "Water")
            {
                //depleates water boot power while in water
                waterBootDamage = StartCoroutine(WaterBootDamage());
            }
        }


        //If not wearing fire boots depleate all power
        if (Boots.fireBoot == false)
        {
            //Is touching lava
            if (other.gameObject.tag == "Lava")
            {
                //Lose all power
                GetComponent<Boots>().losePower(100);
                GetComponent<Boots>().powerBar.SetPower(Boots.currentPower);
                Debug.Log("Player Touched Lava Without Fire Boots");
            }
        }
        //If wearing fire boots
        else
        {
            //Is touching lava
            if (other.gameObject.tag == "Lava")
            {
                fireBootDamage = StartCoroutine(FireBootDamage());
            }
        }

        if (other.gameObject.tag == "Rope")
        {
            //Lose all power
            GetComponent<Boots>().losePower(100);
            GetComponent<Boots>().powerBar.SetPower(Boots.currentPower);
            Debug.Log("Player Touched A Live Wire");
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("PistonCollider"))
        {
            if (other.gameObject.GetComponent<PistonCollider>().killPlayer)
            {
                //Lose all power
                GetComponent<Boots>().losePower(100);
                GetComponent<Boots>().powerBar.SetPower(Boots.currentPower);
                Debug.Log("Player Got Smashed By Pistons");
            }
        }
        //if (other.gameObject.CompareTag("PistonCollider2"))
        //{
        //    if (other.gameObject.GetComponent<PistonCollider>().killPlayer)
        //    {
        //        //Lose all power
        //        GetComponent<Boots>().losePower(100);
        //        GetComponent<Boots>().powerBar.SetPower(Boots.currentPower);
        //        Debug.Log("Player Got Smashed By Pistons");
        //    }
        //}
    }

    public void OnTriggerExit(Collider other)
    {
        //Stop taking water power damage
        if (other.gameObject.tag == "Water")
        {
            if (waterBootDamage != null)
            {
                StopCoroutine(waterBootDamage);
            }
            

        }
        //Stop taking fire power damage
        if (other.gameObject.tag == "Lava")
        {
            if (fireBootDamage != null)
            {
                StopCoroutine(fireBootDamage);
            }
        }

    }
    
    //Need to have the base boot run only work on holding shift instead of all the time

    //If base boots are worn reduce power then stops speed boost
    public void baseBCheck()
    {
        if(Boots.baseBPower <= 10)
        {
            StopCoroutine(BaseBootDamage());
        }
    }

    //Coroutine for base boot damage every 2 seconds
    public IEnumerator BaseBootDamage()
    {
        while (true)
        {
            if (Boots.baseBPower >= 10)
            {
                
                //Reduces base boots power by XX
                Boots.baseBPower -= 2;
                //Updates power bar with new base power #
                GetComponent<Boots>().powerBar.SetPower(Boots.baseBPower);
                yield return new WaitForSeconds(2);
                Debug.Log("reduced power and waited");
            }
            yield return null;
        }

    }

    //Coroutine for water boot damage every 2 seconds
    IEnumerator WaterBootDamage()
    {
        while (true)
        {
            if (Boots.waterBPower > 0)
            {
                //Reduces water power by XX
                Boots.waterBPower -= 5;
                //Updates power bar with new water power #
                GetComponent<Boots>().powerBar.SetPower(Boots.waterBPower);
                yield return new WaitForSeconds(2);
            }
            
        }
    }
    //Coroutine for fire boot damage every 2 seconds
    IEnumerator FireBootDamage()
    {
        while (true)
        {
            if (Boots.fireBPower > 0)
            {
                //Reduces fire boots power by XX
                Boots.fireBPower -= 10;
                //Updates power bar with new fire power #
                GetComponent<Boots>().powerBar.SetPower(Boots.fireBPower);
                yield return new WaitForSeconds(2);
            }
        }
        
        
    }

}