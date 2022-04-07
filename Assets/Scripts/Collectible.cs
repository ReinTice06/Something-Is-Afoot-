/*
* Author: Tice, Rein
* Date: [10/27/2021]
* [Simply rotates the Collectible pieces]
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(0, 0, 50 * Time.deltaTime);
    }
}
