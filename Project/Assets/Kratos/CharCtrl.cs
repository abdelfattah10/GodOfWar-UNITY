using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharCtrl : MonoBehaviour {


    [SerializeField]
    private Animator animator;
    [SerializeField]

    private ParticleSystem rage;
    public bool rageActivated = false;
    public Image RageBar;

    public float speed = 5.0f;

    int attackRepeatTime = 1;
    float attackTime;

    float startTime;
    float waitInSeconds = 5.0F;

    float start1;

    void Start () {
        animator = GetComponent<Animator>();
        attackTime = Time.time;
    }
	

	void Update () {

        float translation = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetFloat("movementSpeed", 1.0f);
            transform.Translate(0, 0, translation * speed * Time.deltaTime);
        } else {
            animator.SetFloat("movementSpeed", 0.0f);
            transform.Translate(0, 0, translation * (speed * 0.5f) * Time.deltaTime);
        }

        if (Input.GetButtonDown("Jump")){
            animator.SetTrigger("isJumping");
        }

        if(translation != 0){
            animator.SetBool("isMoving", true);
        } else {
            animator.SetBool("isMoving", false);
        }

        if ((Input.GetMouseButtonDown(0)) && (animator.GetBool("isJumping") == false) && (animator.GetBool("isAttacking2") == false))
        {

            //if (Time.time > attackTime)
            //{
            if (Time.time > start1)
            {
                animator.SetTrigger("isAttacking");
                start1 = Time.time + 0.8f;
            }
              //  attackTime = Time.time + attackRepeatTime;
            //}
        }
        if ((Input.GetMouseButtonDown(1)) && (animator.GetBool("isJumping") == false) && (animator.GetBool("isAttacking") == false))
        {
            //if (Time.time > attackTime)
            //{
            if (Time.time > start1)
            {
                animator.SetTrigger("isAttacking2");
                start1 = Time.time + 0.8f;
            }
            //  attackTime = Time.time + attackRepeatTime;
            //}
        }

        if (Input.GetKeyDown(KeyCode.R)){
            if (RageBar.fillAmount == 1.0f)
            {
                rageActivated = true;
                RageBar.fillAmount = 0.0f;
                startTime = Time.time;

            }
        }

        if(rageActivated == true){
            rage.Emit(1);
             
            if(Time.time > startTime + waitInSeconds){
                rageActivated = false;
            }
        }

    }
}
