using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

namespace HoloToolkit.Unity
{
    public class thumbnailExpand : MonoBehaviour {
        public float ExpandMult;
        public float ShrinkMult;
        Vector3 startScale;
        Vector3 simpleStartScale;
        Vector3 photoStartScale;
        Vector3 videoStartScale;
        formFieldController linkedField;
        public float breakOutScale;
        public Transform breakOutPos;
        Vector3 startPos;
        bool brokeOut;

        // Use this for initialization
        void Start()
        {
            linkedField = GetComponent<commentContents>().linkedComponent.GetComponent<formFieldController>();
            simpleStartScale = linkedField.GetComponent<formFieldController>().simpleNotePrefab.transform.localScale;
            photoStartScale = linkedField.GetComponent<formFieldController>().photoThumbPrefab.transform.localScale; 
            videoStartScale = linkedField.GetComponent<formFieldController>().videoThumbPrefab.transform.localScale;
            for (int i = 0; i<transform.parent.childCount; i++)
            {
                if (transform.parent.GetChild(i).gameObject.name == "breakOut")
                {
                    breakOutPos = transform.parent.GetChild(i);
                }
            }
            startScale = transform.localScale;
            startPos = transform.localPosition;

        }

        // Update is called once per frame
        void Update() {

        }

        public void expandThumbnail()
        {
            if (!brokeOut)
            {

                transform.localScale = transform.localScale * ExpandMult;
                shrinkThumbnails();
            }

        }

        void shrinkThumbnails()
        {



            for (int i=0; i<linkedField.activeSimpleNotes.Count; i++)
            {
                if (linkedField.activeSimpleNotes[i] != this.gameObject)
                {
                    linkedField.activeSimpleNotes[i].transform.localScale = linkedField.activeSimpleNotes[i].transform.localScale * ShrinkMult;

                }
                
            }

            for (int i = 0; i < linkedField.activePhotos.Count; i++)
            {
                if (linkedField.activePhotos[i] != this.gameObject)
                {
                    linkedField.activePhotos[i].transform.localScale = linkedField.activePhotos[i].transform.localScale * ShrinkMult;
                }

            }

            for (int i = 0; i < linkedField.activeVideos.Count; i++)
            {
                if (linkedField.activeVideos[i] != this.gameObject)
                {
                    linkedField.activeVideos[i].transform.localScale = linkedField.activeVideos[i].transform.localScale * ShrinkMult;

                }

            }

        }

        public void resetThumbs()
        {
            if (!brokeOut)
            {
                for (int i = 0; i < linkedField.activeSimpleNotes.Count; i++)
                {
                    if (!linkedField.activeSimpleNotes[i].activeSelf)
                    {
                        linkedField.activeSimpleNotes[i].SetActive(true);
                    }
                    linkedField.activeSimpleNotes[i].transform.localScale = startScale;
                }

                for (int i = 0; i < linkedField.activePhotos.Count; i++)
                {
                    if (!linkedField.activePhotos[i].activeSelf)
                    {
                        linkedField.activePhotos[i].SetActive(true);
                    }
                    linkedField.activePhotos[i].transform.localScale = startScale;

                }

                for (int i = 0; i < linkedField.activeVideos.Count; i++)
                {
                    if (!linkedField.activeVideos[i].activeSelf)
                    {
                        linkedField.activeVideos[i].SetActive(true);
                    }
                    linkedField.activeVideos[i].transform.localScale = startScale;

                }
                transform.localPosition = startPos;

                GetComponent<commentContents>().commentMeta.gameObject.SetActive(false);
            }   

        }

        public void breakOutThumb()
        {
            if (!brokeOut)
            {
                brokeOut = true;

                for (int i = 0; i < linkedField.activeSimpleNotes.Count; i++)
                {
                    if (linkedField.activeSimpleNotes[i] != this.gameObject)
                    {
                        linkedField.activeSimpleNotes[i].SetActive(false);

                    }

                }

                for (int i = 0; i < linkedField.activePhotos.Count; i++)
                {
                    if (linkedField.activePhotos[i] != this.gameObject)
                    {
                        linkedField.activePhotos[i].SetActive(false);
                    }

                }

                for (int i = 0; i < linkedField.activeVideos.Count; i++)
                {
                    if (linkedField.activeVideos[i] != this.gameObject)
                    {
                        linkedField.activeVideos[i].SetActive(false);
                    }

                }

                transform.localScale = transform.localScale * breakOutScale;
                GetComponent<commentContents>().commentMeta.gameObject.SetActive(true);

                transform.localPosition = breakOutPos.localPosition;
            }

        }

        public void closeBreakout()
        {

            brokeOut = false;
            resetThumbs();
        }
    }
}