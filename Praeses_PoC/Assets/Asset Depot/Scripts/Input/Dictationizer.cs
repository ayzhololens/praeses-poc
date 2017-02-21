using HoloToolkit;
using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;
using HoloToolkit.Unity.InputModule;


namespace HoloToolkit.Unity
{


    public class Dictationizer : MonoBehaviour
    {

        private DictationRecognizer dictationRecognizer;
        public Text DictationDisplay;
        private StringBuilder textSoFar;
        public annotationManager annotMananger;
        public KeywordManager keyWordManager;
        bool inProgress;


        // Use this for initialization
        void Start()
        {
            inProgress = false;
            PhraseRecognitionSystem.Restart();
            keyWordManager = GameObject.Find("InputManager").GetComponent<KeywordManager>();
            annotMananger = GameObject.Find("AnnotationManager").GetComponent<annotationManager>();
            setUpDictation();

            //keyWordManager.enabled = false;








        }



        // Update is called once per frame
        void Update()
        {

        }

        void setUpDictation()
        {
            textSoFar = new StringBuilder();
            dictationRecognizer = new DictationRecognizer();
            dictationRecognizer.DictationHypothesis += DictationRecognizer_DictationHypothesis;
            dictationRecognizer.DictationResult += DictationRecognizer_DictationResult;
            dictationRecognizer.DictationComplete += DictationRecognizer_DictationComplete;
            dictationRecognizer.DictationError += DictationRecognizer_DictationError;
        }

        private void DictationRecognizer_DictationResult(string text, ConfidenceLevel confidence)
        {
            // do something
            textSoFar.Append(text + ". ");
            DictationDisplay.text = textSoFar.ToString();
        }

        private void DictationRecognizer_DictationHypothesis(string text)
        {
            // do something

            DictationDisplay.text = textSoFar.ToString() + " " + text + "...";
        }

        public void DictationRecognizer_DictationComplete(DictationCompletionCause cause)
        {
            // do something
            dictationRecognizer.DictationResult -= DictationRecognizer_DictationResult;
            dictationRecognizer.DictationComplete -= DictationRecognizer_DictationComplete;
            dictationRecognizer.DictationHypothesis -= DictationRecognizer_DictationHypothesis;
            dictationRecognizer.DictationError -= DictationRecognizer_DictationError;
            dictationRecognizer.Dispose();
        }

        private void DictationRecognizer_DictationError(string error, int hresult)
        {
            // do something
        }

        public void startDiction()
        {
            if (!inProgress)
            {
                inProgress = true;
                setUpDictation();
                PhraseRecognitionSystem.Shutdown();
                DictationDisplay.text = "Speech to text started.  Begin dictating";
                dictationRecognizer.Start();
                annotMananger.StartDictation();
                annotMananger.activeDictationBox = this.gameObject;
                GetComponent<BoxCollider>().enabled = false;
            }


        }

        public void stopDiction()
        {
            dictationRecognizer.Stop();
            dictationRecognizer.DictationResult -= DictationRecognizer_DictationResult;
            dictationRecognizer.DictationComplete -= DictationRecognizer_DictationComplete;
            dictationRecognizer.DictationHypothesis -= DictationRecognizer_DictationHypothesis;
            dictationRecognizer.DictationError -= DictationRecognizer_DictationError;
            dictationRecognizer.Dispose();
            PhraseRecognitionSystem.Restart();
            inProgress = false;
            GetComponent<BoxCollider>().enabled = true;
        }




    }
}
