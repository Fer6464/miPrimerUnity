using UnityEngine;

public class GarbageColecctor : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(col.gameObject);
        //Debug.Log("GameObject2 collided with " + col.name);
    }
}
