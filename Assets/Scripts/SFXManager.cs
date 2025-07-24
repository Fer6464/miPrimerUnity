using UnityEngine;

public class MusicPlayerManager : MonoBehaviour
{
    public AudioClip soundFX;
    private AudioSource mySoundFX;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mySoundFX = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
   
}
