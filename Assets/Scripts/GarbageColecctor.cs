using UnityEngine;

public class GarbageColecctor : MonoBehaviour
{
    


    
    //DESTRUIR DESTRUIR DESTRUIR (destruye todo lo que toca, no diferencia nada)
    void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(col.gameObject);
    }
}
