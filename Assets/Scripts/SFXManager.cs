using UnityEngine;

public class MusicPlayerManager : MonoBehaviour
{
    //No se si siquiera uso este script, lo dejo por si las moscas
    public AudioClip soundFX;
    private AudioSource mySoundFX;
    void Start()
    {
        mySoundFX = GetComponent<AudioSource>();
    }
   
}
