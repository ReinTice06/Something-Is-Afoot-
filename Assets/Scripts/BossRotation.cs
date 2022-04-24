using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRotation : MonoBehaviour
{
    private float rotationAmount;

    private void Start()
    {
        StartCoroutine(Rotate());

    }

    private void Update()
    {
        rotationAmount = Random.Range(-359, 359);
    }

    IEnumerator Rotate()
    {
        WaitForSeconds wait = new WaitForSeconds(2);

        while (true)
        {

            transform.Rotate(Vector3.up * rotationAmount);

            yield return wait;
        }
    }
}
