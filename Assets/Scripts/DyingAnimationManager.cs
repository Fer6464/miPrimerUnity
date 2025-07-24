using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
public class DyingAnimationManager : MonoBehaviour
{

    public Sprite hitSprite;
    public Sprite[] dyingSprites;
    public AudioClip soundFX;
    public float fallSpeed = 0;
    private AudioSource mySoundFX;
    public float waitAnimation = 0.05f;
    private int index = 0;
    private Coroutine coroutine;
    private SpriteRenderer mySpriteRenderer;
    private Rigidbody2D rb;
    private bool isFalling = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        mySoundFX = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
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
            mySoundFX.PlayOneShot(soundFX, 1f);
            StartCoroutine(DieRoutine());
        }
    }
}
