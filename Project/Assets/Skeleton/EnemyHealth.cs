using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {

    public float startHealth = 50f;
    private float health;
    private int level;
    private static float requiredExp = 500f;
    public Image healthBar;

    public Image ExpBar;
    public Image RageBar;
    public Text LevelText;

    private float startTime;

    private Animator animator;

    private bool enemyDied = false;

    public SkeletonLogic SkeletonLogic;
    public SkeletonCombat SkeletonCombat;

    //public SpawnScript spawnn;

    void Start()
    {
        health = startHealth;
        animator = GetComponent<Animator>();
    }

    void ApplyDamage(int damage) {
        if (enemyDied == false)
        {
            health -= damage;
            healthBar.fillAmount = health / startHealth;


            RageBar.fillAmount += 0.2f;

            if (health <= 0)
            {
                ExpBar.fillAmount += 50 / requiredExp;
                if (ExpBar.fillAmount == 1.0f)
                {
                    level = int.Parse(LevelText.text);
                    level += 1;
                    requiredExp = requiredExp * 2;
                    LevelText.text = level.ToString();
                    ExpBar.fillAmount = 0.0f;
                }

                SkeletonLogic.enabled = false;
                SkeletonCombat.enabled = false;
                animator.SetBool("isAttacking", false);
                animator.SetBool("isIdle", false);
                animator.SetBool("isRunning", false);
                animator.SetBool("die", true);
                SpawnScript.countKills++;
                enemyDied = true;
                //Destroy(gameObject);

            }
        }
    }
	
	/*
	void Update () {
        if(health <= 0){
            Destroy(gameObject);
        }
	}
	*/
}
