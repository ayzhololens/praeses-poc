using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoloToolkit.Unity
{

    public class boilerSpawner : MonoBehaviour
    {

        public GameObject boiler;
        bool tapToPlaceBoiler;
        public GameObject SpatialMapping;

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
            Vector3 pos = GazeManager.Instance.Position;
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, GazeManager.Instance.Normal);
            GameObject boilerClone = Instantiate(boiler, pos, rot) as GameObject;
            boiler = boilerClone;
            for (int i=0; i<boiler.transform.childCount; i++)
            {
                boiler.transform.GetChild(i).GetComponent<MeshCollider>().enabled = false;
            }
            tapToPlaceBoiler = true;
        }

        public void PlaceBoiler()
        {
            tapToPlaceBoiler = true;
            Vector3 pos = GazeManager.Instance.Position;
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, GazeManager.Instance.Normal);
            boiler.transform.position = pos;
            boiler.transform.rotation = rot;
        }

        public void LockBoiler()
        {
            tapToPlaceBoiler = false;
            for (int i = 0; i < boiler.transform.childCount; i++)
            {
                boiler.transform.GetChild(i).GetComponent<MeshCollider>().enabled = true;
            }
            boiler.transform.SetParent(SpatialMapping.transform);

        }
    }
}
