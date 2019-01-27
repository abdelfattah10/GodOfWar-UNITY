using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGameMenu : MonoBehaviour {
    public GameObject PauseUI;
    static public bool GameIsPaused;
	// Use this for initialization
    void Start()
    {
        PauseUI = GameObject.FindGameObjectWithTag("PauseHere");
        PauseUI.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                PauseUI.SetActive(true);
                Time.timeScale = 0f;
                GameIsPaused = true;
                
            }
            
        }
	}
    public void Resume()
    {
        PauseUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    public void toMenu()
    {
        SceneManager.LoadScene("MenuScene");
        Time.timeScale = 1f;
    }
    public void Restart()
    {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1f;
    }
}
