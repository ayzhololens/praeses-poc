using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoloToolkit.Unity
{
    public class keyboardSounds : MonoBehaviour {

        bool isPlaying;
        public AudioClip au_click;
        public AudioClip au_hover;

        private void Update()
        {
            playThis();
        }

        public void playThis()
        {
            if (GazeManager.Instance.FocusedObject)
            {
                if (GazeManager.Instance.FocusedObject.tag == "keyboard")
                {
                    if (!isPlaying)
                    {
                        isPlaying = true;
                        gameObject.GetComponent<AudioSource>().clip = au_hover;
                        gameObject.GetComponent<AudioSource>().Play();
                        if (GestureManager.Instance.sourcePressed)
                        {
                            gameObject.GetComponent<AudioSource>().clip = au_click;
                            gameObject.GetComponent<AudioSource>().Play();
                        }
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
    }
    }
