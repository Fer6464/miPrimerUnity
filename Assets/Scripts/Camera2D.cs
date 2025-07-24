using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Camera2D : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Transform targetPlayer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(targetPlayer.position.x + 6f, 0, -10);
    }
}
