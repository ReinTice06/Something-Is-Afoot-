using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    //Input Actions
    [SerializeField]
    private InputActionReference movementControl;
    [SerializeField]
    private InputActionReference jumpControl;
    [SerializeField]
    private InputActionReference crouchControl;
    [SerializeField]
    private InputActionReference runControl;

    //GameObjects
    public GameObject playerBody;
    public GameObject thePlayer;
    public GameObject sprintDust;
    public Text CollectiblesText;
    public Text UiRoom;
    public CameraShake cameraShake;

    //Bools
    public bool isGrounded;    
    private bool isRespawning;
    public bool playerDied = false;
    private bool isCrouched = false;
    public bool crouching = false;
    public bool sprintCoIsRunning = false;

    //Floats
    public float currentSpeed;
    [SerializeField]
    public float runSpeed = 7.0f;
    [SerializeField]
    public float crouchSpeed = 2.0f;
    [SerializeField]
    public float playerSpeed = 4.0f;   
    [SerializeField]
    private float jumpHeight = 1.0f;
    [SerializeField]
    private float gravityValue = -9.81f;
    [SerializeField]
    private float rotationSpeed = 4f;
    [SerializeField]
    public int collectedCollectibles = 0;
    
    //Scripts
    public Boots theBoots;
    public HazardCheck hazardCheck;
    public CharacterController controller;
    public animationController crouchAnimator;
    private Transform cameraMainTransform;
    Coroutine deathAnim;

    //Vector 3
    private Vector3 playerVelocity;
    private Vector3 respawnPoint;
    private Vector3 jumpDirection;


    Coroutine baseBootDamage;
    //Collectables


    private void OnEnable()
    {
        movementControl.action.Enable();
        jumpControl.action.Enable();
        crouchControl.action.Enable();
        runControl.action.Enable();
    }

    private void OnDisable()
    {
        movementControl.action.Disable();
        jumpControl.action.Enable();
        crouchControl.action.Enable();
        runControl.action.Enable();
    }

    private void Awake()
    {
        //sprintDust = GameObject.Find("SprintDust");
        //sprintDust = transform.Find("");
        //sprintDust = GetChildWithName(GameObject sprintDust, string "SprintDust");
    }

    // Start is called before the first frame update
    void Start()
    {
        //Locks Cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        controller = gameObject.GetComponent<CharacterController>();
        cameraMainTransform = Camera.main.transform;

        //Sets start point to respawn point
        respawnPoint = transform.position;

        //Sets player speed
        currentSpeed = playerSpeed;

        

    }

    // Update is called once per frame
    void Update()
    {
        if (!playerDied)
        {
            playerMovement();
        }

        speedCheck();
        baseBoost();
        checkForPower();
        SprintDust();
    }
    private void LateUpdate()
    {
        
    }

    //Player Movement
    public void playerMovement()
    {
        Vector2 movement = movementControl.action.ReadValue<Vector2>();
        Vector3 move = new Vector3(movement.x, 0f, movement.y);
        move = cameraMainTransform.forward * move.z + cameraMainTransform.right * move.x;
        move.y = -0.00001f;
        controller.Move(move * Time.deltaTime * currentSpeed);

        //Actually moves the player
        transform.Translate(move, Space.Self);

        //Jump
        jump();

        //Rotation of player
        if (movement != Vector2.zero)
        {
            float targetAngle = Mathf.Atan2(movement.x, movement.y) * Mathf.Rad2Deg + cameraMainTransform.eulerAngles.y;
            Quaternion rotation = Quaternion.Euler(0f, targetAngle, 0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);

        }

        //Crouch Mechanic
        if (isCrouched == false)
        {
            //Player Crouches
            crouchControl.action.performed += context =>
            {
                crouching = true;
                crouchAnimator.crouch();
            };
            //Player stands
            crouchControl.action.canceled += context =>
            {
                crouching = false;
                crouchAnimator.stand();
            };
        }
        

    }
    //Jump
    public void jump()
    {
        isGrounded = controller.isGrounded;
        if (isGrounded && playerVelocity.y < 0)
        {
            //Pushes player down to ensure isgrounded is always true when grounded
            playerVelocity.y = -gravityValue * Time.deltaTime;
        }
        
        if (jumpControl.action.triggered && isGrounded)
        {
            //Start lunge coroutine
            StartCoroutine(lunge());
            //Jumps the player
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
    //Lunge coroutine
    IEnumerator lunge()
    {
        //Finds direction player is facing when jump is pressed
        jumpDirection = (transform.forward);
        //Lunges towards jump position
        playerVelocity += jumpDirection * 2;
        //Waits to land
        yield return new WaitForSeconds(1.1f);
        //subtracts previous force
        playerVelocity -= jumpDirection * 2;

        yield return null;
    }

    //Run control for base boots
    public void baseBoost()
    {
        //If base boots are worn
        if (Boots.baseBoot == true)
        {
            if (Boots.baseBPower >= 10)
            {

                //If button is pressed allow sprint
                runControl.action.performed += context =>
                {
                    if (Boots.baseBoot == true)
                    {
                        //Debug.Log("Sprinting");
                        hazardCheck.runBoost = true;

                        //Shakes the camera when starting to sprint
                        //StartCoroutine(cameraShake.Shake(.15f, .1f));

                        //Coroutine damage while running
                        if (sprintCoIsRunning == false)
                        {
                            baseBootDamage = StartCoroutine(hazardCheck.BaseBootDamage());
                            sprintCoIsRunning = true;
                        }
                    }

                };
                //If button is not pressed don't allow sprint
                runControl.action.canceled += context =>
                {
                    //Debug.Log("Walking");
                    hazardCheck.runBoost = false;
                    if (sprintCoIsRunning == true)
                    {
                        //Stop coroutine damage 
                        if (baseBootDamage != null)
                        {
                            StopCoroutine(baseBootDamage);
                        }
                        sprintCoIsRunning = false;
                    }
                };

            }
        }
    }


    //Speed Check
    public void speedCheck()
    {
        //Sets Crouch Speed
        if (crouching == true)
        {
            currentSpeed = crouchSpeed;
        }
        else
        {
            //Checks if base boots are active pressing run and has power
            if (Boots.baseBoot == true && hazardCheck.runBoost == true && Boots.baseBPower >= 10)
            {
                //Gives speed boost
                currentSpeed = runSpeed;
            }
            else
            {
                //No speed boost
                currentSpeed = playerSpeed;
            }
            
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        //When Player collides with Collectible it dissapears and shows up on the UI
        if (other.gameObject.tag == "Collectible")
        {
            collectedCollectibles++;
            other.gameObject.SetActive(false);
            CollectiblesText.text = "Collectibles: " + collectedCollectibles;
        }
        //Dsiplays name of gameobject on UI on trigger enter
        if(other.gameObject.tag == "UIRoom")
        {
            UiRoom.text = other.name;
        }
    }

    
    //Checks Boot Power Level
    public void checkForPower()
    {
        //Respawns the player if current boot health is at 0
        if (Boots.currentPower <= 0)
        {
            //StopAllCoroutines();
            playerDied = true;
            //Triggers Death Animation which respawns player
            crouchAnimator.animator.SetTrigger("Death");
        }
        else
        {
            //Ensures death animation only happens when dead
            crouchAnimator.animator.ResetTrigger("Death");
        }
    }

    //Respawn Function
    public void Respawn()
    {
        if (playerDied == true)
        {
            thePlayer.transform.position = respawnPoint;
            theBoots.SetBootPower();
        }
        playerDied = false;
    }

    public void SetSpawnPoint (Vector3 newPosition)
    {
        respawnPoint = newPosition;
    }

    private void SprintDust()
    {
        if (sprintCoIsRunning)
        {
            sprintDust.SetActive(true);
        }
        else
        {
            sprintDust.SetActive(false);
        }
    }
}
