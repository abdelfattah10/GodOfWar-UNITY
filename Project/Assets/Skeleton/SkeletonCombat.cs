using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonCombat : MonoBehaviour
{

    public int damage = 10;
    private float distance;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        //Debug.Log(animator.GetBool("isAttacking"));
        if (animator.GetBool("isAttacking"))
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
            {
                distance = hit.distance;

                if (distance <= 1.2)
                {
                    hit.transform.SendMessage("ApplyDamage", damage, SendMessageOptions.DontRequireReceiver);
                }
            }
        }
    }
}
