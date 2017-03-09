using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using HoloToolkit.Unity;

public class minimize : MonoBehaviour, IInputClickHandler {

    public GameObject miniCopy;
    public bool posUpdate;
    public bool rotUpdate;
    public GameObject miniRot;
    bool done;
    public GameObject bigHeadGeo;
    public List<GameObject> meshesHide;

    public GameObject paperPlane;

    public void miniThis()
    {
        miniCopy = Instantiate(gameObject);
        //print("miniThis:" + miniCopy);
        Destroy(miniCopy.GetComponent<minimize>());
        if (miniCopy.GetComponent<followCam>())
        {
            Destroy(miniCopy.GetComponent<followCam>());
        }
        if (rotUpdate)
        {
            foreach (Transform childObj in miniCopy.GetComponentsInChildren<Transform>())
            {
                if (childObj.gameObject.name == "headPivot")
                {
                    miniRot = childObj.gameObject;
                    lookAtAvatar.Instance.avatarObj = miniCopy.transform;
                }
                if (childObj.gameObject.name == "body_geo")
                {
                    childObj.gameObject.GetComponent<followViz>().opposite = paperPlane;
                }
            }
        }
        minimapTransferObject.Instance.mainFunc(miniCopy);
        done = true;
        foreach(GameObject mesh in meshesHide)
        {
            mesh.GetComponent<Collider>().enabled = false;
        }
    }

    private void Update()
    {
        //if (Input.GetButtonDown("Jump")){
        //    if (!done)
        //    {
        //        miniThis();
        //    }
        //}

        if(miniCopy != null && posUpdate)
        {
            miniCopy.transform.localPosition = transform.position + minimapSpawn.Instance.miniMapHolder.transform.localPosition/minimapSpawn.Instance.scaleOffset*.5752f;
            miniCopy.transform.localRotation = transform.rotation;
        }

        if (miniCopy != null && rotUpdate && done)
        {
            miniRot.transform.localRotation = bigHeadGeo.transform.localRotation;
        }
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        if (!done)
        {
            miniThis();
        }
    }

}
