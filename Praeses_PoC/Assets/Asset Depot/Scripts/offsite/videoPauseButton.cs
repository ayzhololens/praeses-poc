using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RenderHeads.Media.AVProVideo;

public class videoPauseButton : MonoBehaviour {

    public MediaPlayer videoPlayer;
    public GameObject playButton;

    private void Start()
    {
            gameObject.GetComponent<Collider>().enabled = false;
    }

    private void OnMouseDown()
    {
        pauseVideo();
        gameObject.GetComponent<Collider>().enabled = false;
        playButton.GetComponent<Collider>().enabled = true;
        playButton.GetComponent<SpriteRenderer>().enabled = true;
    }

    public void pauseVideo()
    {
        if (videoPlayer.Control.IsPlaying())
        {
            videoPlayer.Control.Pause();
        }
    }
}
