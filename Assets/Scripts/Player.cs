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

    //GameObjects
    public GameObject playerBody;
    public GameObject thePlayer;
    public Text CollectiblesText;

    //Bools
    private bool isGrounded;    
    private bool isRespawning;
    private bool playerDied = false;
    private bool isCrouched = false;
    public bool crouching = false;

    //Floats
    public float currentSpeed;
    [SerializeField]
    public float playerSpeed = 4.0f;   
    [SerializeField]
    private float jumpHeight = 1.0f;
    [SerializeField]
    private float gravityValue = -9.81f;
    [SerializeField]
    public float crouchSpeed = 2.0f;
    [SerializeField]
    private float rotationSpeed = 4f;
    [SerializeField]
    public int collectedCollectibles = 0;
    
    //Scripts
    public Boots theBoots;
    public CharacterController controller;
    public animationController crouchAnimator;
    private Transform cameraMainTransform;

    //Vector 3
    private Vector3 playerVelocity;
    private Vector3 respawnPoint;

    //Collectables


    private void OnEnable()
    {
        movementControl.action.Enable();
        jumpControl.action.Enable();
        crouchControl.action.Enable();
    }

    private void OnDisable()
    {
        movementControl.action.Disable();
        jumpControl.action.Enable();
        crouchControl.action.Enable();
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
        playerMovement();
    }
    private void LateUpdate()
    {
        checkForPower();
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
            playerVelocity.y = 0f;
        }

        if (jumpControl.action.triggered && isGrounded)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
    
    //When Player collides with Collectible it dissapears and shows up on the UI
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Collectible")
        {
            collectedCollectibles++;
            other.gameObject.SetActive(false);
            CollectiblesText.text = "Collectibles: " + collectedCollectibles;
        }

        //if (other.gameObject.tag == "TextPopup")
        //{
        //    GameObject text = GameObject.FindGameObjectWithTag("TextPopup");
        //    text.GetComponent<MeshRenderer>().enabled = true;
        //    //Debug.Log("Did I get in here?");
        //}
    }

    //Gets rid of the text once you leave the sphere
    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.tag == "TextPopup")
    //    {
    //        GameObject text = GameObject.FindGameObjectWithTag("TextPopup");
    //        text.GetComponent<MeshRenderer>().enabled = false;
    //    }

    //}

    //Checks Boot Power Level
    public void checkForPower()
    {
        //Respawns the player if current boot health is at 0
        if (Boots.currentPower <= 0)
        {
            playerDied = true;
            Debug.Log("Power is at 0");

            //Respawn the player
            Respawn();
            Debug.Log("Player has been respawned");
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
}
