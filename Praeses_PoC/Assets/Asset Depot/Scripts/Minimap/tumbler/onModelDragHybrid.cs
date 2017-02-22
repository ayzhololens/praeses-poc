using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using HoloToolkit.Unity;

public class onModelDragHybrid : MonoBehaviour
{
    private float rotationFactor;
    private float scaleFactor;
    public float rotationMultiplier;
    public float scaleMultiplier;

    public GameObject cursorOri;
    public GameObject cursorHand;
    bool allowRot;
    bool allowSca;
    Vector3 initHandPos;

    public GameObject buttonsGrp;

    Transform oriParent;
    bool editState;
    float xPos;
    float yPos;

    float tempDist;

    public GameObject handPosLocal;

    public followCursorScript followCur;

    bool navigating;

    public List<radialOperationsHybrid> operations;

    public bool tumblerModeOn;

    void Start()
    {
        initHandPos = new Vector3(0, 0, 0);
        allowRot = false;
        allowSca = false;

        navigating = false;
        oriParent = buttonsGrp.transform.parent;
        editState = false;
        adjustWithEdit();

        tempDist = 0.0f;
        gameObject.GetComponent<Collider>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (tumblerModeOn) {
            menuOn();
            if (gameObject.GetComponent<Collider>().enabled == true) { return; }
            gameObject.GetComponent<Collider>().enabled = true;
        }else
        {
            if(gameObject.GetComponent<Collider>().enabled == false) { return; }
            gameObject.GetComponent<Collider>().enabled = false;         
        }
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
                //cursorOri.SetActive(false);
                cursorHand.SetActive(true);

                Vector3 handPos = HandsManager.Instance.ManipulationHandPosition - initHandPos;

                handPosLocal.transform.position = new Vector3(Mathf.Clamp(handPos.x, -.1f, .1f),
                                                                Mathf.Clamp(handPos.y, -.1f, .1f),
                                                                handPos.z);

                xPos = handPosLocal.transform.localPosition.x;
                yPos = handPosLocal.transform.localPosition.y;

                cursorHand.transform.localPosition = new Vector3(xPos, yPos, tempDist/ 100 - .025f);

            }
            else
            {
                editState = false;
                navigating = false;
                adjustWithEdit();
                cursorOri.SetActive(true);
                cursorHand.SetActive(false);
                initHandPos = new Vector3(0, 0, 0);
                rotationFactor = 0;
                scaleFactor = 0;
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
            followCur.iconIndex = 0;
            buttonsGrp.SetActive(false);
            cursorOri.SetActive(true);
            foreach (radialOperationsHybrid oper in operations)
            {
                oper.rotationFactor = 0;
            }
        }

    }

}

