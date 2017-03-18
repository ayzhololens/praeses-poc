using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RenderHeads.Media.AVProVideo;

namespace HoloToolkit.Unity
{

    public class nodeMediaHolder : MonoBehaviour
    {


        public List<string> filepath;
        public string activeFilepath;
        public string activeFileName;
        public List<GameObject> activeComments;

        public MediaPlayer VideoPlayer;
        public videoRecorder vidRecorder;
        public GameObject playIcon;
        public GameObject pauseIcon;
        bool startedVideo;
        public Texture2D photoTexture;
        public photoRecorder photoRecorder;
        public GameObject photoVideoPane;
        public bool videoNode;
        public bool photoNode;
        public bool simpleNode;
        public bool fieldNode;
        public bool violationNode;
        public InputField Title;
        public InputField Description;
        public string Date;
        public string User;
        public string audioPath;
        public int type;
        public int NodeIndex;

        // Use this for initialization
        void Start()
        {
            NodeIndex = annotationManager.Instance.nodeIndex;
            annotationManager.Instance.nodeIndex += 1;


            vidRecorder = GameObject.Find("VideoManager").GetComponent<videoRecorder>();
            VideoPlayer = GameObject.Find("VideoPlayer").GetComponent<MediaPlayer>();
            photoRecorder = GameObject.Find("PhotoManager").GetComponent<photoRecorder>();

        }


        // Update is called once per frame
        void Update()
        {

            videoChecker();


        }

        public void loadVideoMedia()
        {


            activeFileName = vidRecorder.filename;
            filepath.Add(vidRecorder.filepath);
            activeFilepath = vidRecorder.filepath;
            VideoPlayer.m_VideoPath = activeFileName;
            VideoPlayer.LoadVideoPlayer();
        }

        public void loadPhotoMedia()
        {

            if (photoRecorder.targetTexture != null && photoVideoPane != null)
            {
                filepath.Add(photoRecorder.filePath);
                photoTexture = photoRecorder.targetTexture;
                photoVideoPane.GetComponent<Renderer>().material.mainTexture = photoTexture;
            }
        }

        public void loadPhoto(string filepath)
        {

            Texture2D targetTexture = new Texture2D(2048, 1152);

            var bytesRead = System.IO.File.ReadAllBytes(filepath);
            //Texture2D myTexture = new Texture2D(1024, 1024);
            targetTexture.LoadImage(bytesRead);
            photoTexture = targetTexture;
            photoVideoPane.GetComponent<Renderer>().material.mainTexture = photoTexture;

        }

        public void LoadVideo()
        {
            if (VideoPlayer == null)
            {
                VideoPlayer = GameObject.Find("VideoPlayer").GetComponent<MediaPlayer>();
            }
            VideoPlayer.m_VideoPath = activeFileName;
            VideoPlayer.LoadVideoPlayer();

        }


        public void PlayVideo()
        {
            if (!startedVideo)
            {
                VideoPlayer.Control.Play();
                startedVideo = true;
                playIcon.SetActive(false);
                pauseIcon.SetActive(true);
            }

        }

        public void PauseVideo()
        {
            if (startedVideo)
            {
                VideoPlayer.Control.Pause();
                startedVideo = false;
                playIcon.SetActive(true);
                pauseIcon.SetActive(false);
            }
        }

        void videoChecker()
        {
            if (startedVideo && VideoPlayer.Control.IsFinished())
            {
                playIcon.SetActive(true);
                pauseIcon.SetActive(false);
                startedVideo = false;
            }
        }


    }
}