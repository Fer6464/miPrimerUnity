using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
public class TheEndlessNowManager : MonoBehaviour
{   
    private AudioSource mySoundFX;

    [Header("Dying Sounds")]
    public AudioClip[] soundFX;
    void Start()
    {
        mySoundFX = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("MainPlayer"))
        {
            int randomIndex = Random.Range(0, soundFX.Length);
            AudioClip actualSoundFX = soundFX[randomIndex];
            mySoundFX.PlayOneShot(actualSoundFX, 1f);
            StartCoroutine(RepeatAllRoutine());
            Debug.Log("El jugador cayó al vacio!");    
        }
    }

    //REINICIO TOTAL DEL JUEGO
    IEnumerator RepeatAllRoutine()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("The Cycle Continues");
    }
}
