using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
public class MainPManager : MonoBehaviour
{
    private bool isGrounded = true;
    private bool isAlive = true;
    private int walkIndex = 0;
    private int jumpIndex = 0;
    private int jumpsLeft = 0;
    private int coinsCollected = 1;
    private AudioSource myJumpSound;
    private AudioSource myBulletSound;
    private AudioSource myCollectableSound;
    private Coroutine coroutine;
    private Rigidbody2D myRigidbody2D;
    private SpriteRenderer mySpriteRenderer;

    [Header("Player Parameters")]
    public float playerJumpForce = 20f;
    public float playerSpeed = 5f;
    public int jumpLimit = 2; //si el limite es un numero negativo, los saltos son infinitos

    [Header("Player Sprites")]
    public Sprite[] mySprites;
    public Sprite[] myJumpSprites;
    public Sprite myDeadSprite;

    [Header("Time Between Frames")]
    public float waitAnimation = 0.05f;

    [Header("Player Bullet")]
    public GameObject Bullet;

    [Header("Player SFX's")]
    public AudioClip collectableSound;
    public AudioClip bulletSound;
    public AudioClip jumpSound;


    void Start()
    {
        myBulletSound = GetComponent<AudioSource>();
        myJumpSound = GetComponent<AudioSource>();
        myRigidbody2D = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        myCollectableSound = GetComponent<AudioSource>();
        coroutine = StartCoroutine(WalkRoutine());
    }

    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            Application.Quit(); // Cierra el juego en un build
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false; // Detiene el juego en el editor
            #endif
        }
        if (isAlive)
        {
            //Salto del jugador, si se acaban los saltos restantes se inhabilita el salto
            //Si jumpLimit inicia con un valor negativo, los saltos son infinitos
            if (Keyboard.current.spaceKey.wasPressedThisFrame && jumpsLeft != 0)
            {
                jumpsLeft--;
                myJumpSound.PlayOneShot(jumpSound, 1f);
                myRigidbody2D.linearVelocity = new Vector2(myRigidbody2D.linearVelocity.x, playerJumpForce);
            }
            myRigidbody2D.linearVelocity = new Vector2(playerSpeed, myRigidbody2D.linearVelocity.y);

            //Boton de disparo
            //Talvez tenga que nerfear la cantidad de disparos
            if (Keyboard.current.eKey.wasPressedThisFrame)
            {
                myBulletSound.PlayOneShot(bulletSound, 0.2f);
                Instantiate(Bullet, transform.position, Quaternion.identity);
            }
        }
        else
        {
            //Si el jugador muere, se cae y ya
            myRigidbody2D.linearVelocity = new Vector2(0, myRigidbody2D.linearVelocity.y);
        }

    }

    //Gana saltos al llegar a una plataforma
    //Inicia animación de caminar
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Plataforma"))
        {
            StopCoroutine(coroutine);
            isGrounded = true;
            coroutine = StartCoroutine(WalkRoutine());
            jumpsLeft = jumpLimit;
            jumpIndex = 0;
        }
    }

    //Inicia animación de salto
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Plataforma"))
        {
            StopCoroutine(coroutine);
            isGrounded = false;
            coroutine = StartCoroutine(JumpRoutine());
            walkIndex = 0;
        }
    }

    //Diferentes triggers, cada uno actua dependiendo del tag del objeto tocado
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Collectable"))
        {
            Destroy(col.gameObject);
            myCollectableSound.PlayOneShot(collectableSound, 0.2f);
            UIManager.instance.UpdateCoinText(coinsCollected); //Se actualiza la UI
        }
        if (col.gameObject.CompareTag("Enemy")) //El jugador muere si choca contra un enemigo
        {
            Destroy(GetComponent<BoxCollider2D>());
            isAlive = false;
            StopCoroutine(coroutine);
            mySpriteRenderer.sprite = myDeadSprite;
            jumpsLeft = 0;
            Debug.Log("El jugador chocó contra un enemigo! Perdió");
            StartCoroutine(DieRoutine());
            
        }
        if (col.gameObject.CompareTag("PlayerEnder")) //Adios jugador
        {
            jumpsLeft = 0;
        }
    }
    //Animacion de caminar
    IEnumerator WalkRoutine()
    {
        while (isGrounded)
        {
            yield return new WaitForSeconds(waitAnimation);
            mySpriteRenderer.sprite = mySprites[walkIndex];
            walkIndex++;
            if (walkIndex >= mySprites.Length)
            {
                walkIndex = 0;
            }
        }
    }
    //Animacion de salto
    IEnumerator JumpRoutine()
    {
        while (!isGrounded)
        {
            yield return new WaitForSeconds(waitAnimation);
            mySpriteRenderer.sprite = myJumpSprites[jumpIndex];
            jumpIndex += 1;
            if (jumpIndex >= myJumpSprites.Length)
            {
                jumpIndex = 0;
            }
        }
    }

    IEnumerator DieRoutine()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
}
