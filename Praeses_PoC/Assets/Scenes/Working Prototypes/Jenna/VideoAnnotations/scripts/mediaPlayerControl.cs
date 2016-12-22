using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mediaPlayerControl : MonoBehaviour {


    RenderHeads.Media.AVProVideo.MediaPlayer MediaControl;

	// Use this for initialization
	void Start () {
        MediaControl  = GetComponent<RenderHeads.Media.AVProVideo.MediaPlayer>();
        MediaControl.Play();


    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void startPlayback()
    {
        MediaControl.Play();
    }

    public void pausePlayback()
    {
        MediaControl.Pause();
    }
}
