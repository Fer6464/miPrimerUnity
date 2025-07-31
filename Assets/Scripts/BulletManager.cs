using UnityEngine;

public class BulletMovement : MonoBehaviour
{

    public float bulletSpeed = 30f;
    private int enemiesKilled = 1;

    //Movimiento de la bala (linea recta)
    void Update()
    {
        transform.Translate(Vector2.right * bulletSpeed * Time.deltaTime);
    }

    //Trigger que detecta si chocó contra un enemigo
    //Si lo hizo, eliminará al enemigo pero la bala se autodestruye
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("TIRO AL BLANCO!");
            AnimationManager enemigo = col.gameObject.GetComponent<AnimationManager>();
            enemigo?.die();
            UIManager.instance.UpdateEnemyText(enemiesKilled); //Actualizar UI
            Destroy(col.gameObject, 5f);
            Destroy(gameObject);
        }
        if (col.gameObject.CompareTag("Collectable"))
        {
            
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
    }
}
