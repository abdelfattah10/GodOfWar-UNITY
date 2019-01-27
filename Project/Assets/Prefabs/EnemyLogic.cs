using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : MonoBehaviour {

    float distance = 0.0f;
    public Transform target;
    float lookAtDistance = 10.0f;
    float attackRange = 5.0f;
    float moveSpeed = 5.0f;
    float dampin = 6.0f;
    Material material;


    void Start () {
        material = GetComponent<Renderer>().material;
    }
	

	void Update () {

        distance = Vector3.Distance(target.position, transform.position);

        if(distance < lookAtDistance){
            material.color = Color.yellow;
            lookAt();
        }

        if(distance < attackRange){
            attack();
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
