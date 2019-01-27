using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour {
    bool audioedit = false;
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
        AudioTime = GameObject.FindGameObjectWithTag("Here");
        BackTo = GameObject.FindGameObjectWithTag("BackToMenu");
        AudioX = GameObject.FindGameObjectWithTag("AudioX");

	}
    public void AudioEdit()
    {
        CreditsButton.SetActive(false);
        // MuteSounds.SetActive(false);
        HowToPlayButton.SetActive(false);
        AudioX.SetActive(false);
        BackTo.SetActive(true);
        audioedit = true;
        gameObject.SetActive(true);

    }
	
	// Update is called once per frame
	void Update () {
        if (audioedit)
        {
            gameObject.SetActive(true);
        }
        if (!audioedit)
        {
            gameObject.SetActive(false);
        }

	}
    public void Back()
    {
        AudioX.SetActive(true);
        CreditsButton.SetActive(true);
        HowToPlayButton.SetActive(true);
        BackTo.SetActive(true);
        gameObject.SetActive(false);
        audioedit = false;
    }
}
