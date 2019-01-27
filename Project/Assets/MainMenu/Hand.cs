using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Hand : MonoBehaviour {
    public GameObject Backy;

	// Use this for initialization
	void Start () {
        Backy = GameObject.FindGameObjectWithTag("BackToMenu");

	}
    public void Back()
    {
        SceneManager.LoadScene("Options");
    }
	// Update is called once per frame
	void Update () {
		
	}
}
