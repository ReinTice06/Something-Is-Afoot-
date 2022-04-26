using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectile : MonoBehaviour
{
    //List of prefabed projectiles added in inspector
    public List<GameObject> prefabList = new List<GameObject>();

    public IEnumerator fireBall()
    {
        //Waits for end of frame
        yield return new WaitForEndOfFrame();
        //Picks a random projectile out of the list
        int prefabIndex = Random.Range(0, prefabList.Count);
        //Instantiates the random projectile
        GameObject ball = Instantiate(prefabList[prefabIndex]) as GameObject;
        //Sets position and rotation of projectile
        ball.transform.position = gameObject.transform.position;
        ball.transform.rotation = gameObject.transform.rotation;
    }

}
