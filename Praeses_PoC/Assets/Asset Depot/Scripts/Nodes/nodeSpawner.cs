using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using HoloToolkit.Examples.GazeRuler;

namespace HoloToolkit.Unity
{

    public class nodeSpawner : MonoBehaviour
    {
        public GameObject[] nodePrefab;
        public GameObject[] miniNodePrefab;

        GameObject spawnedNode;
        int spawnedIndex;
        bool placingInProgress;
        int offsetCounter;

        //gaze position and rotation
        public Vector3 lookPos;
        public Quaternion lookRot;




        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (placingInProgress)
            {
                nodePlacement();
            }

        }

        public void spawnNode(int nodeIndex)
        {
            //spawn the right node
            spawnedIndex = nodeIndex;
            spawnedNode = Instantiate(nodePrefab[spawnedIndex], getNodeLoc(lookPos), getNodeRot(lookRot));
            
            //add node to active node list and set the parent
            annotationManager.Instance.activeAnnotations.Add(spawnedNode);
            spawnedNode.transform.SetParent(transform);

            //turn off the collider so we dont activate it when placing
            spawnedNode.GetComponent<BoxCollider>().enabled = false;
            placingInProgress = true;
        }

        Vector3 getNodeLoc(Vector3 camPos)
        {
            camPos = GazeManager.Instance.HitPosition;
            return camPos;
        }
        Quaternion getNodeRot(Quaternion camRot)
        {
            camRot = Quaternion.FromToRotation(Vector3.up, GazeManager.Instance.HitInfo.normal);
            return camRot;
        }


        void nodePlacement()
        {
            //update node placement
            spawnedNode.transform.position = getNodeLoc(lookPos);
            spawnedNode.transform.rotation = getNodeRot(lookRot);

            //wait a short while before they can lock placement so it doesnt autolock
            offsetCounter += 1;
            if(sourceManager.Instance.sourcePressed && offsetCounter >= 40)
            {
                lockNodePlacement();
                offsetCounter = 0;
            }
        }

        public void lockNodePlacement()
        {
            placingInProgress = false;
            annotationManager.Instance.currentAnnotation = spawnedNode;

            //get minimap components, scale and offset it to real space
            minimapSpawn miniMapComponent = minimapSpawn.Instance;
            Vector3 boilerPos = miniMapComponent.boilerPivot;
            Transform miniMap = miniMapComponent.miniMapHolder.transform;
            Transform rotatorGroup = miniMap.parent;
            rotatorGroup.localScale = Vector3.one * (1 / miniMapComponent.scaleOffset);
            rotatorGroup.position = boilerPos;

            //spawn miniNode and parent it correctly
            GameObject miniNode = Instantiate(miniNodePrefab[spawnedIndex], spawnedNode.transform.position, Quaternion.identity);
            annotationManager.Instance.activeAnnotations.Add(miniNode);

            //reset rotator group to position miniNode
            miniNode.transform.SetParent(miniMap);
            rotatorGroup.localPosition = Vector3.zero;
            rotatorGroup.localScale = Vector3.one;
            miniNode.SetActive(miniMapToggle.Instance.active);
        }


    }
}