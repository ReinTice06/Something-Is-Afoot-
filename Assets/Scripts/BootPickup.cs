using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootPickup : MonoBehaviour
{
    //Fire Boot Button UI
    public GameObject FireBootButton;
    //Water Boot Button UI
    public GameObject WaterBootButton;
    //Fire Boot Item
    public GameObject FireBootItem;
    //Water Boot Item
    public GameObject WaterBootItem;
    //Ref to turn current boot button attatched to this script
    private GameObject thisBootButton;
    //Ref to turn current boot item attatched to this script
    private GameObject thisBootItem;
    //Bool for if player is near boots
    private bool canPickUp = false;

    // Update is called once per frame
    void Update()
    {
        TriggerCheck();
    }

    //Check is player is near the boot item
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canPickUp = true;           
        }
    }

    //Checks if player is near boot item and presses "F" to pickup
    private void TriggerCheck()
    {
        if(canPickUp == true && Input.GetKeyDown(KeyCode.F))
        {
            grabThisBoot();
        }
    }

    //Function to pick up the fire boots
    private void grabFireBoot()
    {
        if (canPickUp == true)
        {
            //Defines the boot button
            thisBootButton = FireBootButton;
            //Turns on the boot button
            thisBootButton.SetActive(true);
            //Destroys the game object 
            Destroy(FireBootItem);
            Debug.Log("Picked Up Fire Boots");
        }
    }

    //Function to pick up the water boots
    private void grabWaterBoot()
    {
        if (canPickUp == true)
        {
            //Defines the boot button
            thisBootButton = WaterBootButton;
            //Turns on the boot button
            thisBootButton.SetActive(true);
            //Destroys the game object 
            Destroy(WaterBootItem);
            Debug.Log("Picked Up Water Boots");
        }
    }


    //Determines which boot this script is attatched to and picks them up
    private void grabThisBoot()
    {
        //If these boots are fire boots grab fire boots
        if(gameObject.tag == "FireBoots")
        {
            grabFireBoot();
        }
        //If these boots are water boots grab water boots
        if (gameObject.tag == "WaterBoots")
        {
            grabWaterBoot();
        }

    }
}
