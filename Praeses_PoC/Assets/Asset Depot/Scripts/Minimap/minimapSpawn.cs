using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR.WSA;

namespace HoloToolkit.Unity
{
    public class minimapSpawn : Singleton<minimapSpawn>
    {

        public GameObject miniMapHolder;
        public List<GameObject> miniMapMeshes;
        public GameObject SpatUnderstanding;
        public GameObject MiniMapHolderParent;
        public Material miniMapMat;
        public float scaleOffset;
        GameObject desk;
        GameObject boiler;
        int switchCounter;

        public Vector3 boilerPivot;
        public GameObject avatar;

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
            miniMapHolder.transform.position = MiniMapHolderParent.transform.position;


            for (int i = 0; i < transform.childCount; i++)
            {

                
                miniMapMeshes.Add((GameObject)Instantiate(transform.GetChild(i).gameObject, transform.GetChild(i).position, transform.GetChild(i).localRotation));
                miniMapMeshes[i].transform.SetParent(miniMapHolder.transform);
                if (miniMapMeshes[i].tag == "boilerPrefab") {
                    boilerPivot = miniMapMeshes[i].transform.position;
                } else
                {
                    transform.GetChild(i).gameObject.tag = "SpatialMapping";
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

            MiniMapHolderParent.transform.localScale = MiniMapHolderParent.transform.localScale / scaleOffset;
            MiniMapHolderParent.transform.position = boilerPivot;
            miniMapHolder.transform.SetParent(MiniMapHolderParent.transform);
            MiniMapHolderParent.transform.localPosition = Vector3.zero;
            MiniMapHolderParent.transform.localScale = Vector3.one;
            GetComponent<miniMapToggle>().active = true;
            avatar.GetComponent<minimize>().miniThis();
        }

        public void spawnUnderstandingMiniMap()
        {

            foreach (Transform spatChild in SpatUnderstanding.transform)
            {
                spatChild.transform.SetParent(miniMapHolder.transform);
                spatChild.transform.gameObject.GetComponent<Renderer>().material = miniMapMat;

                if (spatChild.transform.gameObject.GetComponent<MeshFilter>() != null && spatChild.transform.gameObject.GetComponent<MeshFilter>().sharedMesh != null)
                {
                    spatChild.transform.gameObject.GetComponent<MeshFilter>().sharedMesh.RecalculateNormals();
                    Debug.Log("success");


                }
            }

            if (SpatUnderstanding.transform.childCount != 0)
            {
                spawnUnderstandingMiniMap();
            }
            if (SpatUnderstanding.transform.childCount == 0)
            {
                miniMapHolder.transform.position = Vector3.zero;
                miniMapHolder.transform.localScale = miniMapHolder.transform.localScale * scaleOffset;
                miniMapHolder.transform.SetParent(MiniMapHolderParent.transform);
                miniMapHolder.transform.position = new Vector3(MiniMapHolderParent.transform.position.x, MiniMapHolderParent.transform.position.y - .2f, MiniMapHolderParent.transform.position.z);
                GetComponent<miniMapToggle>().active = true;
                //SpatUnderstanding.SetActive(false);
            }



            //for (int i = 0; i < SpatUnderstanding.transform.childCount; i++)
            //{
            //    SpatUnderstanding.transform.GetChild(i).gameObject.tag = "SpatialMapping";
            //    miniMapMeshes.Add((GameObject)Instantiate(SpatUnderstanding.transform.GetChild(i).gameObject, SpatUnderstanding.transform.GetChild(i).position, SpatUnderstanding.transform.GetChild(i).localRotation));
            //    miniMapMeshes[i].transform.SetParent(miniMapHolder.transform);
            //    //miniMapMeshes[i].GetComponent<MeshFilter>().mesh = SpatUnderstanding.transform.GetChild(i).gameObject.GetComponent<MeshFilter>().mesh;
            //    if (miniMapMeshes[i].GetComponent<Renderer>() != null)
            //    {
            //        miniMapMeshes[i].GetComponent<Renderer>().material = miniMapMat;

            //        //miniMapMeshes[i].GetComponent<MeshFilter>().sharedMesh.RecalculateNormals();
            //    }

            //    //if (miniMapMeshes[i].GetComponent<MeshRenderer>() != null)
            //    //{
            //    //    transform.GetChild(i).GetComponent<MeshRenderer>().enabled = false;
            //    //}

            //    if (miniMapMeshes[i].GetComponent<WorldAnchor>() != null)
            //    {
            //        Destroy(miniMapMeshes[i].GetComponent<WorldAnchor>());
            //        //miniMapMeshes[i].GetComponent<MeshRenderer>().enabled = false;
            //    }

            //    //if (miniMapMeshes[i].GetComponent<MeshFilter>() != null && miniMapMeshes[i].GetComponent<MeshFilter>().sharedMesh != null)
            //    //{
            //    //    Debug.Log("recalc");
            //    //    miniMapMeshes[i].GetComponent<MeshFilter>().sharedMesh.RecalculateNormals();

            //    //}
            //}




            //SpatUnderstanding.GetComponent<SpatialUnderstandingCustomMesh>().ImportMeshPeriod = 0;
            //if(SpatUnderstanding.transform.childCount == miniMapHolder.transform.childCount)
            //{
            //    foreach (Transform spatChild in SpatUnderstanding.transform)
            //    {
            //        //stroyImmediate(spatChild.gameObject);
            //    }

            //}











            //SpatUnderstanding.GetComponent<SpatialUnderstanding>().RequestFinishScan();
            //SpatUnderstanding.GetComponent<SpatialUnderstandingCustomMesh>().ImportMeshPeriod = 0;
            //////SpatUnderstanding.transform.GetChild(1).transform.SetParent(miniMapHolder.transform);
            ////Debug.Log(SpatUnderstanding.transform.childCount);
            ////int ChildCountMeshes = SpatUnderstanding.transform.childCount;
            //foreach (Transform spatChild in SpatUnderstanding.transform)
            //{
            //    spatChild.SetParent(miniMapHolder.transform);
            //}

            //for (int i = 0; i < SpatUnderstanding.transform.childCount; i++)
            //{
            //    //SpatUnderstanding.transform.GetChild(i).gameObject.tag = "SpatialMapping";
            //    //miniMapMeshes.Add((GameObject)SpatUnderstanding.transform.GetChild(i).gameObject);
            //    //SpatUnderstanding.transform.GetChild(i).transform.SetParent(miniMapHolder.transform);
            //    //if (miniMapMeshes[i].GetComponent<Renderer>() != null)
            //    //{
            //    //    miniMapMeshes[i].GetComponent<Renderer>().material = miniMapMat;

            //    //    //miniMapMeshes[i].GetComponent<MeshFilter>().sharedMesh.RecalculateNormals();
            //    //}

            //    //if (miniMapMeshes[i].GetComponent<MeshRenderer>() != null)
            //    //{
            //    //    transform.GetChild(i).GetComponent<MeshRenderer>().enabled = false;
            //    //}

            //    //if (miniMapMeshes[i].GetComponent<WorldAnchor>() != null)
            //    //{
            //    //    Destroy(miniMapMeshes[i].GetComponent<WorldAnchor>());
            //    //    miniMapMeshes[i].GetComponent<MeshRenderer>().enabled = false;
            //    //}

            //    //if (miniMapMeshes[i].GetComponent<MeshFilter>() != null && miniMapMeshes[i].GetComponent<MeshFilter>().sharedMesh != null)
            //    //{
            //    //    miniMapMeshes[i].GetComponent<MeshFilter>().sharedMesh.RecalculateNormals();

            //    //}
            //}

            ////miniMapHolder.transform.position = Vector3.zero;
            ////miniMapHolder.transform.localScale = miniMapHolder.transform.localScale * scaleOffset;
            ////miniMapHolder.transform.SetParent(MiniMapTagAlong.transform);
            ////miniMapHolder.transform.position = new Vector3(MiniMapTagAlong.transform.position.x, MiniMapTagAlong.transform.position.y - .2f, MiniMapTagAlong.transform.position.z);
            ////GetComponent<miniMapToggle>().active = true;

            ////if(SpatUnderstanding.transform.childCount == 0)
            ////{
            ////    SpatUnderstanding.SetActive(false);
            ////}

        }
        

    }
}