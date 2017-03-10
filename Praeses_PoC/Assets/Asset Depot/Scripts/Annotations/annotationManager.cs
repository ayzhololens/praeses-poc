using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

namespace HoloToolkit.Unity
{

    public class annotationManager : Singleton<annotationManager>
    {

        //public GameObject videoRecordTextIndicator;
        //public GameObject tapToPlaceIndicator;
        //public GameObject videoRecordingInProgressIndicator;
        //public GameObject photoCaptureTextIndicator;
        //public GameObject dictationInProgressIndicator;
        public GameObject stateIndicator;
        public bool videoReordingEnabled;
        public bool videoRecordingInProgress;
        public bool photoCaptureEnabled;
        public bool dictationInProgress;
        public List<GameObject> activeAnnotations;
        public GameObject currentAnnotation;
        public GameObject vidManager;
        public GameObject photoManager;
        videoRecorder vidRecorder;
        photoRecorder photoRecorder;
        annotationSpawner annotSpawner;
        public GameObject activeDictationBox;

        public bool annotating;

        // Use this for initialization
        void Start()
        {
            vidRecorder = vidManager.GetComponent<videoRecorder>();
            photoRecorder = photoManager.GetComponent<photoRecorder>();
            annotSpawner = GetComponent<annotationSpawner>();

        }

        // Update is called once per frame
        void Update()
        {

            if (sourceManager.Instance.sourcePressed && videoReordingEnabled)
            {
                StartVideoRecording();
            }
            if (sourceManager.Instance.sourcePressed && videoRecordingInProgress)
            {
                StopVideoRecording();
            }
            if(sourceManager.Instance.sourcePressed && photoCaptureEnabled)
            {
                CapturePhoto();
            }
            if(sourceManager.Instance.sourcePressed && dictationInProgress)
            {
                StopDictation();
            }


        }

        public void activateMedia()
        {

            if (currentAnnotation.GetComponent<openAnnotationNode>() != null)
            {
                currentAnnotation.GetComponent<selectEvent>().enabled = true;

                currentAnnotation.GetComponent<annotationMediaHolder>().loadMedia();
                currentAnnotation.GetComponent<openAnnotationNode>().openContent();
                currentAnnotation.GetComponent<openAnnotationNode>().enableReview();
            }
            if(currentAnnotation.GetComponent<formNodeController>() != null)
            {

            }



            //annotSpawner.spawnedAnnotation.GetComponent<selectEvent>().enabled = true;

            //annotSpawner.spawnedAnnotation.GetComponent<annotationMediaHolder>().loadMedia();
            //annotSpawner.spawnedAnnotation.GetComponent<openAnnotationNode>().openContent();
            //annotSpawner.spawnedAnnotation.GetComponent<openAnnotationNode>().enableReview();
        }


        public void enableVideoRecording()
        {
            annotating = true;
            if (videoReordingEnabled == false)
            {
                stateIndicator.SetActive(true);
                videoReordingEnabled = true;
                sourceManager.Instance.sourcePressed = false;
                stateIndicator.GetComponent<TextMesh>().text = "Tap to start recording video.";
            }

            Debug.Log("enabled");

        }

        public void StartVideoRecording()
        {
            stateIndicator.GetComponent<TextMesh>().text = "Recoding in progress.  Tap to stop";

            vidRecorder.startRecordingVideo();
            videoRecordingInProgress = true;
            videoReordingEnabled = false;
            Debug.Log("started");

        }

        public void StopVideoRecording()
        {
            stateIndicator.SetActive(false);
            vidRecorder.StopRecordingVideo();
            videoRecordingInProgress = false;
            activateMedia();
            annotating = false;
            Debug.Log("stopped");

        }


        public void enableSimpleCapture()
        {
            annotating = true;
            stateIndicator.SetActive(true);
            stateIndicator.GetComponent<TextMesh>().text = "Tap to start recording video.";

            Debug.Log("enabled");
        }

        public void enablePhotoCapture()
        {
            annotating = true;
            if (photoCaptureEnabled == false)
            {
                photoCaptureEnabled = true;
                stateIndicator.SetActive(true);
                stateIndicator.GetComponent<TextMesh>().text = "Tap to start capture photo.";
                sourceManager.Instance.sourcePressed = false;
            }
        }

        

        public void CapturePhoto()
        {
            if (photoCaptureEnabled)
            {
                photoRecorder.CapturePhoto();
                photoCaptureEnabled = false;
                stateIndicator.SetActive(false);
                //activateMedia();
                annotating = false;
            }
        }

        public void StartDictation()
        {
            annotating = true;
            dictationInProgress = true;
            stateIndicator.SetActive(true);
            stateIndicator.GetComponent<TextMesh>().text = "Dictation in progress.  Tap to stop";
        }

        public void StopDictation()
        {
            annotating = false;
            dictationInProgress = false;
            stateIndicator.SetActive(false);
            //activeDictationBox.GetComponent<Dictationizer>().stopDiction();
        }




    }
}
