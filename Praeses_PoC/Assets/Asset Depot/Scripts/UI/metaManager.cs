using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity;


namespace HoloToolkit.Unity
{

    public class metaManager : Singleton<metaManager>
    {

        public string user;
        public string date { get; set; }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            date = System.DateTime.Now.ToString();
        }
    }
}
