using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour {

    public CharCtrl CharCtrl;
    public int damage1 = 10;
    public int damage2 = 30;
    private float distance;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
            {
                distance = hit.distance;
                //Debug.Log(distance);
                if (distance <= 2)
                {
                    if (!CharCtrl.rageActivated)
                    {
                        hit.transform.SendMessage("ApplyDamage", damage1, SendMessageOptions.DontRequireReceiver);
                    }
                    else
                    {
                        hit.transform.SendMessage("ApplyDamage", damage1 * 2, SendMessageOptions.DontRequireReceiver);
                    }
                }
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
            {
                distance = hit.distance;
                //Debug.Log(distance);
                if (distance <= 2)
                {
                    if (!CharCtrl.rageActivated)
                    {
                        hit.transform.SendMessage("ApplyDamage", damage2, SendMessageOptions.DontRequireReceiver);
                    }
                    else
                    {
                        hit.transform.SendMessage("ApplyDamage", damage2 * 2, SendMessageOptions.DontRequireReceiver);
                    }
                }
            }
        }
    }
}
