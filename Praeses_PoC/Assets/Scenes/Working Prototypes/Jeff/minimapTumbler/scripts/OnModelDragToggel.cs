using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoloToolkit.Unity
{
    public class OnModelDragToggel : MonoBehaviour
    {

        public GameObject textObject;
        public bool stateOnOff;
        public GameObject tumbledGrp;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        void toggleOn()
        {
            textObject.GetComponent<TextMesh>().text = "on";
        }
        void toggleOff()
        {
            textObject.GetComponent<TextMesh>().text = "off";
        }

        public void toggleOnOff()
        {
            if (stateOnOff)
            {
                toggleOff();
                stateOnOff = false;
                tumbledGrp.GetComponent<Collider>().enabled = false;
            }
            else
            {
                toggleOn();
                stateOnOff = true;
                tumbledGrp.GetComponent<Collider>().enabled = true;
            }
        }
    }
}
