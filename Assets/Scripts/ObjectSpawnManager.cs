using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
public class ObjectSpawnManager : MonoBehaviour
{
    [Header("Objects to Spawn")]
    public GameObject[] itemPrefab;

    [Header("Timers")]
    public float minTime = 1f;
    public float maxTime = 2f;
    void Start()
    {
        StartCoroutine(SpawnCoRoutine(0));   
    }
    //Corrutina que crea los objetos, empieza con 0 para crear objetos al instante
    //Talvez modifique esto luego
    IEnumerator SpawnCoRoutine(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Instantiate(itemPrefab[Random.Range(0, itemPrefab.Length)], transform.position, Quaternion.identity);
        StartCoroutine(SpawnCoRoutine(Random.Range(minTime, maxTime)));
    }

}
