using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using HoloToolkit.Unity.InputModule;

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
        public string fieldTextPreview;
        public InputField keyboardField;
        
        //public GameObject canvasObj;

        //anim objects
        float animCounter;
        public GameObject beforeObj;
        public GameObject afterObj;
        Vector3 canvasOriPos;
        Vector3 canvasOffset;

        public GameObject numbers;
        public GameObject symbols;
        bool symbolsOn;

        public GameObject lower;
        public GameObject upper;
        bool shift;
        public bool capsLock;

        public float doubleClickSpeed;
        float initDoubleClick;
        public GameObject LcapsLockBG;
        public GameObject RcapsLockBG;

        private void Start()
        {
            initDoubleClick = doubleClickSpeed;
        }

        private void FixedUpdate()
        {
            doubleClick();

            if (currentField)
            {
                currentField.text = keyboardField.text;
                //fieldTextPreview = keyboardField.text;
            }
            if (animCounter > 0)
            {
                //    animCounter -= Time.deltaTime;
                //    animObj(activatorObject,beforeObj,afterObj);
            }
        }

        void doubleClick()
        {
            if (shift)
            { 
            doubleClickSpeed -= Time.deltaTime;
            }
            else
            {
                doubleClickSpeed = initDoubleClick;
            }

        }

        public void turnOn()
        {
            nestedOn();
            Invoke("adjustCaret",.1f);
        }

        void nestedOn()
        {
            //canvasOriPos = canvasObj.GetComponent<RectTransform>().position;
            //canvasOffset = canvasOriPos + new Vector3(0, .2f, 0);
            activatorObject.SetActive(true);
            keyboardField.ActivateInputField();
            onOff = true;
            cameraParent();

            animCounter = .2f;
            //symbols=============================================================
            numbers.SetActive(true);
            symbols.SetActive(false);
            symbolsOn = false;
            //======================================================================
            //shift================================================================
            lower.SetActive(true);
            upper.SetActive(false);
            shift = false;
            //====================================================================
        }

        public void adjustCaret()
        {
            keyboardField.caretPosition = currentField.text.Length;
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
            //float animMult = 1 - (animCounter / .2f);
            //animated.transform.SetParent(before.transform);
            //animated.transform.localPosition = new Vector3(0, 0, 0);
            //animated.transform.localRotation = new Quaternion(0, 0, 0, 0);
            //animated.transform.localScale = new Vector3(1, 1, 1);
            //animated.transform.SetParent(after.transform);
            //animated.transform.localPosition = Vector3.MoveTowards(animated.transform.localPosition, after.transform.position, animMult);
            //animated.transform.localRotation = new Quaternion(0, 0, 0, 0);
            //animated.transform.localScale = Vector3.MoveTowards(animated.transform.localScale, after.transform.localScale, animMult);
            //canvasObj.transform.position = Vector3.MoveTowards(canvasOriPos, canvasOffset, animMult);
        }

        public void turnOff()
        {
            //canvasOriPos = canvasObj.GetComponent<RectTransform>().position;
            canvasOffset = canvasOriPos + new Vector3(0, 0, 0);
            activatorObject.SetActive(false);
            keyboardField.DeactivateInputField();
            onOff = false;
            animCounter = .2f;
            float animMult = 1 - (animCounter / .2f);
            //canvasObj.transform.position = Vector3.MoveTowards(canvasOriPos,canvasOffset, animMult);
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
            keyboardField.text = keyboardField.text.Insert(keyboardField.caretPosition, processUnderScore(GazeManager.Instance.HitObject.name));
            keyboardField.caretPosition++;
        }

        public void typeCapitalCheck()
        {
            typeObject();
            if (!capsLock)
            {
                shiftToggle();
            }
        }

        public void capsToggle()
        {
            if (!capsLock)
            {
                capsLock = true;
            }else
            {
                capsLock = false;
            }
        }
        public virtual string processUnderScore(string inputString)
        {
            string outputString;
            outputString = inputString.Split('_')[1];
            if (inputString.Substring(inputString.Length - 1, 1) == "_")
            {
                outputString = "_";
            }
            return outputString;
        }

        public void deleteField()
        {
            string tempText = "";
            bool notEnd = false;

            if (keyboardField.caretPosition < keyboardField.text.Length)
            {
                notEnd = true;
            }

            if (keyboardField.caretPosition > 0)
            {
                tempText = keyboardField.text;
                tempText = tempText.Remove(keyboardField.caretPosition - 1, 1);
                keyboardField.text = tempText;
                if (notEnd)
                {
                    keyboardField.caretPosition--;
                }
            }

        }

        public void clearAllField()
        {
            keyboardField.text = "";
        }

        public void caretBack()
        {
            keyboardField.caretPosition--;
        }

        public void caretForward()
        {
            keyboardField.caretPosition++;
        }

        void symbolsOnFunc()
        {

        }

        void symbolsOffFunc()
        {

        }

        public void symbolsToggle()
        {
            if (symbolsOn)
            {
                numbers.SetActive(true);
                symbols.SetActive(false);
                symbolsOn = false;
            }
            else
            {
                numbers.SetActive(false);
                symbols.SetActive(true);
                symbolsOn =true;
            }
        }

        void capsLockOnFunc()
        {
            if (!capsLock)
            {
                LcapsLockBG.SetActive(true);
                RcapsLockBG.SetActive(true);
                capsLock = true;
            }
        }

        void capsLockOffFunc()
        {
            if (capsLock)
            {
                LcapsLockBG.SetActive(false);
                RcapsLockBG.SetActive(false);
                capsLock = false;
            }
        }

        public void shiftToggle()
        {
            if (shift)
            {
                if (doubleClickSpeed < initDoubleClick && doubleClickSpeed > 0)
                {
                    capsLockOnFunc();
                } else {
                    capsLockOffFunc();
                    lower.SetActive(true);
                    upper.SetActive(false);
                    shift = false;
                }
            }
            else
            {
                lower.SetActive(false);
                upper.SetActive(true);
                shift = true;
            }
        }
    }

}

