using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sharkAttack : MonoBehaviour
{
    Animator animator;
    [SerializeField] GameObject shark;

    void Start()
    {
        animator = shark.GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            animator.SetBool("Attack", true);
        }
    }
}
