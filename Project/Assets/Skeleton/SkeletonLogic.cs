using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonLogic : MonoBehaviour {

    //float distance = 0.0f;
    public Transform target;
    //float lookAtDistance = 10.0f;
    //float attackRange = 5.0f;
    float moveSpeed = 5.0f;
    //float dampin = 6.0f;
    //Material material;
    int attackRepeatTime = 3;
    float attackTime;

    private Animator animator;

    public CharStats CharStats;

    void Start () {
        animator = GetComponent<Animator>();
        attackTime = Time.time;
    }


    void Update () {

        if (CharStats.isDied == false)
        {

            if (Vector3.Distance(target.position, transform.position) < 9)
            {
                Vector3 direction = target.position - transform.position;
                direction.y = 0;
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * 5.0f);

                if (direction.magnitude > 1.5)
                {
                    transform.Translate(0, 0, moveSpeed * Time.deltaTime);
                    animator.SetBool("isIdle", false);
                    animator.SetBool("isRunning", true);
                    animator.SetBool("isAttacking", false);
                }
                else
                {
                    animator.SetBool("isRunning", false);
                    if (Time.time > attackTime)
                    {
                            animator.SetBool("isAttacking", true);
                            attackTime = Time.time + attackRepeatTime;
                    }
                    else
                    {
                        animator.SetBool("isAttacking", false);
                    }
                }
            }
            else
            {
                animator.SetBool("isIdle", true);
                animator.SetBool("isRunning", false);
                animator.SetBool("isAttacking", false);
            }
        } else {
            animator.SetBool("isIdle", true);
            animator.SetBool("isAttacking", false);
            animator.SetBool("isRunning", false);
        }
    }


    void lookAt(){
        //Vector3 relativePos = target.position - transform.position;
        //transform.rotation = Quaternion.LookRotation(relativePos);
        transform.rotation = Quaternion.Slerp(transform.rotation, target.localRotation, Time.deltaTime);
    }

    void attack(){
        //transform.position = target.position + new Vector3(-1, 0, -1);
        //transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
    }
}
