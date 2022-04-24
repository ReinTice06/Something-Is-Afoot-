using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRotation : MonoBehaviour
{
    private float rotationAmount;

    private void Start()
    {
        //Start Boss Rotation
        StartCoroutine(Rotate());

    }

    private void Update()
    {
        //Choose a random angle to rotate
        rotationAmount = Random.Range(-359, 359);
    }

    //Rotation coroutine
    IEnumerator Rotate()
    {
        WaitForSeconds wait = new WaitForSeconds(2);

        while (true)
        {
            //Rotate in the y axis by random angle
            transform.Rotate(Vector3.up * rotationAmount);

            yield return wait;
        }
    }
}
