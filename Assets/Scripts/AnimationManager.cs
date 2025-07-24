using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
public class AnimationManager : MonoBehaviour
{
    public Sprite[] mySprites;
    private SpriteRenderer mySpriteRenderer;
    public float waitAnimation = 0.05f;
    private bool isAlive = true;
    private int index = 0;
    private Coroutine walkcoroutine;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        walkcoroutine = StartCoroutine(WalkRoutine());
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void die()
    {
        StopCoroutine(walkcoroutine);
        isAlive = !isAlive;
    }
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
