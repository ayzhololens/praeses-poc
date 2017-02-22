using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

namespace HoloToolkit.Unity
{

    public class annotationManager : MonoBehaviour
    {

        public GameObject videoRecordTextIndicator;
        public GameObject tapToPlaceIndicator;
        public GameObject videoRecordingInProgressIndicator;
        public GameObject photoCaptureTextIndicator;
        public GameObject dictationInProgressIndicator;
        public bool videoReordingEnabled;
        public bool videoRecordingInProgress;
        public bool tapToPlaceAnnotNode;
        public bool photoCaptureEnabled;
        public bool dictationInProgress;
        public List<GameObject> activeAnnotations;

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


        }


        public void enableVideoRecording()
        {
            annotating = true;
            if (videoReordingEnabled == false)
            {
                videoRecordTextIndicator.SetActive(true);
                videoReordingEnabled = true;
            }

        }

        public void StartVideoRecording()
        {
                videoRecordTextIndicator.SetActive(false);
                videoRecordingInProgressIndicator.SetActive(true);
                tapToPlaceIndicator.SetActive(false);
                vidRecorder.startRecordingVideo();
                videoRecordingInProgress = true;
                videoReordingEnabled = false;
            
        }

        public void StopVideoRecording()
        {
            tapToPlaceIndicator.SetActive(true);
            videoRecordingInProgressIndicator.SetActive(false);
            vidRecorder.StopRecordingVideo();
            videoRecordingInProgress = false;
            annotSpawner.spawnVideoAnnotation();
            tapToPlaceAnnotNode = true;

        }


        public void enableSimpleCapture()
        {
            annotating = true;
            annotSpawner.spawnSimpleAnnotation();
            tapToPlaceAnnotNode = true;
            tapToPlaceIndicator.SetActive(true);
        }

        public void enablePhotoCapture()
        {
            annotating = true;
            if (photoCaptureEnabled == false)
            {
                photoCaptureTextIndicator.SetActive(true);
                photoCaptureEnabled = true;
            }
        }

        public void CapturePhoto()
        {
            if (photoCaptureEnabled)
            {
                photoRecorder.CapturePhoto();
                photoCaptureEnabled = false;
                tapToPlaceIndicator.SetActive(true);
                photoCaptureTextIndicator.SetActive(false);
                tapToPlaceAnnotNode = true;
                annotSpawner.spawnPhotoAnnotation();
            }
        }

        public void StartDictation()
        {
            annotating = true;
            dictationInProgress = true;
            dictationInProgressIndicator.SetActive(true);
        }

        public void StopDictation()
        {
            annotating = false;
            dictationInProgress = false;
            dictationInProgressIndicator.SetActive(false);
            activeDictationBox.GetComponent<Dictationizer>().stopDiction();
        }




    }
}
