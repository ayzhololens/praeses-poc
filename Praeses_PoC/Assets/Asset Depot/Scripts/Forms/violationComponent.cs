using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

namespace HoloToolkit.Unity
{
    public class violationComponent : MonoBehaviour
    {

        public Text optionTitle;
        public InputField optionContent;
        public violationController linkedViolation;
        public int Index;
        public bool setDate;

        // Use this for initialization
        void Start()
        {
            if (setDate)
            {
                optionContent.placeholder.GetComponent<Text>().text = System.DateTime.Now.AddDays(180).ToString();
            }

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void setCategory()
        {
            if (linkedViolation.violationData.Count==0)
            {
                linkedViolation.violationData.Add(optionTitle.text);
                linkedViolation.violationIndices.Add(Index);
            }
            else
            {
                linkedViolation.violationData[0] = optionTitle.text;
                linkedViolation.violationIndices[0] = Index;
            }
            violatoinSpawner.Instance.populateSubCategories(linkedViolation.violationIndices[0]);
            Text linkedText = linkedViolation.violationTabButtons[0].transform.GetChild(0).transform.GetChild(0).GetComponent<Text>();
            linkedText.text = optionTitle.text;
            linkedText.color = Color.white;
            linkedViolation.violationTabs[0].SetActive(false);
            linkedViolation.violationTabs[1].SetActive(true);
        }

        public void setSubCategory()
        {
            if (linkedViolation.violationData.Count == 1)
            {
                linkedViolation.violationData.Add(optionTitle.text);
                linkedViolation.violationIndices.Add(Index);
            }
            else
            {
                linkedViolation.violationData[1] = optionTitle.text;
                linkedViolation.violationIndices[1] = Index;
            }
            violatoinSpawner.Instance.populateViolations(linkedViolation.violationIndices[1]);
            Text linkedText = linkedViolation.violationTabButtons[1].transform.GetChild(0).transform.GetChild(0).GetComponent<Text>();
            linkedText.text = optionTitle.text;
            linkedText.color = Color.white;
            linkedViolation.violationTabs[1].SetActive(false);
            linkedViolation.violationTabs[2].SetActive(true);
        }

        public void setViolation()
        {
            if (linkedViolation.violationData.Count == 2)
            {
                linkedViolation.violationData.Add(optionTitle.text);
                linkedViolation.violationIndices.Add(Index);
            }
            else
            {
                linkedViolation.violationData[2] = optionTitle.text;
                linkedViolation.violationIndices[2] = Index;
            }
            Text linkedText = linkedViolation.violationTabButtons[2].transform.GetChild(0).transform.GetChild(0).GetComponent<Text>();
            linkedText.text = optionTitle.text;
            linkedText.color = Color.white;
            linkedViolation.violationTabs[2].SetActive(false);
            linkedViolation.violationTabs[3].SetActive(true);

        }

        public void setClassification()
        {
            if (linkedViolation.violationData.Count == 3)
            {
                linkedViolation.violationData.Add(optionTitle.text);
                linkedViolation.violationIndices.Add(Index);
            }
            else
            {
                linkedViolation.violationData[3] = optionTitle.text;
                linkedViolation.violationIndices[3] = Index;
            }
            Text linkedText = linkedViolation.violationTabButtons[3].transform.GetChild(0).transform.GetChild(0).GetComponent<Text>();
            linkedText.text = optionTitle.text;
            linkedText.color = Color.white;
            linkedViolation.violationTabs[3].SetActive(false);
            linkedViolation.violationTabs[4].SetActive(true);

        }

        public void setDueDate()
        { 
            Text linkedText = linkedViolation.violationTabButtons[4].transform.GetChild(0).transform.GetChild(0).GetComponent<Text>();

            if (linkedViolation.violationData.Count == 4)
            {
                if (optionContent.text.Length == 0)
                {
                    linkedViolation.violationData.Add(optionContent.placeholder.GetComponent<Text>().text);
                    linkedText.text = optionContent.placeholder.GetComponent<Text>().text;
                }
                else
                {

                    linkedViolation.violationData.Add(optionContent.text);
                    linkedText.text = optionContent.text;
                }
                linkedViolation.violationIndices.Add(Index);
            }
            else
            {

                if (optionContent.text.Length == 0)
                {
                    linkedViolation.violationData[4] = optionContent.placeholder.GetComponent<Text>().text;
                    linkedText.text = optionContent.placeholder.GetComponent<Text>().text;
                }
                else
                {

                    linkedViolation.violationData[4] = (optionContent.text);
                    linkedText.text = optionContent.text;
                }


                linkedViolation.violationIndices[4] = Index;
            }

            
            linkedText.color = Color.white;
            linkedViolation.violationTabs[4].SetActive(false);
            linkedViolation.violationTabs[5].SetActive(true);
        }


        public void setConditions()
        {

            Text linkedText = linkedViolation.violationTabButtons[5].transform.GetChild(0).transform.GetChild(0).GetComponent<Text>();

            if (linkedViolation.violationData.Count == 5)
            {
                if (optionContent.text.Length == 0)
                {
                    linkedViolation.violationData.Add(optionContent.placeholder.GetComponent<Text>().text);
                    linkedText.text = optionContent.placeholder.GetComponent<Text>().text;
                }
                else
                {

                    linkedViolation.violationData.Add(optionContent.text);
                    linkedText.text = optionContent.text;
                }
                linkedViolation.violationIndices.Add(Index);
            }
            else
            {

                if (optionContent.text.Length == 0)
                {
                    linkedViolation.violationData[5] = optionContent.placeholder.GetComponent<Text>().text;
                    linkedText.text = optionContent.placeholder.GetComponent<Text>().text;
                }
                else
                {

                    linkedViolation.violationData[5] = (optionContent.text);
                    linkedText.text = optionContent.text;
                }


                linkedViolation.violationIndices[5] = Index;
            }
            linkedText.color = Color.white;
            linkedViolation.violationIndices.Add(Index);
            linkedViolation.violationTabs[5].SetActive(false);
            linkedViolation.violationTabs[6].SetActive(true);
        }

        public void setRequirements()
        {
            Text linkedText = linkedViolation.violationTabButtons[6].transform.GetChild(0).transform.GetChild(0).GetComponent<Text>();
            if (linkedViolation.violationData.Count == 6)
            {
                if (optionContent.text.Length == 0)
                {
                    linkedViolation.violationData.Add(optionContent.placeholder.GetComponent<Text>().text);
                    linkedText.text = optionContent.placeholder.GetComponent<Text>().text;
                }
                else
                {

                    linkedViolation.violationData.Add(optionContent.text);
                    linkedText.text = optionContent.text;
                }
                linkedViolation.violationIndices.Add(Index);
            }
            else
            {

                if (optionContent.text.Length == 0)
                {
                    linkedViolation.violationData[6] = optionContent.placeholder.GetComponent<Text>().text;
                    linkedText.text = optionContent.placeholder.GetComponent<Text>().text;
                }
                else
                {

                    linkedViolation.violationData[6] = (optionContent.text);
                    linkedText.text = optionContent.text;
                }


                linkedViolation.violationIndices[6] = Index;
            }
            linkedText.color = Color.white;
            linkedViolation.violationIndices.Add(Index);
            linkedViolation.violationTabs[6].SetActive(false);
            linkedViolation.violationTabs[7].SetActive(true);
        }

        public void showViolationContent()
        {
            linkedViolation.violationContent.text = violatoinSpawner.Instance.Vios[Index];
        }
    }
}