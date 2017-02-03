using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoloToolkit.Unity
{
    public class MagnetManager : Singleton<MagnetManager>
    {
        public bool magnetOn;
        public float lerpTime;
        float lerpTimer;
        bool lerpStart;

        private void lerper()
        {
           if (!lerpStart)
            {
                lerpStart = true;
                lerpTimer = lerpTime;
            }
            
        }

        private void Update()
        {
            if (magnetOn)
            {
                lerper();
            }

            if (lerpTimer > 0)
            {
                lerpTimer -= Time.deltaTime;
            }else if(lerpTimer == 0)
            {
                lerpStart = false;
            }
        }

        public virtual float normalize(float varA, float varB)
        {
            float result;
            result = varA / varB;
            return result;
        }

        public virtual Vector3 GazeDirUpdate(Vector3 cameraDir)
        {
            Vector3 tentativeGazeDir;
            if (magnetOn)
            {
                if (lerpTime > 0)
                {
                    tentativeGazeDir = cameraDir * normalize(lerpTimer, lerpTime) + calculateDirection(Camera.main.transform, GazeManager.Instance.FocusedObject.transform) * (1 - normalize(lerpTimer, lerpTime));
                }
                else
                {
                    tentativeGazeDir = calculateDirection(Camera.main.transform, GazeManager.Instance.FocusedObject.transform);
                }
            }else{ 
            tentativeGazeDir = cameraDir;
            }
            return tentativeGazeDir;
        }

        public virtual Vector3 calculateDirection(Transform camera, Transform focused)
        {
            var heading = camera.position - focused.position;
            var distance = heading.magnitude;
            var direction = heading / distance; // This is now the normalized direction.
            return -direction;
        }

    }
}
