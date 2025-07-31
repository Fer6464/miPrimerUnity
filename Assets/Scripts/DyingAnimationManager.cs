using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
public class DyingAnimationManager : MonoBehaviour
{
    [Header("Dying Animation Sprites")]
    public Sprite hitSprite;
    public Sprite[] dyingSprites;

    [Header("Time Between Frames")]
    public float waitAnimation = 0.05f;
    [Header("Fall Speed")]
    public float fallSpeed = 0;

    [Header("Dying SFX's")]
    public AudioClip[] soundFX;
    private AudioSource mySoundFX;
    private int index = 0;
    private Coroutine coroutine;
    private SpriteRenderer mySpriteRenderer;
    private Rigidbody2D rb;
    private bool isFalling = false;
    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        mySoundFX = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isFalling)
        {
            rb.linearVelocity = new Vector2(0,-fallSpeed);
        }
        
    }
    IEnumerator DieRoutine()
    {
        mySpriteRenderer.sprite = hitSprite;
        yield return new WaitForSeconds(0.5f);
        isFalling = !isFalling;
        while (true)
        {
            yield return new WaitForSeconds(waitAnimation);
            mySpriteRenderer.sprite = dyingSprites[index];
            index++;
            if (index >= dyingSprites.Length)
            {
                index = 0;
            }
        }
    }
    
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Bullet"))
        {
            int randomIndex = Random.Range(0, soundFX.Length);
            AudioClip actualSoundFX = soundFX[randomIndex];
            mySoundFX.PlayOneShot(actualSoundFX, 1f);
            StartCoroutine(DieRoutine());
            Destroy(GetComponent<PolygonCollider2D>());   
        }
    }
}
