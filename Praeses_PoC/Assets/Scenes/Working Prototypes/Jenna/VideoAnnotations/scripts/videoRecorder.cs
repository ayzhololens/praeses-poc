using UnityEngine;
using System.Collections;

using UnityEngine.VR.WSA.WebCam;
using System.Linq;
#if !UNITY_EDITOR
    using Windows.Storage;
    using Windows.System;
    using System.Collections.Generic;
using System;
using System.IO;
#endif

public class videoRecorder : MonoBehaviour {


    VideoCapture m_VideoCapture = null;

	// Use this for initialization
	void Start () {
        VideoCapture.CreateAsync(false, OnVideoCaptureCreated);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void startRecordingVideo()
    {
        
    }



    void OnVideoCaptureCreated(VideoCapture videoCapture)
    {
        if(videoCapture != null)
        {
            m_VideoCapture = videoCapture;

            Resolution cameraResolution = VideoCapture.SupportedResolutions.OrderByDescending((res) => res.width * res.height).Last();
            float cameraFramerate = VideoCapture.GetSupportedFrameRatesForResolution(cameraResolution).OrderByDescending((fps) => fps).First();

            CameraParameters cameraParameters = new CameraParameters();
            cameraParameters.hologramOpacity = 0.0f;
            cameraParameters.frameRate = cameraFramerate;
            cameraParameters.cameraResolutionWidth = cameraResolution.width;
            cameraParameters.cameraResolutionHeight = cameraResolution.height;
            cameraParameters.pixelFormat = CapturePixelFormat.BGRA32;

            m_VideoCapture.StartVideoModeAsync(cameraParameters,
                                                VideoCapture.AudioState.None,
                                                OnStartedVideoCaptureMode);
        }
        else
        {
            Debug.LogError("Failed to create VideoCapture Instance!");
        }
    
    }

    void OnStartedVideoCaptureMode(VideoCapture.VideoCaptureResult result)
    {
        if (result.success)
        {
            string filename = string.Format("videoTest.mp4", Time.time);
            string filepath = System.IO.Path.Combine(Application.persistentDataPath, filename);

            m_VideoCapture.StartRecordingAsync(filepath, OnStartedRecordingVideo);
        }
    }

    void OnStartedRecordingVideo(VideoCapture.VideoCaptureResult result)
    {


        Debug.Log("Started Recording Video!");
        // We will stop the video from recording via other input such as a timer or a tap, etc.
    }

    public void StopRecordingVideo()
    {
        m_VideoCapture.StopRecordingAsync(OnStoppedRecordingVideo);
    }

    void OnStoppedRecordingVideo(VideoCapture.VideoCaptureResult result)

    {

        Debug.Log("Stopped Recording Video!");
        m_VideoCapture.StopVideoModeAsync(OnStoppedVideoCaptureMode);
    }

    void OnStoppedVideoCaptureMode(VideoCapture.VideoCaptureResult result)
    {
        m_VideoCapture.Dispose();
        m_VideoCapture = null;
    }
}
