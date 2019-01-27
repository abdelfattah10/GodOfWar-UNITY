using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rangeSpell : MonoBehaviour {


    void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Player"){
            collision.transform.SendMessage("ApplyDamage", 10, SendMessageOptions.DontRequireReceiver);
            Destroy(gameObject);
        } else {
            Destroy(gameObject);
        }
    }
}
