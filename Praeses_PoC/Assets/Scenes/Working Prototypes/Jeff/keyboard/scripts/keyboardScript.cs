using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HoloToolkit.Unity
{
    public class keyboardScript : Singleton<keyboardScript>
    {

        public GameObject activatorObject;
        bool onOff;
        public InputField currentField;

        public void turnOn()
        {
            activatorObject.SetActive(true);
            onOff = true;
        }

        public void turnOff()
        {
            activatorObject.SetActive(false);
            onOff = false;
        }

        public void keyboardToggle()
        {
            if (onOff)
            {
                turnOff();
                
            }
            else
            {
                turnOn();
               
            }
        }

        public void typeObject()
        {
            currentField.text = currentField.text + processUnderScore(GazeManager.Instance.FocusedObject.name);
            currentField.MoveTextEnd(true);
        }

        public virtual string processUnderScore(string inputString)
        {
            string outputString;
            outputString = inputString.Split('_')[1];
            return outputString;
        }

    }

}

