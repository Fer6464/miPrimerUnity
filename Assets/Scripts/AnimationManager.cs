using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
public class AnimationManager : MonoBehaviour
{
    
    private SpriteRenderer mySpriteRenderer;
    private bool isAlive = true;
    private int index = 0;
    private Coroutine walkcoroutine;
    [Header("Animation Frames")]
    public Sprite[] mySprites;
    [Header("Time Between Frames")]
    public float waitAnimation = 0.05f;

    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        walkcoroutine = StartCoroutine(WalkRoutine());
    }
    public void die()
    {
        StopCoroutine(walkcoroutine);
        isAlive = !isAlive;
    }
    //Animaciones para el enemigo y la moneda
    IEnumerator WalkRoutine()
    {
        while (isAlive)
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
