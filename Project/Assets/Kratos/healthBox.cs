using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBox : MonoBehaviour {

    public Image healthBar;
    // Use this for initialization
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player")){
            if(CharStats.health < 100f){
                CharStats.health = CharStats.health + 30f;
                if(CharStats.health > 100){
                    CharStats.health = 100;
                }
                healthBar.fillAmount = CharStats.health / 100f;
                Destroy(gameObject);
            }
        }
    }
}
