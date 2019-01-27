using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CharStats : MonoBehaviour
{

    private Animator animator;

    private float startHealth = 100f;
    public static float health;
    public Image healthBar;
    public Image ExpBar;
    public Image RageBar;
    public Text LevelText;

    public bool isDied = false;



    void Start()
    {
        health = startHealth;
        //int level = int.Parse(LevelText.text);
        animator = GetComponent<Animator>();
    }

    void ApplyDamage(int damage)
    {
        health -= damage;
        healthBar.fillAmount = health / startHealth;

        if (health <= 0)
        {
            //Destroy(gameObject);
            isDied = true;
            animator.SetBool("died", true);
        }
    }
/*
    void Update () {

    }
*/
}
