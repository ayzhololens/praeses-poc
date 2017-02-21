using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using HoloToolkit.Unity;

public class onModelDragDonut : MonoBehaviour
{
    private float rotationFactor;
    private float scaleFactor;
    public float rotationMultiplier;
    public float scaleMultiplier;

    public GameObject cursorOri;
    public GameObject cursorHand;
    public GameObject buttonsGrp;
    bool allowRot;
    bool allowSca;
    Vector3 initHandPos;

    Transform oriParent;
    bool editState;
    float xPos;
    float yPos;

    float tempDist;

    public GameObject handPosLocal;

    bool navigating;

    public GameObject torus;
    public GameObject scaleable;
    public GameObject rotateable;

    void Start()
    {
        initHandPos = new Vector3(0, 0, 0);
        allowRot = false;
        allowSca = false;
        oriParent = buttonsGrp.transform.parent;
        navigating = false;
        editState = false;
        adjustWithEdit();

        tempDist = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        menuOn();
    }

    private void menuOn()
    {
        if (GazeManager.Instance.HitObject == gameObject || navigating)
        {
            if (sourceManager.Instance.sourcePressed)
            {
                if (!navigating)
                {
                    tempDist = Vector3.Distance(Camera.main.transform.position, GazeManager.Instance.HitPosition);

                    initHandPos = HandsManager.Instance.ManipulationHandPosition;
                    editState = true;
                    adjustWithEdit();
                    navigating = true;
                }
                navigating = true;
                cursorOri.SetActive(false);
                buttonsGrp.SetActive(true);
                torus.SetActive(true);

                Vector3 handPos = HandsManager.Instance.ManipulationHandPosition - initHandPos;

                handPosLocal.transform.position = new Vector3(Mathf.Clamp(handPos.x, -.1f, .1f),
                                                                Mathf.Clamp(handPos.y, -.1f, .1f),
                                                                handPos.z);

                xPos = handPosLocal.transform.localPosition.x;
                yPos = handPosLocal.transform.localPosition.y;

                cursorHand.transform.localPosition = new Vector3(xPos, yPos, tempDist / 100 - .025f);
                Vector3 targetPosition = new Vector3(cursorHand.transform.position.x,
                                       torus.transform.position.y,
                                       cursorHand.transform.position.z);
                torus.transform.LookAt(targetPosition);
                torus.transform.position = new Vector3(torus.transform.position.x, yPos, torus.transform.position.z);

                rotateable.transform.rotation = torus.transform.rotation;
                float scaleFactor = 1 + torus.transform.localPosition.y*.01f;

                //scaleable.transform.localScale += new Vector3(scaleFactor, scaleFactor, scaleFactor);
                //if (cursorHand.transform.localPosition.x > .01f || cursorHand.transform.localPosition.x < -.01f)
                //{
                //    if (allowRot) {
                //    torus.transform.LookAt(targetPosition);
                //        allowSca = false;
                //    }
                //}

                //if (cursorHand.transform.localPosition.y > .01f || cursorHand.transform.localPosition.y < -.01f)
                //{
                //    if (allowSca)
                //    {
                //        allowRot = false;
                //        torus.transform.position = new Vector3(torus.transform.position.x, cursorHand.transform.position.y, torus.transform.position.z);

                //    }
                //}
                //if (cursorHand.GetComponent<Rigidbody>().velocity == Vector3.zero)
                //{
                //    //Debug.Log(cursorHand.GetComponent<Rigidbody>().velocity);
                //    allowRot = true;
                //    allowSca = true;
                //}
            }
            else
            {
                editState = false;
                navigating = false;
                adjustWithEdit();
                cursorOri.SetActive(true);
                initHandPos = new Vector3(0, 0, 0);
                rotationFactor = 0;
                scaleFactor = 0;
                torus.SetActive(false);
                allowRot = true;
                allowSca = true;
            }
        }
    }

    private void adjustWithEdit()
    {
        if (editState)
        {
            Vector3 up = oriParent.up;
            Vector3 forward = Vector3.ProjectOnPlane(Camera.main.transform.forward, up).normalized;

            buttonsGrp.SetActive(true);
            buttonsGrp.transform.SetParent(Camera.main.transform);
            buttonsGrp.transform.localPosition = new Vector3(0, 0, tempDist);
            buttonsGrp.transform.rotation = Quaternion.LookRotation(forward, up);
            buttonsGrp.transform.SetParent(oriParent);
        }
        else
        {
            cursorOri.SetActive(true);
            buttonsGrp.SetActive(false);
            torus.SetActive(false);
        }

    }

}

