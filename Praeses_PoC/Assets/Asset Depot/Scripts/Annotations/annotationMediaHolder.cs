﻿using System.Collections;
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


        }

        // Update is called once per frame
        void Update()
        {
            videoChecker();


        }

        public void loadMedia()
        {
            vidRecorder = GameObject.Find("VideoManager").GetComponent<videoRecorder>();
            VideoPlayer = GameObject.Find("VideoPlayer").GetComponent<MediaPlayer>();
            photoRecorder = GameObject.Find("PhotoManager").GetComponent<photoRecorder>();

            filename = vidRecorder.filename;
            filepath = vidRecorder.filepath;
            VideoPlayer.m_VideoPath = filename;
            VideoPlayer.LoadVideoPlayer();
        }

        public void LoadVideo()
        {

            VideoPlayer.m_VideoPath = filename;
            VideoPlayer.LoadVideoPlayer();

        }

        public void PlayVideo()
        {
            if (!startedVideo)
            {
                VideoPlayer.Control.Play();
                startedVideo = true;
                playIcon.SetActive(false);
            }

            //if (startedVideo)
            //{
            //    VideoPlayer.Control.Pause();
            //    startedVideo = false;
            //    playIcon.SetActive(false);
            //}

        }

        void videoChecker()
        {
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
