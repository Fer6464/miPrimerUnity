using UnityEngine;

public class BulletMovement : MonoBehaviour
{

    public float bulletSpeed = 30f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector2.right * bulletSpeed * Time.deltaTime);

    }
    
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("TIRO AL BLANCO!");
            AnimationManager enemigo = col.gameObject.GetComponent<AnimationManager>();
            enemigo?.die();
            Destroy(col.gameObject, 5f);   
        }
    }
}
