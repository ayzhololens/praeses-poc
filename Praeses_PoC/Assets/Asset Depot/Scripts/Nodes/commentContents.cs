﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using RenderHeads.Media.AVProVideo;
using UnityEngine.UI;

namespace HoloToolkit.Unity
{
    public class commentContents : MonoBehaviour {

        public bool isSimple;
        public bool isPhoto;
        public bool isVideo;
        public InputField commentMain;
        public Text commentMeta;
        public string Date;
        public string user;
        public GameObject editButton;
        public InputField inputField;
        public string filepath;
        public GameObject linkedComponent;
        bool startedVideo;
        public GameObject playIcon;
        public GameObject pauseIcon;
        MediaPlayer mediaPlayer;

        // Use this for initialization
        void Start() {
            if (linkedComponent.GetComponent<formFieldController>() != null)
            {

                mediaPlayer = linkedComponent.GetComponent<formFieldController>().VideoPlayer;
            }

            if (linkedComponent.GetComponent<violationController>() != null)
            {

                mediaPlayer = linkedComponent.GetComponent<violationController>().VideoPlayer;
            }
        }

        // Update is called once per frame
        void Update() {

            if (startedVideo)
            {
                videoChecker();
            }

        }

        public void LoadVideo()
        {
            mediaPlayer.m_VideoPath = filepath;
            mediaPlayer.LoadVideoPlayer();
            linkedComponent.GetComponent<formFieldController>().VideoPlayer.m_VideoPath = filepath;
            linkedComponent.GetComponent<formFieldController>().VideoPlayer.LoadVideoPlayer();
            //PlayVideo();

        }

        public void loadPhoto()
        {

            Texture2D targetTexture = new Texture2D(2048, 1152);

            var bytesRead = System.IO.File.ReadAllBytes(filepath);
            targetTexture.LoadImage(bytesRead);
            GetComponent<Renderer>().material.mainTexture = targetTexture;

        }

        public void PlayVideo()
        {
            if (mediaPlayer.m_VideoPath != filepath)
            {
                LoadVideo();
            }
            if (!startedVideo)
            {
                mediaPlayer.Control.Play();
                startedVideo = true;
                playIcon.SetActive(false);
                pauseIcon.SetActive(true);
            }


        }

        public void PauseVideo()
        {
            if (startedVideo)
            {
                mediaPlayer.Control.Pause();
                startedVideo = false;
                playIcon.SetActive(true);
                pauseIcon.SetActive(false);
            }

        }

        void videoChecker()
        {
            if (mediaPlayer.Control.IsFinished())
            {
                playIcon.SetActive(true);
                pauseIcon.SetActive(false);
                startedVideo = false;
            }
        }
    }
}