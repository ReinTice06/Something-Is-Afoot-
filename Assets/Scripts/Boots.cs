using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
using UnityEngine.UI;



public class Boots : MonoBehaviour
{
    public static bool BootWheelIsActive = false;
    public GameObject bootWheelUI;
    public GameObject FireButton;
    public GameObject WaterButton;

    //Boot Variables
    public static float maxPower = 100;
    public static float currentPower;
    public static bool baseBoot;
    public static bool fireBoot;
    public static bool waterBoot;
    public static float baseBPower;
    public static float fireBPower;
    public static float waterBPower;
    //Materials
    public Material baseBootMat;
    public Material fireBootMat;
    public Material waterBootMat;
    //Game Objects
    public GameObject leftBoot;
    public GameObject rightBoot;
    public Image powerBarColor;
    public Renderer LbootRend;
    public Renderer RbootRend;
    


    public PowerBar powerBar;
    public Player thePlayer;
    public HazardCheck hazardCheck;

    [SerializeField]
    public InputActionReference bootControl;

    

    private void OnEnable()
    {
        bootControl.action.Enable();
    }

    private void OnDisable()
    {
        bootControl.action.Disable();

    }

    private void Awake()
    {
        //Starts with Base Boots
        BaseBootButton();
    }
    // Start is called before the first frame update
    void Start()
    {
        thePlayer.currentSpeed = thePlayer.runSpeed;

        //Sets power level to full
        SetBootPower();

        //Turn off Fire and Water boot button
        FireButton.SetActive(false);
        WaterButton.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        bootCheck();
        
    }
    //Boot Check
    public void bootCheck()
    {
        //Checks if boot wheel is already on the screen
        if (BootWheelIsActive == false)
        {
            
            //Opens up the boot wheel
            bootControl.action.performed += context =>
            {
                //Unocks Cursor
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;

                //Opens boots
                OpenBoots();
                BootWheelIsActive = true;
            };

            //Closes the boot wheel
            bootControl.action.canceled += context =>
            {
                //Locks Cursor
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;

                //Closes boots
                CloseBoots();
                BootWheelIsActive = false;
            };
        }

    }

    //Base boot button
    public void BaseBootButton()
    {
        //Turns on base boots
        baseBoot = true;
        //Sets power bar to base boot power bar
        currentPower = baseBPower;
        GetComponent<Boots>().powerBar.SetPower(Boots.baseBPower);
        //Changes boots material
        leftBoot.GetComponent<Renderer>().material = baseBootMat;
        rightBoot.GetComponent<Renderer>().material = baseBootMat;

        //Turns off other boots
        fireBoot = false;
        waterBoot = false;

        Debug.Log("Selected base boots");
    }

    //Fire boot button
    public void FireBootButton()
    {
        //Ensures sprint is inactive
        StopCoroutine(hazardCheck.BaseBootDamage());
        //Turns on fire boots
        fireBoot = true;
        //Sets power bar to fire boot power bar
        currentPower = fireBPower;
        GetComponent<Boots>().powerBar.SetPower(Boots.fireBPower);
        //Changes boots material
        LbootRend.material = fireBootMat;
        RbootRend.material = fireBootMat;

        //Turns off other boots
        baseBoot = false;
        waterBoot = false;

        Debug.Log("Selected fire boots");

    }

    //Water boot button
    public void WaterBootButton()
    {
        //Ensures sprint is inactive
        StopCoroutine(hazardCheck.BaseBootDamage());
        //Turns on water boots
        waterBoot = true;
        //Sets power bar to water power bar
        currentPower = waterBPower;
        GetComponent<Boots>().powerBar.SetPower(Boots.waterBPower);
        //Changes boots material
        leftBoot.GetComponent<Renderer>().material = waterBootMat;
        rightBoot.GetComponent<Renderer>().material = waterBootMat;

        //Turns off other boots
        fireBoot = false;
        baseBoot = false;

        Debug.Log("Selected water boots");

    }

    //Opens boot wheel and slows down time
    public void OpenBoots()
    {
        bootWheelUI.SetActive(true);
        Time.timeScale = .2f;
        BootWheelIsActive = true;
    }

    //Closes boot wheel and sets time back to 1    
    public void CloseBoots()
    {
        bootWheelUI.SetActive(false);
        Time.timeScale = 1f;
        BootWheelIsActive = false;
    }

    //Set all boots to Max Power
    public void SetBootPower()
    {
        //Sets Boots power to the max power
        waterBPower = maxPower;
        fireBPower = maxPower;
        baseBPower = maxPower;
        currentPower = maxPower;
        powerBar.SetPower(currentPower);

    }
    
    //Charges boots and sets power bar correctly
    public void ChargeCurrentBoot()
    {
        if(waterBoot == true)
        {
            if (waterBPower <= maxPower)
            {
                waterBPower += 5;
                powerBar.SetPower(Boots.waterBPower);
            }
        }
        if (fireBoot == true)
        {
            if (fireBPower <= maxPower)
            {
                fireBPower += 5;
                powerBar.SetPower(Boots.fireBPower);
            }
        }
        if (baseBoot == true)
        {
            if (baseBPower <= maxPower)
            {
                baseBPower += 5;
                powerBar.SetPower(Boots.baseBPower);
            }
        }
    }

    //Set power loss
    public void losePower(int powerLoss)
    {
        currentPower -= powerLoss;

        
    }

}
