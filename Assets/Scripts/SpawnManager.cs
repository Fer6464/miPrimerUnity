using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnManager : MonoBehaviour
{
    //Que no ya tenia un spawn manager
    //Por si acaso mejor no borro este script
    [Header("Objects to Spawn")]
    public GameObject[] itemPrefab;
    public float minTime = 1f;
    public float maxTime = 2f;
    
    void Start()
    {
        StartCoroutine(SpawnCoRoutine(0));   
    }

    IEnumerator SpawnCoRoutine(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Instantiate(itemPrefab[Random.Range(0, itemPrefab.Length)], transform.position, Quaternion.identity);
        StartCoroutine(SpawnCoRoutine(Random.Range(minTime, maxTime)));
    }

}
