using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using HoloToolkit.Unity.InputModule;
using RenderHeads.Media.AVProVideo;


namespace HoloToolkit.Unity
{
    public class violationController : MonoBehaviour
    {
        public GameObject contentHolder;
        public List<string> violationData;
        public List<int> violationIndices;
        public GameObject[] violationTabs;
        public GameObject[] violationTabButtons;
        public Text violationHeader;
        public Text violationContent;
        public Transform boxStartPos;
        public Transform fieldStartPos;
        public GameObject simpleNotePrefab;
        public GameObject photoThumbPrefab;
        public GameObject videoThumbPrefab;
        public List<GameObject> activeSimpleNotes;
        public List<GameObject> activeVideos;
        public List<GameObject> activePhotos;
        public bool capturingVideo;
        public bool capturingPhoto;
        public GameObject linkedNode;
        public Transform attachmentParent;
        public videoRecorder vidRecorder;
        public MediaPlayer VideoPlayer;
        public photoRecorder photoRecorder;
        string activeVideoPath;
        string activePhotoPath;
        public Transform thumbPos;
        public float thumbOffset;
        public GameObject linkedPreview;
        public Transform frontHolder;
        // Use this for initialization
        void Start()
        {
            frontHolder = Camera.main.transform.GetChild(0);
        }

        // Update is called once per frame
        void Update()
        {

        }


        //enablements here
        #region
        public void enableCategories()
        {
            if(violationData.Count > 0)
            {
                violationTabs[0].SetActive(true);

                for (int i = 0; i < violationTabs.Length; i++)
                {
                    if (i != 0)
                    {
                        if (violationTabs[i].activeSelf)
                        {
                            violationTabs[i].SetActive(false);
                        }

                    }
                }

            }
        }

        public void enableSubCategories()
        {
            if (violationData.Count > 1)
            {

                violationTabs[1].SetActive(true);

                for (int i = 0; i < violationTabs.Length; i++)
                {
                    if (i != 1)
                    {
                        if (violationTabs[i].activeSelf)
                        {
                            violationTabs[i].SetActive(false);
                        }

                    }
                }
            }
        }

        public void enableViolations()
        {

            if(violationData.Count > 2)
            {

                violationTabs[2].SetActive(true);

                for (int i = 0; i < violationTabs.Length; i++)
                {
                    if (i != 2)
                    {
                        if (violationTabs[i].activeSelf)
                        {
                            violationTabs[i].SetActive(false);
                        }

                    }
                }
            }
        }

        public void enableClassification()
        {

            if(violationData.Count > 3)
            {
                violationTabs[3].SetActive(true);

                for (int i = 0; i < violationTabs.Length; i++)
                {
                    if (i != 3)
                    {
                        if (violationTabs[i].activeSelf)
                        {
                            violationTabs[i].SetActive(false);
                        }

                    }
                }
            }
        }

        public void enableDueDate()
        {
            if (violationData.Count > 4)
            {

                violationTabs[4].SetActive(true);

                for (int i = 0; i < violationTabs.Length; i++)
                {
                    if (i != 4)
                    {
                        if (violationTabs[i].activeSelf)
                        {
                            violationTabs[i].SetActive(false);
                        }

                    }
                }
            }
        }

        public void enableConditions()
        {
            if(violationData.Count > 5)
            {

                violationTabs[5].SetActive(true);

                for (int i = 0; i < violationTabs.Length; i++)
                {
                    if (i != 5)
                    {
                        if (violationTabs[i].activeSelf)
                        {
                            violationTabs[i].SetActive(false);
                        }

                    }
                }
            }
        }

        public void enableRequirements()
        {
            if(violationData.Count > 6)
            {
                violationTabs[6].SetActive(true);

                for (int i = 0; i < violationTabs.Length; i++)
                {
                    if (i != 6)
                    {
                        if (violationTabs[i].activeSelf)
                        {
                            violationTabs[i].SetActive(false);
                        }

                    }
                }

            }
        }

        public void enableReview()
        {
            if (violationData.Count > 7)
            {

                violationTabs[7].SetActive(true);

                for (int i = 0; i < violationTabs.Length; i++)
                {
                    if (i != 7)
                    {
                        if (violationTabs[i].activeSelf)
                        {
                            violationTabs[i].SetActive(false);
                        }

                    }
                }
            }

        }
        #endregion 

        public void openViolation()
        {
            contentHolder.transform.position = frontHolder.position;
            linkedNode.GetComponent<nodeController>().openNode();
        }
        public void closeViolation()
        {
            linkedNode.GetComponent<nodeController>().closeNode();
        }

        public void showTabs(bool active)
        {
            for(int i=0; i< violationTabButtons.Length; i++)
            {
                violationTabButtons[i].SetActive(active);
            }
        }
        


        //Comments here
        #region 
        public void spawnSimpleComment()
        {
            repositionThumb();
            GameObject spawnedComment = Instantiate(simpleNotePrefab, transform.position, Quaternion.identity);
            spawnedComment.transform.SetParent(attachmentParent);
            spawnedComment.transform.localPosition = thumbPos.localPosition;
            spawnedComment.transform.localScale = simpleNotePrefab.transform.localScale;
            spawnedComment.transform.localRotation = simpleNotePrefab.transform.localRotation;
            activeSimpleNotes.Add(spawnedComment);
            spawnedComment.GetComponent<commentContents>().isSimple = true;
            spawnedComment.GetComponent<inputFieldManager>().activateField();
            spawnedComment.GetComponent<commentContents>().Date = System.DateTime.Now.ToString();
            spawnedComment.GetComponent<commentContents>().user = metaManager.Instance.user;
            spawnedComment.GetComponent<commentContents>().commentMeta.text = (metaManager.Instance.user + " " + System.DateTime.Now);
            spawnedComment.GetComponent<commentContents>().linkedComponent = this.gameObject;

        }

        public void enableVideoCapture()
        {
            annotationManager.Instance.enableVideoRecording();
            annotationManager.Instance.currentAnnotation = linkedNode;
            annotationManager.Instance.activeField = this.gameObject;
            capturingVideo = true;
        }

        public void loadVideoMedia()
        {
            if (vidRecorder == null)
            {
                vidRecorder = GameObject.Find("VideoManager").GetComponent<videoRecorder>();
                VideoPlayer = GameObject.Find("VideoPlayer").GetComponent<MediaPlayer>();
            }

            activeVideoPath = vidRecorder.filepath;
            VideoPlayer.m_VideoPath = activeVideoPath;
            linkedNode.GetComponent<nodeMediaHolder>().filepath.Add(activeVideoPath);
            spawnVideoPane();
        }

        void spawnVideoPane()
        {
            repositionThumb();
            attachmentParent.gameObject.SetActive(true);
            GameObject spawnedVideo = Instantiate(videoThumbPrefab, transform.position, Quaternion.identity);
            activeVideos.Add(spawnedVideo);
            spawnedVideo.transform.SetParent(attachmentParent);
            spawnedVideo.transform.localPosition = thumbPos.localPosition;
            spawnedVideo.transform.localScale = videoThumbPrefab.transform.localScale;
            spawnedVideo.transform.localRotation = videoThumbPrefab.transform.localRotation;

            spawnedVideo.GetComponent<commentContents>().isVideo = true;
            spawnedVideo.GetComponent<commentContents>().Date = System.DateTime.Now.ToString();
            spawnedVideo.GetComponent<commentContents>().user = metaManager.Instance.user;
            spawnedVideo.GetComponent<commentContents>().commentMeta.text = (metaManager.Instance.user + " " + System.DateTime.Now);
            spawnedVideo.GetComponent<commentContents>().filepath = activeVideoPath;
            spawnedVideo.GetComponent<commentContents>().linkedComponent = this.gameObject;
            VideoPlayer.LoadVideoPlayer();
            capturingVideo = false;
        }
        
        public void enablePhotoCapture()
        {
            annotationManager.Instance.enablePhotoCapture();
            annotationManager.Instance.currentAnnotation = linkedNode;
            annotationManager.Instance.activeField = this.gameObject;
            capturingPhoto = true;

        }

        public void loadPhotoMedia()
        {
            if (photoRecorder == null)
            {
                photoRecorder = GameObject.Find("PhotoManager").GetComponent<photoRecorder>();
            }
            //
            attachmentParent.gameObject.SetActive(false);
            //
            activePhotoPath = photoRecorder.filePath;
            linkedNode.GetComponent<nodeMediaHolder>().filepath.Add(activePhotoPath);
            spawnPhotoPane();
        }

        public void spawnPhotoPane()
        {
            repositionThumb();
            attachmentParent.gameObject.SetActive(true);
            GameObject spawnedPhoto = Instantiate(photoThumbPrefab, transform.position, Quaternion.identity);
            activePhotos.Add(spawnedPhoto);
            spawnedPhoto.transform.SetParent(attachmentParent);
            spawnedPhoto.transform.localPosition = thumbPos.localPosition;
            spawnedPhoto.transform.localScale = photoThumbPrefab.transform.localScale;
            spawnedPhoto.transform.localRotation = photoThumbPrefab.transform.localRotation;


            spawnedPhoto.GetComponent<commentContents>().isPhoto = true;
            spawnedPhoto.GetComponent<commentContents>().filepath = activePhotoPath;
            spawnedPhoto.GetComponent<commentContents>().linkedComponent = this.gameObject;
            spawnedPhoto.GetComponent<commentContents>().Date = System.DateTime.Now.ToString();
            spawnedPhoto.GetComponent<commentContents>().user = metaManager.Instance.user;
            spawnedPhoto.GetComponent<commentContents>().commentMeta.text = (metaManager.Instance.user + " " + System.DateTime.Now);
            Texture2D photoTexture =  photoRecorder.targetTexture;
            spawnedPhoto.GetComponent<Renderer>().material.mainTexture = photoTexture;
            capturingPhoto = false;

        }

        public void repositionThumb()
        {
            foreach(GameObject comment in activeSimpleNotes)
            {
                comment.transform.localPosition = new Vector3(comment.transform.localPosition.x, comment.transform.localPosition.y - thumbOffset, comment.transform.localPosition.z);
            }
            foreach (GameObject comment in activePhotos)
            {
                comment.transform.localPosition = new Vector3(comment.transform.localPosition.x, comment.transform.localPosition.y - (thumbOffset*1.6f), comment.transform.localPosition.z);
            }
            foreach (GameObject comment in activeVideos)
            {
                comment.transform.localPosition = new Vector3(comment.transform.localPosition.x, comment.transform.localPosition.y - (thumbOffset * 1.6f), comment.transform.localPosition.z);
            }
        }

        #endregion
    }
}