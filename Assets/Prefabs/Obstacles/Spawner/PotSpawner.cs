using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotSpawner : MonoBehaviour
{
    public GameObject spawnObjectPrefab;

    [SerializeField]
    public GameObject pos;

    public float startDelay = 0f;
    public float spawnRate;

    private void Start()
    {
        InvokeRepeating("SpawnObject", startDelay, spawnRate);
    }

    void SpawnObject()
    {
        Instantiate(spawnObjectPrefab, transform.position, transform.rotation);
        //Instantiate(spawnObjectPrefab, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
    }



    //private void Start()
    //{
    //    StartCoroutine(SpawnObject());
    //}

    //IEnumerator SpawnObject()
    //{
    //    Instantiate(spawnObjectPrefab, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
    //    yield return new WaitForSeconds(2);
    //}
}
