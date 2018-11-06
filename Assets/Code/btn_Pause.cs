using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btn_Pause : MonoBehaviour {

    public GameObject canvas_EndLevel;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void buttonPause()
    {
        if (Time.timeScale != 0f)
        {
            Time.timeScale = 0f;
            canvas_EndLevel.SetActive(true);
        }

        else
        {
            Time.timeScale = 1f;
            canvas_EndLevel.SetActive(false);
        }
    }
}
