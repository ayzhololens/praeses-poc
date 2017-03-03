using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

namespace HoloToolkit.Unity
{
    public class keyboardSounds : MonoBehaviour{

        bool isPlaying;
        public AudioClip au_click;
        public AudioClip au_hover;

        private void Update()
        {
            playThis();
        }

        public void playThis()
        {
            if (GazeManager.Instance.HitObject)
            {
                if (GazeManager.Instance.HitObject.tag == "keyboard")
                {
                    if (!isPlaying)
                    {
                        isPlaying = true;
                        gameObject.GetComponent<AudioSource>().clip = au_hover;
                        gameObject.GetComponent<AudioSource>().Play();
                    }
                }
                else
                {
                    isPlaying = false;
                }
            }else
            {
                isPlaying = false;
            }
        }
        public void typeSound()
            {
                if (GazeManager.Instance.HitObject.tag == "keyboard")
                {
                    gameObject.GetComponent<AudioSource>().clip = au_click;
                    gameObject.GetComponent<AudioSource>().Play();
                }
            }

        public void wooshSound()
        {
            if (GazeManager.Instance.HitObject.tag == "keyboard")
            {
                gameObject.GetComponent<AudioSource>().clip = au_click;
                gameObject.GetComponent<AudioSource>().Play();
            }
        }
    }
    }
