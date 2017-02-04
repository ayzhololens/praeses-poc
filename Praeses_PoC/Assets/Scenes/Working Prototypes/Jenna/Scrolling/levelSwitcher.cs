using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelSwitcher : MonoBehaviour {
    int levelCounter;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void loadNextLevel()
    {
        levelCounter += 1;
        if (levelCounter > 1)
        {
            levelCounter = 0;
        }
        Application.LoadLevel(levelCounter);
    }
}
