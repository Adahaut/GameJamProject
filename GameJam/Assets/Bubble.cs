using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        transform.localScale = Vector3.zero;
    }

    private void OnEnable()
    {
        animator.SetBool("Open", true);
    }

    public void Disable()
    {
        animator.SetBool("Open", false);
        transform.localScale = Vector3.zero;
        this.gameObject.SetActive(false);
    }

}
