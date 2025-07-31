using UnityEngine;

public class EnemyMovementManager : MonoBehaviour
{
    private Rigidbody2D myRigidbody2D;
    private bool isAlive = true;
    private int numeroAleatorio = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        numeroAleatorio = Random.Range(-10, 0);
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isAlive){
            myRigidbody2D.linearVelocity = new Vector2(numeroAleatorio, myRigidbody2D.linearVelocity.y);
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Bullet"))
        {
            //isAlive = false;
            numeroAleatorio = 0;
        }
    }
}
