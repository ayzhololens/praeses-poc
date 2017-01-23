using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RenderHeads.Media.AVProVideo;

namespace HoloToolkit.Unity
{

    public class annotationMediaHolder : MonoBehaviour
    {

        public MediaPlayer VideoPlayer;
        public videoRecorder vidRecorder;
        public string filepath;
        public string filename;
        public GameObject playIcon;
        bool startedVideo;
        public Texture2D photoTexture;
        public photoRecorder photoRecorder;
        public GameObject photoVideoPane;
        public bool videoNode;
        public bool photoNode;
        public bool simpleNode;


        // Use this for initialization
        void Start()
        {
            vidRecorder = GameObject.Find("VideoManager").GetComponent<videoRecorder>();
            VideoPlayer = GameObject.Find("VideoPlayer").GetComponent<MediaPlayer>();
            photoRecorder = GameObject.Find("PhotoManager").GetComponent<photoRecorder>();

            filename = vidRecorder.filename;
            filepath = vidRecorder.filepath;
            VideoPlayer.m_VideoPath = filename;
            VideoPlayer.LoadVideoPlayer();

        }

        // Update is called once per frame
        void Update()
        {
            videoChecker();


        }

        public void LoadVideo()
        {

            VideoPlayer.m_VideoPath = filename;
            VideoPlayer.LoadVideoPlayer();

        }

        public void PlayVideo()
        {
            VideoPlayer.Control.Play();
            startedVideo = true;
            playIcon.SetActive(false);
        }

        void videoChecker()
        {
            Debug.Log("playing " + VideoPlayer.Control.IsPlaying());
            Debug.Log("finished " + VideoPlayer.Control.IsFinished());
            if (startedVideo && VideoPlayer.Control.IsFinished())
            {
                playIcon.SetActive(true);
                startedVideo = false;
            }
        }

        public void LoadPhoto()
        {
            if (photoRecorder.targetTexture != null && photoVideoPane != null)
            {
                photoTexture = photoRecorder.targetTexture;
                photoVideoPane.GetComponent<Renderer>().material.mainTexture = photoTexture;
            }
        }
    }
}
