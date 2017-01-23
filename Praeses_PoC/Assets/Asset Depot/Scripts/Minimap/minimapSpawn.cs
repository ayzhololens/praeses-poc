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
            Debug.Log("tried");

            for (int i = 0; i < transform.childCount; i++)
            {   

                miniMapMeshes.Add((GameObject)Instantiate(transform.GetChild(i).gameObject, transform.GetChild(i).position, transform.GetChild(i).localRotation));
                miniMapMeshes[i].transform.SetParent(miniMapHolder.transform);
                if (miniMapMeshes[i].GetComponent<Renderer>() != null)
                {
                    miniMapMeshes[i].GetComponent<Renderer>().material = miniMapMat;
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
            }

            miniMapHolder.transform.position = Vector3.zero;
            miniMapHolder.transform.localScale = miniMapHolder.transform.localScale * scaleOffset;
            miniMapHolder.transform.SetParent(MiniMapTagAlong.transform);
            miniMapHolder.transform.position = new Vector3(MiniMapTagAlong.transform.position.x, MiniMapTagAlong.transform.position.y - .1f, MiniMapTagAlong.transform.position.z);
            GetComponent<miniMapToggle>().active = true;
        }
    }
}