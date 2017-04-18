using System.Collections;
using System.Collections.Generic;

using UnityEngine.Events;
using UnityEngine;
namespace HoloToolkit.Unity.InputModule
{
    public class handEnterEvent : MonoBehaviour
    {

        public UnityEvent Event;
        AudioSource aud;
        // Use this for initialization
        void Start()
        {
            if (GetComponent<AudioSource>() == null)
            {
                gameObject.AddComponent<AudioSource>();
            }
            if (aud == null)
            {
                aud = GetComponent<AudioSource>();
                aud.playOnAwake = false;
                aud.spatialBlend = 1;
                aud.minDistance = 1;
                aud.maxDistance = 5;

            }
        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnFocusEnter()
        {
            if (this.enabled == false) return;
            if (Event != null)
            {
                aud.clip = audioManager.Instance.highlightSound;
                aud.Play();
                Event.Invoke();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "handCursor")
            {

                OnFocusEnter();
            }
        }
    }
}