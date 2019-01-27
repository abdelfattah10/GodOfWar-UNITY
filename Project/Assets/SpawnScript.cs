using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnScript : MonoBehaviour {


    public GameObject waveOne;
    public GameObject waveTwo;
    public GameObject waveThree;


    public static int countKills = 0;
    int countWave = 0;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
    
        if (countWave == 0)
        {
            waveOne.active = true;
            if (countKills == 4)
            {
                waveOne.active = false;
                countWave++;
                countKills = 0;
            }
        }



        if (countWave == 1)
        {
            waveTwo.active = true;
            if (countKills == 4)
            {
                waveTwo.active = false;
                countWave++;
                countKills = 0;
            }
        }


        if (countWave == 2)
        {
            waveThree.active = true;
            if (countKills == 4)
            {
                waveThree.active = false;
                countWave++;
                countKills = 0;
                SceneManager.LoadScene("BOSS");
            }
        }

    }
}
