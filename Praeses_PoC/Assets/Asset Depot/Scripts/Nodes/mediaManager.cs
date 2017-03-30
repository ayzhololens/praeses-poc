using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RenderHeads.Media.AVProVideo;
using UnityEngine.UI;
using HoloToolkit.Unity.InputModule;

namespace HoloToolkit.Unity
{

    public class mediaManager : Singleton<mediaManager>
    {
        public videoRecorder vidRecorder;
        bool recordingEnabled;
        bool recordingInProgress;
        public photoRecorder photoRecorder;
        bool photoCaptureEnabled;
        public GameObject stateIndicator;
        public GameObject currentNode { get; set; }
        public List<GameObject> activeNodes;
        public bool isCapturing { get; set; }
        public int nodeIndex { get; set; }


        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (isCapturing)
            {
                stopCapturing();
            }

        }

        public void activateMedia()
        {
            //set 
            nodeMediaHolder nodeMedia = currentNode.GetComponent<nodeMediaHolder>();

            if (nodeMedia.photoNode)
            {
                //send photo file path to be stored and loaded on node
                nodeMedia.activeFilepath = photoRecorder.filePath;
                nodeMedia.loadPhoto(photoRecorder.filePath);
            }
            if (nodeMedia.videoNode)
            {
                //send video name to node and load it
                //using filename instead of path because the media player is set to persistent data path
                nodeMedia.activeFilepath = vidRecorder.filename;
                nodeMedia.LoadVideo();
            }

            //set user and date
            nodeMedia.User = metaManager.Instance.user;
            nodeMedia.Date = System.DateTime.Now.ToString();
            currentNode.GetComponent<nodeOpener>().setUpNode();


        }
        
        public void enablePhotoCapture()
        {
            isCapturing = true;
            photoCaptureEnabled = true;
            setStatusIndicator("Tap to capture photo");

            //clear source manager
            sourceManager.Instance.sourcePressed = false;

        }
        
        void capturePhoto()
        {
            disableStatusIndicator();
            photoCaptureEnabled = false;
            isCapturing = false;

            //capture photo, save it, activeMedia() when done
            photoRecorder.CapturePhoto();
        } 

        public void enableVideoRecording()
        {
            isCapturing = true;
            setStatusIndicator("Tap to start recording video");
            recordingEnabled = true;

            //clear source manager
            sourceManager.Instance.sourcePressed = false;
        }

        void startVideoRecording()
        {
            vidRecorder.startRecordingVideo();
            setStatusIndicator("Recording in progress. Tap to stop");
            recordingEnabled = false;
            recordingInProgress = true;
        }

        void stopVideoRecording()
        {
            disableStatusIndicator();
            recordingInProgress = false;
            isCapturing = false;

            //stop recording, finish encoding then calling activateMedia() when done
            vidRecorder.StopRecordingVideo();
        }

        public void setStatusIndicator(string curStatus)
        {
            if (!stateIndicator.activeSelf)
            {
                stateIndicator.SetActive(true);
            }
            stateIndicator.GetComponent<TextMesh>().text = curStatus;
        }

        public void disableStatusIndicator()
        {
            if (stateIndicator.activeSelf)
            {
                stateIndicator.SetActive(false);
            }
            stateIndicator.GetComponent<TextMesh>().text = null;
        }

        void stopCapturing()
        {
            if (sourceManager.Instance.sourcePressed)
            {
                if (recordingEnabled)
                {
                    startVideoRecording();
                }
                if (recordingInProgress)
                {
                    stopVideoRecording();
                }
                if (photoCaptureEnabled)
                {
                    capturePhoto();
                }

            }

        }
    }
}