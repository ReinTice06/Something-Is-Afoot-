using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotSpawner : MonoBehaviour
{
    //GameObjects
    public GameObject spawnObjectPrefab;

    [SerializeField]
    public GameObject pos;

    //switches plugin
    public Switch Switch1;
    public Switch Switch2;

    public float startDelay = 0f;
    public float spawnRate;

    public bool canSpawn = true;

    private void Start()
    {
        //InvokeRepeating("SpawnObject", startDelay, spawnRate);
    }

    private void Update()
    {
        if (Switch1.isOn && Switch2.isOn)
        {
            if (canSpawn)
            {
                //InvokeRepeating("SpawnObject", startDelay, spawnRate);
                RepeatSpawning();
                //canSpawn = false;
            }
        }
    }

    void RepeatSpawning()
    {
        InvokeRepeating("SpawnObject", startDelay, spawnRate);
        canSpawn = false;
    }


    void SpawnObject()
    {
        Instantiate(spawnObjectPrefab, transform.position, transform.rotation);
        
        //Instantiate(spawnObjectPrefab, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
        //canSpawn = false;
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
