using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveScript : MonoBehaviour
{
    public Animator animator;
    public float transitionDelayTime = 1.0f;


    void OnTriggerEnter2D(Collider2D other)
    {
        StartCoroutine(DelayLoadLevel());
    }

    IEnumerator DelayLoadLevel()
    {
        animator.SetTrigger("TriggerTransition");
        yield return new WaitForSeconds(transitionDelayTime);
        GameManager.nextLevel();
    }
}
