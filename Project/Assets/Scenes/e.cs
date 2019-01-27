using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e : MonoBehaviour
{

    public GameObject projectile;
    float start;

    void Start()
    {
        //animator = GetComponent<Animator>();
        start = Time.time;
    }


    void Update()
    {

        if (Time.time > start + 1.0f)
        {
            GameObject p = Instantiate(projectile, transform.position, transform.rotation);
            //p.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 10f));
            p.GetComponent<Rigidbody>().AddRelativeForce(transform.forward * 5000.0f);
            //hit.transform.SendMessage("ApplyDamage", damage, SendMessageOptions.DontRequireReceiver);
            //p.transform.Translate(Vector3.forward * 10.0f);
            start = Time.time;
        }
    }

}
