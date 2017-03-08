using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using HoloToolkit.Unity.InputModule;

namespace HoloToolkit.Unity
{
    public class inputFieldManager : MonoBehaviour, IInputClickHandler
    {

        public InputField mainInputField;

        bool engaged;

        private void Update()
        {
            if (sourceManager.Instance.sourcePressed)
            {
                if (GazeManager.Instance.HitObject != null)
                {
                    if (GazeManager.Instance.HitObject.tag != "inputField" && GazeManager.Instance.HitObject.tag != "keyboard" && GazeManager.Instance.HitObject.tag != "keyboardBG")
                    {
                        keyboardScript.Instance.turnOff();
                        deactivateField();
                    }
                }else
                {
                    keyboardScript.Instance.turnOff();
                    deactivateField();
                }
            }
        }

        private void Start()
        {
            engaged = false;
        }

        public void activateField()
        {


            mainInputField.ActivateInputField();
            keyboardScript.Instance.currentField = mainInputField;
            keyboardScript.Instance.keyboardToggle();
            Debug.Log("egggg");
            engaged = true;

        }

        public void deactivateField()
        {
            mainInputField.DeactivateInputField();
            keyboardScript.Instance.currentField = null;
            keyboardScript.Instance.turnOff();
            engaged = false;
        }

        public void toggleField()
        {
            if (engaged)
            {
                deactivateField();
                
            }
            else
            {
                activateField();
            }
        }

        public void OnInputClicked(InputClickedEventData eventData)
        {
            //toggleField();
        }
    }
}
