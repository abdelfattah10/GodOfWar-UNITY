using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossController : MonoBehaviour
{
    public float LookRadius = 10f;
    private int RHcounter = 0;
    private int RLcounter = 0; 
    private int HeadCounter = 0;
    private bool Stunned = false;
    private bool isDead = false;
    private int attackCounter = 1;
    public Transform target;
    NavMeshAgent agent;
    public int health;
    public int damage;
    private float startTime;
    public Slider HealthBar;
    float movespeed = 5.0f;
    private int remainingHealth;
    public static Animator BossAnimator;
    public GameObject playerCube;
    // Use this for initialization
    void Start()
    {
        //target = PlayerManager.instance.transform;

        agent = GetComponent<NavMeshAgent>();
        BossAnimator = GetComponent<Animator>();
        

    }

    // Update is called once per frame
    void Update()
    {
      //  HealthBar.value = health;
        float distance = Vector3.Distance(target.position, transform.position);
        BossAnimator.SetBool("isIdle", true);
        BossAnimator.SetBool("isWalking", false);
        BossAnimator.SetBool("isHit", false);

        if (distance <= LookRadius)
        {
            BossAnimator.SetBool("isIdle", false);
            BossAnimator.SetBool("isWalking", true);
           BossAnimator.SetBool("Punch", false);
           BossAnimator.SetBool("Swipe", false);
            BossAnimator.SetBool("isHit", false);

            agent.SetDestination(target.position);

        }
        if (distance <= agent.stoppingDistance + 2)
        {
           
           // FaceTarget();
            startTime = Time.time;
           
            if (attackCounter == 1)
                   
                    
                {
                    Attack1();
                print(attackCounter);

            }
                else if (attackCounter == 2)
                {
                    Attack2();
                print(attackCounter);
            }
                else if (attackCounter==3)
                {
                    Attack3();
                print(attackCounter);
                   // attackCounter = 1;
                }            
        }
        else
        {
            //BossAnimator.SetBool("isIdle", false);
            //BossAnimator.SetBool("isWalking", true);
            //BossAnimator.SetBool("Punch", false);
            //BossAnimator.SetBool("Swipe", false);
        }

        //if (health < 70)
        //{
        //    BossAnimator.SetBool("isIdle", false);
        //    BossAnimator.SetBool("isWalking", false);
        //    BossAnimator.SetBool("Punch", false);
        //    BossAnimator.SetBool("Swipe", true);
        //    BossAnimator.SetBool("Combo", false);
        //}

        //if(health < 30)
        //{
        //    BossAnimator.SetBool("isIdle", false);
        //    BossAnimator.SetBool("isWalking", false);
        //    BossAnimator.SetBool("Punch", false);
        //    BossAnimator.SetBool("Swipe", false);
        //    BossAnimator.SetBool("Combo", true);
        //}
        if (health <= 0)
        {
            FindObjectOfType<AudioMaanager>().Play("win");

            isDead = true;
            // BossAnimator.SetBool("isHit", false);
            BossAnimator.SetBool("isIdle", false);
            BossAnimator.SetBool("isWalking", false);
            BossAnimator.SetBool("Punch", false);
            BossAnimator.SetBool("Swipe", false);
            BossAnimator.SetBool("Combo", false);
            BossAnimator.SetBool("isHit", false);
            BossAnimator.SetBool("isDead", true);
            agent.isStopped = true;


        }
        if (isDead == true)
        {

            StartCoroutine(Example());
           
        }

    }
    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookrotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookrotation, Time.deltaTime * 5f);
    }
    IEnumerator Example()
    {
        print(Time.time);
        FindObjectOfType<AudioMaanager>().Play("win");

        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Credits");
        
    }

    void Attack1()
    {
        BossAnimator.SetBool("isIdle", false);
        BossAnimator.SetBool("isWalking", false);
        BossAnimator.SetBool("Punch", true);
        BossAnimator.SetBool("Swipe", false);
        BossAnimator.SetBool("Combo", false);
        BossAnimator.SetBool("isHit", false);
        attackCounter++;

    }

    void Attack2()
    {
        BossAnimator.SetBool("isIdle", false);
        BossAnimator.SetBool("isWalking", false);
        BossAnimator.SetBool("Punch", false);
        BossAnimator.SetBool("Swipe", true);
        BossAnimator.SetBool("Combo", false);
        BossAnimator.SetBool("isHit", false);
        attackCounter++;

    }

    void Attack3()
    {
        BossAnimator.SetBool("isIdle", false);
        BossAnimator.SetBool("isWalking", false);
        BossAnimator.SetBool("Punch", false);
        BossAnimator.SetBool("Swipe", false);
        BossAnimator.SetBool("isHit", false);
        BossAnimator.SetBool("Combo", true);
        attackCounter = 1;
    }
        void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, LookRadius);
    }
    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.CompareTag("KratosArm"))
        {

            health -= 5;

            print(health);
            // BossAnimator.SetBool("isHit", true);

           // FindObjectOfType<AudioMaanager>().Play("hit");


        }
        else
        {
            BossAnimator.SetBool("isHit", false);
        }

        if (c.gameObject.CompareTag("RightHand"))
        {
          //  BossAnimator.SetBool("isHit", true);
            RHcounter++;
            print(RHcounter);
                if (RHcounter == 3)
            {
                BossAnimator.SetBool("isIdle", false);
                BossAnimator.SetBool("isWalking", false);
                BossAnimator.SetBool("Punch", false);
                BossAnimator.SetBool("Swipe", false);
                BossAnimator.SetBool("Combo", false);
                BossAnimator.SetBool("Agony", true);
                Stunned = true;
                
                health = health - 20;
                print(health);
            }
        }
        if (c.gameObject.CompareTag("RightLeg"))
        {
          //  BossAnimator.SetBool("isHit", true);
            RLcounter++;
            print(RLcounter);
            if (RLcounter == 3)
            {
                BossAnimator.SetBool("isIdle", false);
                BossAnimator.SetBool("isWalking", false);
                BossAnimator.SetBool("Punch", false);
                BossAnimator.SetBool("Swipe", false);
                BossAnimator.SetBool("Combo", false);
                BossAnimator.SetBool("Agony", true);
                Stunned = true;

                health = health - 20;
                print(health);
            }
        }
        if (c.gameObject.CompareTag("Head"))
        {
           // BossAnimator.SetBool("isHit", true);
            HeadCounter++;
            print(HeadCounter);
            if (HeadCounter == 3)
            {
                BossAnimator.SetBool("isIdle", false);
                BossAnimator.SetBool("isWalking", false);
                BossAnimator.SetBool("Punch", false);
                BossAnimator.SetBool("Swipe", false);
                BossAnimator.SetBool("Combo", false);
                BossAnimator.SetBool("Agony", true);
                Stunned = true;

                health = health - 20;
                print(health);
            }
        }
    }
}
