using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoloToolkit.Unity
{

    public class boilerSpawner : MonoBehaviour
    {

        public GameObject boiler;
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
            Vector3 pos = GazeManager.Instance.Position;
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, GazeManager.Instance.Normal);
            GameObject boilerClone = Instantiate(boiler, pos, rot) as GameObject;
            activeObj = boilerClone;
            for (int i=0; i< activeObj.transform.childCount; i++)
            {
                activeObj.transform.GetChild(i).GetComponent<MeshCollider>().enabled = false;
            }
            tapToPlaceBoiler = true;
        }

        public void SpawnDesk()
        {
            isObj = true;
            Vector3 pos = GazeManager.Instance.Position;

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
                Vector3 pos = GazeManager.Instance.Position;
                Quaternion rot = Quaternion.FromToRotation(Vector3.up, GazeManager.Instance.Normal);
                activeObj.transform.position = pos;
                activeObj.transform.rotation = rot;
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
            

        }
    }
}
