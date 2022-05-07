using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWalkers : MonoBehaviour
{
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * 3f;
    }
}
