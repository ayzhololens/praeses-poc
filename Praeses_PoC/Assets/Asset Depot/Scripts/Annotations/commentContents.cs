using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

        // Use this for initialization
        void Start() {
            

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
            linkedComponent.GetComponent<formFieldController>().VideoPlayer.m_VideoPath = filepath;
            linkedComponent.GetComponent<formFieldController>().VideoPlayer.LoadVideoPlayer();
            PlayVideo();

        }

        public void PlayVideo()
        {
            if (!startedVideo)
            {

                linkedComponent.GetComponent<formFieldController>().VideoPlayer.Control.Play();
                startedVideo = true;
                playIcon.SetActive(false);
                pauseIcon.SetActive(true);
            }

        }

        public void PauseVideo()
        {
            if (startedVideo)
            {
                linkedComponent.GetComponent<formFieldController>().VideoPlayer.Control.Pause();
                startedVideo = false;
                playIcon.SetActive(true);
                pauseIcon.SetActive(false);
            }
        }

        void videoChecker()
        {
            if (linkedComponent.GetComponent<formFieldController>().VideoPlayer.Control.IsFinished())
            {
                playIcon.SetActive(true);
                pauseIcon.SetActive(false);
                startedVideo = false;
            }
        }
    }
}
