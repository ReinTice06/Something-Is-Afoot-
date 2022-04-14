using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    //Variables
    [SerializeField]
    private InputActionReference CameraControl;
    private float mouseScrollY;
    public float zoomSpeed = 30f;
    public float rotationSpeed = 1;
    public Transform Target, Player;
    float mouseX, mouseY;
    public GameObject checkPoints;

    


    //See through walls
    public Transform Obstruction;

    private void OnEnable()
    {
        CameraControl.action.Enable();
    }

    private void OnDisable()
    {
        CameraControl.action.Disable();
    }

    private void Awake()
    {
        CameraControl.action.performed += x => mouseScrollY = x.ReadValue<float>();
    }

    private void Start()
    {
        Obstruction = Target;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }

    private void LateUpdate()
    {
        //Camera Movement
        camControl();
        //MouseWheel Zoom
        zoom();
        ViewObstructed();
    }

    public void camControl()
    {

        //User Input
        mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * rotationSpeed;
        

        //Fix mouse on Y rotation
        mouseY = Mathf.Clamp(mouseY, -15, 60);

        //Focus Camera on player
        transform.LookAt(Target);

        //Control Rotation
        Target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
    }

    public void zoom()
    {
        //MouseWheel Zoom In 
        if (mouseScrollY > 0)
        {
            transform.Translate(Vector3.forward * zoomSpeed * Time.deltaTime);
        }
        //MouseWheel Zoom Out
        if (mouseScrollY < 0)
        {
            transform.Translate(Vector3.back * zoomSpeed * Time.deltaTime);
        }
        
    }

    //Cant get this to work
    void ViewObstructed()
    {
        RaycastHit hit;

        //Obstruction.gameObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;

        if (Physics.Raycast(transform.position, Target.position - transform.position, out hit, 7.5f))
        {
            
            //Makes sure the player isnt obstructing the camera
            if (hit.collider.tag == "Wall")
            {
                Obstruction = hit.transform;

                //Hides wall but allows shadows to still be present
                Obstruction.gameObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;
            }
            else
            {
                //Turns the wall back to visible
                Obstruction.gameObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
            }

        }

    }

    //Adjust sensitivity with slider in pause menu
    public void AdjustSensitivity(float newSensitivity)
    {
        rotationSpeed = newSensitivity;
    }
    //Adjust zoom sensitivity with slider in pause menu
    public void AdjustZoom(float newZoomSpeed)
    {
        zoomSpeed = newZoomSpeed;
    }

}
