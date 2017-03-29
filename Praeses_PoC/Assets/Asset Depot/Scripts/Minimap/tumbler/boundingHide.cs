using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoloToolkit.Unity
{
    public class boundingHide : MonoBehaviour
    {

        int startingLayer;
        public radialOperationsHybrid[] rotators;

        //private void OnTriggerEnter(Collider other)
        //{
        //    print(other);
        //} 

        private void OnTriggerStay(Collider other)
        {
            for (int i = 0; i < rotators.Length; i++)
            {
                if (rotators[i].rotationFactor != 0)
                {
                    return;
                }


            }
            if (other.gameObject.GetComponent<MeshRenderer>() && other.gameObject.tag == "miniMapMesh")
            {
                if (other.gameObject.GetComponent<MeshRenderer>().enabled == true) { return; };
                other.gameObject.GetComponent<MeshRenderer>().enabled = true;
                other.gameObject.layer = 0;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            //Debug.Log(other.gameObject);
            for (int i = 0; i < rotators.Length; i++)
            {
                if (rotators[i].rotationFactor != 0)
                {
                    return;
                }
                
                
            }
            if (other.gameObject.GetComponent<MeshRenderer>() && other.gameObject.tag == "miniMapMesh")
            {
                other.gameObject.GetComponent<MeshRenderer>().enabled = false;
                other.gameObject.layer = 2;

            }
        }
    }
}