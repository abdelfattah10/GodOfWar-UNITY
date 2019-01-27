using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardCombat : MonoBehaviour
{

    public int damage = 10;
    private float distance;
    private Animator animator;
    public GameObject projectile;
    float startTime;

    //public EnemyHealthWizard EnemyHealthWizard;

    void Start()
    {
        animator = GetComponent<Animator>();
        startTime = Time.time;
    }


    void Update()
    {
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 10, Color.green);
        //Debug.Log(animator.GetBool("isAttacking"));
        //if (animator.GetBool("isAttacking"))
        //Debug.Log(EnemyHealthWizard.enemyDied);
        if (true)
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
            {
                distance = hit.distance;

                if (distance <= 7 && hit.transform.tag == "Player")
                {
                    if (Time.time > startTime + 3.5f)
                    {
                        //animator.SetTrigger("attack");
                        GameObject p = Instantiate(projectile, transform.position, transform.rotation);
                        //p.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, -100f));
                        p.GetComponent<Rigidbody>().AddForce(transform.forward * 1000.0f);
                        //hit.transform.SendMessage("ApplyDamage", damage, SendMessageOptions.DontRequireReceiver);
                        //p.transform.Translate(Vector3.forward * 2.0f);
                        startTime = Time.time;
                    }
                }
            }
        }
    }
}
