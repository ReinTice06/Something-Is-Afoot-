using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallProjectile : MonoBehaviour
{
    private float speed = 6f;
    public static Player player;
    Rigidbody rb;
    Vector3 FireDirection;

    private void Start()
    {
        //Finds balls rigidbody
        rb = GetComponent<Rigidbody>();
        //Finds player
        player = GameObject.FindObjectOfType<Player>();
        //Sets the fire direction to the players position
        FireDirection = (player.transform.position - transform.position).normalized * speed;
        //Sets velocity to go towards player
        rb.velocity = new Vector3(FireDirection.x, FireDirection.y, FireDirection.z);
        //Destroys game object after 9 seconds
        Destroy(gameObject, 9f);
    }
}
