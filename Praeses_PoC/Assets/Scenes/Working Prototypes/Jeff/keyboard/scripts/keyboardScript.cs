using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//#if WINDOWS_UWP
//using WindowsInput;
//#endif

namespace HoloToolkit.Unity
{
    public class keyboardScript : Singleton<keyboardScript>
    {

        public GameObject activatorObject;
        bool onOff;
        public InputField currentField;
        public InputField keyboardField;

        public GameObject cursorObj;
        public GameObject canvasObj;

        //anim objects
        float animCounter;
        public GameObject beforeObj;
        public GameObject afterObj;
        Vector3 canvasOriPos;
        Vector3 canvasOffset;

        public void turnOn()
        {
            canvasOriPos = canvasObj.GetComponent<RectTransform>().position;
            canvasOffset = canvasOriPos + new Vector3(0, .2f, 0);
            activatorObject.SetActive(true);
            onOff = true;
            cameraParent();
            cursorObj.transform.localScale = new Vector3(.2f, .2f, .2f);
            animCounter = .2f;
        }

        void cameraParent()
        {
            Quaternion oldRot = transform.rotation;
            transform.SetParent(Camera.main.transform);
            transform.localPosition = new Vector3(0, 0, 1);
            transform.rotation = new Quaternion(oldRot.x, 0, oldRot.z, oldRot.w);
            transform.SetParent(null);
        }

        void animObj(GameObject animated, GameObject before, GameObject after)
        {
            float animMult = 1 - (animCounter / .2f); 
            animated.transform.SetParent(before.transform);
            animated.transform.localPosition = new Vector3(0, 0, 0);
            animated.transform.localRotation = new Quaternion(0, 0, 0, 0);
            animated.transform.localScale = new Vector3(1, 1, 1);
            animated.transform.SetParent(after.transform);
            animated.transform.localPosition = Vector3.MoveTowards(animated.transform.localPosition, after.transform.position, animMult);
            animated.transform.localRotation = new Quaternion(0, 0, 0, 0);
            animated.transform.localScale = Vector3.MoveTowards(animated.transform.localScale, after.transform.localScale, animMult);
            canvasObj.transform.position = Vector3.MoveTowards(canvasOriPos, canvasOffset, animMult);
        }

        public void turnOff()
        {
            canvasOriPos = canvasObj.GetComponent<RectTransform>().position;
            canvasOffset = canvasOriPos + new Vector3(0, 0, 0);
            activatorObject.SetActive(false);
            onOff = false;
            cursorObj.transform.localScale = new Vector3(1, 1, 1);
            animCounter = .2f;
            float animMult = 1 - (animCounter / .2f);
            canvasObj.transform.position = Vector3.MoveTowards(canvasOriPos,canvasOffset, animMult);
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

        private void Update()
        {
            if (currentField)
            {
                keyboardField.text = currentField.text;
            }
            if (animCounter > 0)
            {
                animCounter -= Time.deltaTime;
                animObj(activatorObject,beforeObj,afterObj);
            }
        }

        public void typeObject()
        {
            //#if WINDOWS_UWP
            //InputSimulator.SimulateTextEntry("Say hello!");
            currentField.text = currentField.text + processUnderScore(GazeManager.Instance.FocusedObject.name);
            currentField.MoveTextEnd(true);
            //#endif
        }

        public virtual string processUnderScore(string inputString)
        {
            string outputString;
            outputString = inputString.Split('_')[1];
            return outputString;
        }

    }

}

