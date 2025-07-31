using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Camera2D : MonoBehaviour
{
    //no recuerdo que era esto
    public Transform targetPlayer;
    
    void Update()
    {
        transform.position = new Vector3(targetPlayer.position.x + 6f, 0, -10); //La cámara sigue al jugador, creo
    }
}
