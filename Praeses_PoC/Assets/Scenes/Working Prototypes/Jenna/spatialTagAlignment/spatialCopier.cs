using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolKit.Unity;

namespace HoloToolkit.Unity
{

    public class spatialCopier : MonoBehaviour
    {

        public GameObject spatialCopyHolder;
        GameObject instSpatialHolder;
        public GameObject meshHolder;
        public List<GameObject> spatialMeshes;
        public GameObject PosterOBJ;
        public Material wireFrame2;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void CopySpatialMesh()
        {


            for (int i = 0; i < transform.childCount; i++)
            {
                spatialMeshes.Add((GameObject)Instantiate(transform.GetChild(i).gameObject, transform.GetChild(i).position, transform.GetChild(i).localRotation));
                //spatialMeshes[i] = Instantiate(transform.GetChild(i).gameObject, transform.position, Quaternion.identity) as GameObject;
                spatialMeshes[i].transform.SetParent(meshHolder.transform);
                spatialMeshes[i].GetComponent<MeshRenderer>().material = wireFrame2;

                Debug.Log("meshesSpawned"); 
            }
        }

        public void PlaceOrigin()
        {
            //spatialCopyHolder.transform.position = PosterOBJ.transform.position;
            Vector3 pos = GazeManager.Instance.Position;
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, GazeManager.Instance.Normal);
            instSpatialHolder = Instantiate(spatialCopyHolder, pos, rot) as GameObject;
            spatialCopyHolder = instSpatialHolder;
            meshHolder.transform.position = spatialCopyHolder.transform.position;
            meshHolder.transform.SetParent(spatialCopyHolder.transform);
            CopySpatialMesh();
        }

        public void alignMeshes()
        {
            spatialCopyHolder.transform.position = PosterOBJ.transform.position;
        }

        public void UnAlignMesh()
        {
            spatialCopyHolder.transform.position = Vector3.zero;
        }
    }
}
