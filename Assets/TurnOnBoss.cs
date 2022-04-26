using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnBoss : MonoBehaviour
{
    public Animator animator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            animator.SetBool("BossOn", true);
        }
    }
}
