using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
public class script : MonoBehaviour
{

    public float playerJumpForce = 20f;
    public float playerSpeed = 5f;
    public Sprite[] mySprites;
    private int index = 0;
    private int jump = 0;

    private Rigidbody2D myRigidbody2D;
    
    public AudioClip jumpSound;
    private AudioSource myJumpSound;
    public AudioClip bulletSound;
    private AudioSource myBulletSound;
    private SpriteRenderer mySpriteRenderer;
    private bool isWalking = true;
    public GameObject Bullet;
    public float waitAnimation = 0.05f;
    //public GameManager myGameManager;


    void Start()
    {
        myBulletSound = GetComponent<AudioSource>();
        myJumpSound = GetComponent<AudioSource>();
        myRigidbody2D = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(WalkRoutine());
        //myGameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame && jump < 2)
        {
            jump++;
            myJumpSound.PlayOneShot(jumpSound, 1f);
            myRigidbody2D.linearVelocity = new Vector2(myRigidbody2D.linearVelocity.x, playerJumpForce);
        }
        myRigidbody2D.linearVelocity = new Vector2(playerSpeed, myRigidbody2D.linearVelocity.y);

        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            myBulletSound.PlayOneShot(bulletSound, 0.2f);
            Instantiate(Bullet, transform.position, Quaternion.identity);

        }        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Plataforma"))
        {
            jump = 0;
        }
    }
    IEnumerator WalkRoutine()
    {
        while (isWalking)
        {
            yield return new WaitForSeconds(waitAnimation);
            mySpriteRenderer.sprite = mySprites[index];
            index++;
            if (index >= mySprites.Length)
            {
                index = 0;
            }
        }
    }
}
