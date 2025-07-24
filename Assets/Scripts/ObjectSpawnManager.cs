using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
public class ObjectSpawnManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is createdpublic GameObject[] itemPrefab;
    public GameObject[] itemPrefab;
    public float minTime = 1f;
    public float maxTime = 2f;
    public bool isEnemy = false;

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
    
    void Update()
    {
        
    }
}
