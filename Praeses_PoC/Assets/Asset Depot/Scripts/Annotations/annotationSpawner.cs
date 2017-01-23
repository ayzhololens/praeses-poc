using System.Collections;
using System.Collections.Generic;
using HoloToolKit.Unity;
using UnityEngine;


namespace HoloToolkit.Unity
{

    public class annotationSpawner : MonoBehaviour {
        
        public GameObject spawnedAnnotation;
        public bool tapToPlaceInProgress;
        public GameObject photoNode;
        public GameObject videoNode;
        public GameObject simpleNode;
        public GameObject Minimap;
        public Vector3 anchDist;
        public Transform SpatialMapping;
        public GameObject miniPhotoNode;
        public GameObject miniVideoNode;
        public GameObject miniSimpleNode;
        float scaleOffest;
        GameObject miniAnnotation;

        bool isVideoNode;
        bool isPhotoNode;
        bool isSimpleNode;


        // Use this for initialization
        void Start() {

            scaleOffest = SpatialMapping.GetComponent<minimapSpawn>().scaleOffset;
            
        }

        // Update is called once per frame
        void Update()
        {

            if (tapToPlaceInProgress)
            {
                startPlacingAnnotNode();
            }

        }

        public void startPlacingAnnotNode()
        {
            Vector3 pos = GazeManager.Instance.Position;
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, GazeManager.Instance.Normal);
            spawnedAnnotation.transform.position = pos;
            spawnedAnnotation.transform.rotation = rot;
            




        }

        public void finishPlacingAnnotNode()
        {
            tapToPlaceInProgress = false;
            GetComponent<annotationManager>().tapToPlaceIndicator.SetActive(false);
            GetComponent<annotationManager>().tapToPlaceAnnotNode = false;
            spawnedAnnotation.GetComponent<BoxCollider>().enabled = true;
            spawnedAnnotation.GetComponent<openAnnotationNode>().openContent();

            //spawn miniNode
            Minimap = SpatialMapping.GetComponent<miniMapToggle>().MiniMapHolder;
            anchDist = (SpatialMapping.position - spawnedAnnotation.transform.position);

            if (isPhotoNode)
            {
                miniAnnotation = Instantiate(miniPhotoNode, Minimap.transform.position, spawnedAnnotation.transform.rotation) as GameObject;
            }
            if (isVideoNode)
            {
                miniAnnotation = Instantiate(miniVideoNode, Minimap.transform.position, spawnedAnnotation.transform.rotation) as GameObject;
            }
            if (isSimpleNode)
            {
                miniAnnotation = Instantiate(miniSimpleNode, Minimap.transform.position, spawnedAnnotation.transform.rotation) as GameObject;
            }
            GetComponent<annotationManager>().activeAnnotations.Add((GameObject)miniAnnotation);
            miniAnnotation.transform.position = (miniAnnotation.transform.position - (anchDist * scaleOffest));
            miniAnnotation.transform.SetParent(Minimap.transform);
            miniAnnotation.transform.localScale = miniAnnotation.transform.localScale * scaleOffest;
            miniAnnotation.SetActive(SpatialMapping.GetComponent<miniMapToggle>().active);


            GetComponent<annotationManager>().annotating = false;
            isPhotoNode = false;
            isSimpleNode = false;
            isVideoNode = false;
        }

        public void spawnPhotoAnnotation()
        {
            isPhotoNode = true;
            Vector3 pos = GazeManager.Instance.Position;
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, GazeManager.Instance.Normal);
            spawnedAnnotation = Instantiate(photoNode, pos, rot) as GameObject;
            GetComponent<annotationManager>().activeAnnotations.Add((GameObject)spawnedAnnotation);
            spawnedAnnotation.GetComponent<BoxCollider>().enabled = false;
            spawnedAnnotation.GetComponent<openAnnotationNode>().closeContent();
            spawnedAnnotation.transform.SetParent(transform);
            tapToPlaceInProgress = true;



        }

        public void spawnVideoAnnotation()
        {
            isVideoNode = true;
            Vector3 pos = GazeManager.Instance.Position;
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, GazeManager.Instance.Normal);
            spawnedAnnotation = Instantiate(videoNode, pos, rot) as GameObject;
            GetComponent<annotationManager>().activeAnnotations.Add((GameObject)spawnedAnnotation);
            spawnedAnnotation.GetComponent<BoxCollider>().enabled = false;
            spawnedAnnotation.GetComponent<openAnnotationNode>().closeContent();
            spawnedAnnotation.transform.SetParent(transform);
            tapToPlaceInProgress = true;
        }


        public void spawnSimpleAnnotation()
        {
            isSimpleNode = true;
            Vector3 pos = GazeManager.Instance.Position;
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, GazeManager.Instance.Normal);
            spawnedAnnotation = Instantiate(simpleNode, pos, rot) as GameObject;
            GetComponent<annotationManager>().activeAnnotations.Add((GameObject)spawnedAnnotation);
            spawnedAnnotation.GetComponent<BoxCollider>().enabled = false;
            spawnedAnnotation.GetComponent<openAnnotationNode>().closeContent();
            spawnedAnnotation.transform.SetParent(transform);
            tapToPlaceInProgress = true;
        }

        public void spawnMiniAnnotation()
        {
            //miniAnnot.transform.SetParent(Holder);
            //anchDist = (Holder.position - miniAnnot.transform.position);

            //Minimap = GameObject.Find("MiniMapHolder");
            //GameObject miniAnnotation = Instantiate(miniAnnotationNode, Minimap.transform.position, Quaternion.identity) as GameObject;
            //miniAnnotation.transform.position = (miniAnnotation.transform.position - (anchDist * .09f));
            //miniAnnotation.transform.SetParent(Minimap.transform);
        }
    }
}
