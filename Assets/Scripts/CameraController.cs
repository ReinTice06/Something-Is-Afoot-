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
    public float cameraObstructionDistance = 70f;
    private bool minDist = false;
    private bool maxDist = false;
    private bool noMoreWall = false;

    public GameObject CameraPos;

    public List<Transform> currentwalls;

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
        CameraZoomDistance();
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
        //if (Distance <= MinDistance)
        //{
            if (mouseScrollY > 0)
            {
                transform.Translate(Vector3.forward * zoomSpeed * Time.deltaTime);
            }
        //}
        //MouseWheel Zoom Out
        //if (Distance >= MaxDistance)
        //{
            if (mouseScrollY < 0)
            {
                transform.Translate(Vector3.back * zoomSpeed * Time.deltaTime);
            }
        //}
        
    }

    //Cant get this to work
    void ViewObstructed()
    {
        RaycastHit hit;

        //Obstruction.gameObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;

        if (Physics.Raycast(transform.position, Target.position - transform.position, out hit, cameraObstructionDistance))
        {
            if (hit.collider.tag == "Wall")
            {
                //If a wall is in the way move camera towards player
                transform.position = Vector3.Lerp(transform.position, Target.position, Time.deltaTime * 2);

            }
            else
            {
                //If a wall is no longer in the way move camera back 
                if (Vector3.Distance(transform.position, Target.position) < 4f)
                {
                    transform.Translate(Vector3.back * Time.deltaTime * 2, Space.Self);
                }
            }
            ////Makes sure the player isnt obstructing the camera
            //if (hit.collider.tag == "Wall")
            //{
            //    //if (noMoreWall == false)
            //    //{
            //    //    noMoreWall = true;
            //        Obstruction = hit.transform;
            //    if (!currentwalls.Contains(Obstruction))
            //    {
            //        currentwalls.Add(Obstruction);
                
            //        foreach (Transform Obstruction in currentwalls)
            //        {
            //            //Hides wall but allows shadows to still be present
            //            Obstruction.gameObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;

            //        }
            //    }
            //}
            //else
            //{
            //    //noMoreWall = false;
            //    foreach (Transform Obstruction in currentwalls)
            //    {
            //        //Turns the wall back to visible
            //        Obstruction.gameObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
            //        currentwalls.Remove(Obstruction);

            //    }

            //}
        }

    }
    private void CameraZoomDistance()
    {
        if(minDist == true)
        {
            transform.Translate(Vector3.back * 20 * Time.deltaTime);
        }
        if (maxDist == true)
        {
            transform.Translate(Vector3.forward * 20 * Time.deltaTime);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "MinZoom")
        {
            minDist = true;
        }
        if (other.gameObject.tag == "MaxZoom")
        {
            maxDist = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "MinZoom")
        {
            minDist = false;
        }
        if (other.gameObject.tag == "MaxZoom")
        {
            maxDist = true;
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


    /// <summary>
    /// Trying to restrict camera scrolling movement
    /// </summary>

    //public float Distance;
    //public float MinDistance = 1;
    //public float MaxDistance = 10;
    //public GameObject Camera;

    //private void Update()
    //{
    //   Distance = Camera.transform.position.z - Player.position.z;
    //}

}
