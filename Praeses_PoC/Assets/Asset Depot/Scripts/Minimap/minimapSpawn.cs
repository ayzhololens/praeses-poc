using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR.WSA;

namespace HoloToolkit.Unity
{
    public class minimapSpawn : MonoBehaviour
    {

        GameObject miniMapHolder;
        public List<GameObject> miniMapMeshes;
        public GameObject MiniMapTagAlong;
        public Material miniMapMat;
        public float scaleOffset;
        GameObject desk;
        GameObject boiler;
        int switchCounter;
        public Material textureMat;

        Vector3 boilerPivot;

        // Use this for initialization
        void Start()
        {
            miniMapHolder = new GameObject();
            miniMapHolder.name = "MiniMapHolder";
            GetComponent<miniMapToggle>().MiniMapHolder = miniMapHolder;


        }

        // Update is called once per frame
        void Update()
        {

        }

        public void spawnMiniMap()
        {
            //Debug.Log(miniMapHolder.transform.position);
            miniMapHolder.transform.position = MiniMapTagAlong.transform.position;

            for (int i = 0; i < transform.childCount; i++)
            {   

                miniMapMeshes.Add((GameObject)Instantiate(transform.GetChild(i).gameObject, transform.GetChild(i).position, transform.GetChild(i).localRotation));
                miniMapMeshes[i].transform.SetParent(miniMapHolder.transform);
                if (miniMapMeshes[i].tag == "boilerPrefab") {
                    boilerPivot = miniMapMeshes[i].transform.position;
                } else
                {
                    miniMapMeshes[i].tag = "miniMapMesh";
                    miniMapMeshes[i].GetComponent<MeshRenderer>().enabled = false;
                    miniMapMeshes[i].layer = 2;
                }
                if (miniMapMeshes[i].GetComponent<Renderer>() != null)
                {
                    miniMapMeshes[i].GetComponent<Renderer>().material = miniMapMat;

                    //miniMapMeshes[i].GetComponent<MeshFilter>().sharedMesh.RecalculateNormals();
                }

                if (miniMapMeshes[i].GetComponent<MeshRenderer>() != null)
                {
                    transform.GetChild(i).GetComponent<MeshRenderer>().enabled = false;
                }

                if (miniMapMeshes[i].GetComponent<WorldAnchor>() != null)
                {
                    Destroy(miniMapMeshes[i].GetComponent<WorldAnchor>());
                    //miniMapMeshes[i].GetComponent<MeshRenderer>().enabled = false;
                }

                if(miniMapMeshes[i].GetComponent<MeshFilter>() != null && miniMapMeshes[i].GetComponent<MeshFilter>().sharedMesh!=null)
                {
                   miniMapMeshes[i].GetComponent<MeshFilter>().sharedMesh.RecalculateNormals();

                }
            }

            MiniMapTagAlong.transform.localScale = MiniMapTagAlong.transform.localScale / scaleOffset;
            MiniMapTagAlong.transform.position = boilerPivot;
            miniMapHolder.transform.SetParent(MiniMapTagAlong.transform);
            MiniMapTagAlong.transform.localPosition = Vector3.zero;
            MiniMapTagAlong.transform.localScale = Vector3.one;
            GetComponent<miniMapToggle>().active = true;
        }


        public void Switcher()
        {
            //switchCounter += 1;

            //if (switchCounter >= 4)
            //{
            //    switchCounter = 0;
            //}

            //if (switchCounter == 0)
            //{
            //    desk.SetActive(true);
            //    boiler.SetActive(false);
            //    desk.transform.GetChild(0).gameObject.GetComponent<Renderer>().material = textureMat;
            //}
            //else if(switchCounter == 1)
            //{
            //    desk.SetActive(true);
            //    boiler.SetActive(false);
            //    desk.transform.GetChild(0).gameObject.GetComponent<Renderer>().material = miniMapMat;
            //}
            //else if(switchCounter == 2)
            //{
            //    desk.SetActive(false);
            //    boiler.SetActive(true);
            //}
            //else if (switchCounter == 3)
            //{
            //    boiler.SetActive(false);
            //    desk.SetActive(false);
            //}


        }
    }
}