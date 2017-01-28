using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoloToolkit.Unity
{
    public class largerHitboxVer2 : MonoBehaviour {

        Collider wall2Collider;
        Collider wall3Collider;
        Collider wall4Collider;
        public int smallBoxHitCount;
        public GameObject magneticManagerObject;
        //states
        //0=ready
        //1=bigBoxHit
        //2=initialHit
        //3=botHit
        //4=leave

        // Use this for initialization
        void Start() {
            collidersReset();
        }

        void collidersReset()
        {
            wall2Collider = gameObject.GetComponentsInChildren<Collider>()[1];
            wall3Collider = gameObject.GetComponentsInChildren<Collider>()[2];
            wall4Collider = gameObject.GetComponentsInChildren<Collider>()[3];
            gameObject.GetComponent<Collider>().enabled = false;
            wall4Collider.enabled = false;
            wall3Collider.enabled = false;
            wall2Collider.enabled = true;
            smallBoxHitCount = 0;
        }

        public void wall3Hit()
        {
            print("reset");
            collidersReset();
        }

        public void wall2Hit()
        {
            if (smallBoxHitCount == 0) { 
            magneticManagerObject.GetComponent<GazeManagerMagnetic>().allowMagnetOff = false;
            print("wall2 hit");
            wall2Collider.enabled = false;
            gameObject.GetComponent<Collider>().enabled = true;
            wall4Collider.enabled = true;
            wall3Collider.enabled = true;
        }else if (smallBoxHitCount == 2) {
                print("exiting small box");
                wall4Collider.enabled = true;
                wall3Collider.enabled = true;
            }
        }



        public void smallBoxLeft()
        {
            if (smallBoxHitCount == 2) {
                print("smallBoxLeft");
                wall2Hit();
            }
        }

        public void smallBoxHit()
        {
            if (smallBoxHitCount == 0) {
                print("smallBoxHit0");
                smallBoxHitCount++;
            }
            else if (smallBoxHitCount == 1)
            {
                magneticManagerObject.GetComponent<GazeManagerMagnetic>().allowMagnetOff = true;
                print("smallBoxHit1");
                smallBoxHitCount++;
                wall4Collider.enabled = false;
                wall3Collider.enabled = false;
            }

        }
    }
}