using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class DeathMenu : MonoBehaviour {

    public Text Scoree;
	// Use this for initialization
	void Start () {
        gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
       
	}
    public void ToggleMenu(int score)
    {
        gameObject.SetActive(true);
        Scoree.text = score.ToString();
   
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void toMenu()
    {
        SceneManager.LoadScene("MenuScene");

    }
}
