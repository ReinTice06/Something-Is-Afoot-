using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPots : MonoBehaviour
{
    public int speed = 1;

    //public GameObject Player;

    public bool playerInside = false;

    public GameObject _player;
    public GameObject _hazardCheck;
    public GameObject _MovePlayer;

    // Update is called once per frame

    private void Awake()
    {
        _player = GameObject.Find("Player");
        _hazardCheck = GameObject.Find("Hazard Check");
    }

    void Update()
    {
        

        if (playerInside)
        {
            _hazardCheck.GetComponent<Rigidbody>().isKinematic = false;
            //_player.transform.position = transform.position;
            
            
            //_player.transform.position += transform.forward * Time.deltaTime * speed;

            _player.transform.position += Vector3.forward * Time.deltaTime * speed;


            _MovePlayer.SetActive(true);


        }
        else
        {
            _hazardCheck.GetComponent<Rigidbody>().isKinematic = true;
            _MovePlayer.SetActive(false);
        }
        transform.position += transform.forward * Time.deltaTime * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("KillPots"))
        {
            Destroy(this.gameObject);
        }

        if (other.gameObject.tag == "Player")
        {
            //other.transform.SetParent(transform);
            //_player.transform.parent = transform;
            playerInside = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //other.transform.SetParent(null);
            //_player.transform.parent = null;
            playerInside = false;
        }
    }
}
