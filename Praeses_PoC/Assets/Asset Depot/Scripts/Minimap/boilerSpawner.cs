using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

namespace HoloToolkit.Unity
{

    public class boilerSpawner : MonoBehaviour
    {

        public GameObject boiler;
        GameObject boilerClone;
        public GameObject desk;
        bool tapToPlaceBoiler;
        public GameObject SpatialMapping;
        public bool isObj;
        GameObject activeObj;

        public GameObject frontHolder;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (tapToPlaceBoiler)
            {
                PlaceBoiler();
            }
        }

        public void SpawnBoiler()
        {
            isObj = false;
            Vector3 pos = GazeManager.Instance.HitPosition;
            boilerClone = Instantiate(boiler, pos, Quaternion.identity) as GameObject;
            activeObj = boilerClone;
            for (int i = 0; i < activeObj.transform.childCount; i++)
            {
                    activeObj.transform.GetChild(i).GetComponent<MeshCollider>().enabled = false;
            }
            tapToPlaceBoiler = true;
        }

        public void SpawnDesk()
        {
            isObj = true;
            Vector3 pos = GazeManager.Instance.HitPosition;

            GameObject deskClone = Instantiate(desk, pos, Quaternion.identity) as GameObject;
            activeObj = deskClone;
            for (int i = 0; i < activeObj.transform.childCount; i++)
            {
                activeObj.transform.GetChild(i).GetComponent<MeshCollider>().enabled = false;
            }
            tapToPlaceBoiler = true;
        }

        public void PlaceBoiler()
        {
            tapToPlaceBoiler = true;
            if (isObj)
            {
                activeObj.transform.position = frontHolder.transform.position;
            }

            if (!isObj)
            {
                Vector3 pos = GazeManager.Instance.HitPosition;
                activeObj.transform.position = pos;
            }

        }

        public void LockBoiler()
        {
            tapToPlaceBoiler = false;
            for (int i = 0; i < activeObj.transform.childCount; i++)
            {
                activeObj.transform.GetChild(i).GetComponent<MeshCollider>().enabled = true;
            }
            activeObj.transform.SetParent(SpatialMapping.transform);

            if (isObj)
            {
                activeObj.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().enabled = false;
            }
            repositionNodeHolder();

        }

        void repositionNodeHolder()
        {
            Transform initParent = annotationManager.Instance.gameObject.transform.parent;
            annotationManager.Instance.gameObject.transform.SetParent(boilerClone.transform);
            annotationManager.Instance.gameObject.transform.localPosition = Vector3.zero;
            annotationManager.Instance.gameObject.transform.localRotation = new Quaternion(0, 0, 0, 0);
            annotationManager.Instance.gameObject.transform.localScale = Vector3.one;
            annotationManager.Instance.gameObject.transform.SetParent(initParent);
        }
    }
}
