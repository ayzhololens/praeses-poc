using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using HoloToolkit.Unity;


namespace HoloToolkit.Unity
{
    public class mainMenuController : MonoBehaviour {

        public GameObject[] tabs;
        public formContent[] preloadedDataFields;
        public GameObject contentHolder;

        // Use this for initialization
        void Start() {

        }

        // Update is called once per frame
        void Update() {

        }

        public void goToTab(int tabIndex)
        {
            for (int i = 0; i < tabs.Length; i++)
            {
                if (tabs[i].activeSelf && i != tabIndex)
                {
                    tabs[i].SetActive(false);
                }
            }
            tabs[tabIndex].SetActive(true);
        }

        public void preloadData()
        {
            Debug.Log("yo333");
            for (int i = 0; i < preloadedDataFields.Length; i++)
            {
                preloadedDataFields[i].loadDetails();
            }
        }

        public void closeMainMenu()
        {
            contentHolder.SetActive(false);
        }
    }
}