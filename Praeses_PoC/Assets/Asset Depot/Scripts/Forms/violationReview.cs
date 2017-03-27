using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using HoloToolkit.Unity.InputModule;

namespace HoloToolkit.Unity
{
    public class violationReview : MonoBehaviour {

        public Text[] violationData;
        public violationController violationControl;
        public GameObject[] resolutions;
        public GameObject ReviewHolder;
        public GameObject submittedViolationHolder;
        public GameObject commentHolder;
        public float headerOffset;
        Vector3 headerStartPos;
        GameObject copiedViolationContent;

    // Use this for initialization
        void Start() {

        }

        // Update is called once per frame
        void Update() {

        }

        public void loadReview()
        {
            for(int i=0; i < violationControl.violationData.Count; i++)
            {
                violationData[i].text = violationControl.violationData[i];
            }
        }

        public void submitReview()
        {
            commentHolder.transform.SetParent(submittedViolationHolder.transform);


            copiedViolationContent = Instantiate(this.gameObject, transform.position, Quaternion.identity);
            copiedViolationContent.transform.SetParent(submittedViolationHolder.transform);
            copiedViolationContent.transform.localScale = transform.localScale;
            copiedViolationContent.transform.localRotation = transform.localRotation;
            
            violationControl.showTabs(false);

            violationControl.violationHeader.text = violationControl.violationData[2];
            Transform header = violationControl.violationHeader.transform.parent.parent;
            headerStartPos = header.position;
            header.localPosition = new Vector3(header.localPosition.x, header.localPosition.y- headerOffset, header.localPosition.z);

            submittedViolationHolder.SetActive(true);
            ReviewHolder.SetActive(false);

            violatoinSpawner.Instance.populatePreviewField();
        }

        public void enableEditing()
        {
            commentHolder.transform.SetParent(ReviewHolder.transform);
            violationControl.violationHeader.text = "Edit Violation";
            Transform header = violationControl.violationHeader.transform.parent.parent;
            header.localPosition = headerStartPos;
            DestroyImmediate(copiedViolationContent);
            violationControl.showTabs(true);
            submittedViolationHolder.SetActive(false);
            ReviewHolder.SetActive(true);
        }

        public void resolveViolation()
        {
            violatoinSpawner.Instance.violationPreview.GetComponent<viewViolationController>().reorderFields(violationControl.linkedPreview);
            violatoinSpawner.Instance.violationPreview.GetComponent<viewViolationController>().vioResolvedFields.Add(violationControl.linkedPreview);
            violationControl.linkedPreview.transform.localPosition = violatoinSpawner.Instance.violationPreview.GetComponent<viewViolationController>().resolvedPos.localPosition;

            resolutions[0].SetActive(false);
            resolutions[1].SetActive(false);

        }

        public void vioNotResolved()
        {
            resolutions[2].SetActive(false);
            resolutions[1].SetActive(false);
        }
        public void vioNotResolvedOther()
        {
            resolutions[2].SetActive(false);
            resolutions[0].SetActive(false);
        }
        


    }
}