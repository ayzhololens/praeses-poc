using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HoloToolkit.Unity
{
    public class inputFieldManager : MonoBehaviour
    {

        public InputField mainInputField;

        bool engaged;

        private void Update()
        {
            if (GestureManager.Instance.sourcePressed)
            {
                if (GazeManager.Instance.FocusedObject != null)
                {
                    if (GazeManager.Instance.FocusedObject.tag != "inputField" && GazeManager.Instance.FocusedObject.tag != "keyboard" && GazeManager.Instance.FocusedObject.tag != "keyboardBG")
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
            engaged = true;

        }

        public void deactivateField()
        {
            mainInputField.DeactivateInputField();
            keyboardScript.Instance.currentField = null;
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
    }
}
