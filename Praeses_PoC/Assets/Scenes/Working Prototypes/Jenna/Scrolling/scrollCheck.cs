﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoloToolkit.Unity
{

    public class scrollCheck : MonoBehaviour
    {
        public scrollManager scrollManag;
        public bool up;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("scrolling down " + scrollManag.scrollingDown);
            if (scrollManag.holdScroll)
            {
                if (scrollManag.scrollingUp && up)
                {
                    other.transform.position = scrollManag.paneLoc[6].transform.position;
                }

                if (scrollManag.scrollingDown && !up)
                {
                    other.transform.position = scrollManag.paneLoc[0].transform.position;
                }

            }


        }
    }
}