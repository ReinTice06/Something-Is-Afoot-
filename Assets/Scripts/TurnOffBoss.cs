using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffBoss : MonoBehaviour
{
    public Animator animator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            animator.SetBool("BossOn", false);
        }
    }
}
