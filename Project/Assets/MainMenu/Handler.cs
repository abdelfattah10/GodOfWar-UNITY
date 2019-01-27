using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Handler : MonoBehaviour {
    bool textactive = false;
    public GameObject CreditsButton;
    public GameObject HowToPlayButton;
    public GameObject BackTo;
    public GameObject AudioTime;
    public GameObject AudioX;//audiobutton
	// Use this for initialization
	void Start () {
        gameObject.SetActive(false);
        CreditsButton = GameObject.FindGameObjectWithTag("Credits");
        HowToPlayButton = GameObject.FindGameObjectWithTag("HowToPlay");
        BackTo = GameObject.FindGameObjectWithTag("BackToMenu");
        AudioX = GameObject.FindGameObjectWithTag("AudioX");


    }
	
	// Update is called once per frame
	void Update () {
        if (textactive)
        {
            gameObject.SetActive(true);
        }
        if (!textactive)
        {
            gameObject.SetActive(false);
        }
       
	}
    public void HowToPlayActive()
    {
        CreditsButton.SetActive(false);
        BackTo.SetActive(false);
        HowToPlayButton.SetActive(false);
        gameObject.SetActive(true);
        AudioX.SetActive(false);
        textactive = true;
    }
    
    public void Back()
    {
        CreditsButton.SetActive(true);
        AudioX.SetActive(true);
        HowToPlayButton.SetActive(true);
        BackTo.SetActive(true);
        gameObject.SetActive(false);
        textactive = false;
    }
    public void AudioEdit()
    {
        CreditsButton.SetActive(false);
       
        HowToPlayButton.SetActive(false);
        AudioX.SetActive(false);
        BackTo.SetActive(true);
       

    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
    public void toCredit()
    {
        SceneManager.LoadScene("Credits");
    }
}
