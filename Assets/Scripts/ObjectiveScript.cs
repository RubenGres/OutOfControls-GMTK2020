using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveScript : MonoBehaviour
{
    public Animator animator;
    public float transitionDelayTime = 1.0f;
    public AudioSource audio;

    void OnTriggerEnter2D(Collider2D other)
    {
        audio.Play();
        DontDestroyOnLoad(audio);
        StartCoroutine(DelayLoadLevel());
    }

    IEnumerator DelayLoadLevel()
    {
        animator.SetTrigger("TriggerTransition");
        yield return new WaitForSeconds(transitionDelayTime);
        GameManager.nextLevel();
    }
}
