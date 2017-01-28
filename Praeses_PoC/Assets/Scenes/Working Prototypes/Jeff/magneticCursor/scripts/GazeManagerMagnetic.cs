// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using UnityEngine;

namespace HoloToolkit.Unity
{
    /// <summary>
    /// GazeManager determines the location of the user's gaze, hit position and normals.
    /// </summary>
    public partial class GazeManagerMagnetic : Singleton<GazeManagerMagnetic>
    {
        /// <summary>
        /// Maximum gaze distance, in meters, for calculating a hit from a GameOjects Collider.
        /// </summary>
        [Tooltip("Maximum gaze distance, in meters, for calculating a hit.")]
        public float MaxGazeDistance = 15.0f;

        /// <summary>
        /// Select the layers raycast should target.
        /// </summary>
        [Tooltip("Select the layers raycast should target.")]
        public LayerMask RaycastLayerMask = Physics.DefaultRaycastLayers;

        /// <summary>
        /// Checking enables SetFocusPointForFrame to set the stabilization plane.
        /// </summary>
        [Tooltip("Checking enables SetFocusPointForFrame to set the stabilization plane.")]
        public bool SetStabilizationPlane = true;

        /// <summary>
        /// Lerp speed when moving focus point closer.
        /// </summary>
        [Tooltip("Lerp speed when moving focus point closer.")]
        public float LerpStabilizationPlanePowerCloser = 4.0f;

        /// <summary>
        /// Lerp speed when moving focus point farther away.
        /// </summary>
        [Tooltip("Lerp speed when moving focus point farther away.")]
        public float LerpStabilizationPlanePowerFarther = 7.0f;

        /// <summary>
        /// Use built in gaze stabilization that utilizes gavity wells.
        /// Change to false if you wish to use your own gabilization calculation
        /// and extend this class.
        /// </summary>
        [Tooltip("Use built in gaze stabilization that utilizes gavity wells.")]
        public bool UseBuiltInGazeStabilization = true;

        /// <summary>
        /// Physics.Raycast result is true if it hits a hologram.
        /// </summary>
        public bool Hit { get; private set; }

        /// <summary>
        /// HitInfo property gives access to RaycastHit public members.
        /// </summary>
        public RaycastHit HitInfo { get; private set; }

        /// <summary>
        /// Position of the intersection of the user's gaze and the holograms in the scene.
        /// </summary>
        public Vector3 Position { get; private set; }

        /// <summary>
        /// RaycastHit Normal direction.
        /// </summary>
        public Vector3 Normal { get; private set; }

        /// <summary>
        /// Object currently being focused on.
        /// </summary>
        public GameObject FocusedObject { get; private set; }

        /// <summary>
        /// Helper class that stabilizes gaze using gravity wells
        /// </summary>
        public GazeStabilizer GazeStabilization { get; private set; }

        private Vector3 gazeOrigin;
        private Vector3 gazeDirection;
        private Quaternion gazeRotation;
        private float lastHitDistance = 15.0f;

        public Vector3 gazeOffset;
        float magnetOn;
        bool magnetOnCounter;
        GameObject magnetFocus;
        bool readyMagnet;
        public bool mixerOn;
        public bool allowMagnetOff;

        private void Awake()
        {
            if (UseBuiltInGazeStabilization)
            {
                GazeStabilization = gameObject.GetComponent<GazeStabilizer>() ??
                                    gameObject.AddComponent<GazeStabilizer>();
            }
            readyMagnet = true;
            allowMagnetOff = true;
        }

        private void Update()
        {
            if (mixerOn) { 
            if (magnetOnCounter)
            {
                magnetOn -= Time.deltaTime;
                if (magnetOn < 0)
                {
                    magnetOnCounter = false;
                    magnetOn = 0;
                }
            }
        }
            gazeOrigin = Camera.main.transform.position;
            if (magnetFocus) {
                gazeDirection = Camera.main.transform.forward * (1 - magnetOn) + calculateDirection(Camera.main.transform, magnetFocus.transform) * magnetOn;
             }else
            {
                gazeDirection = Camera.main.transform.forward;
            }
            gazeRotation = Camera.main.transform.rotation;

            if (GazeStabilization != null)
            {
                GazeStabilization.UpdateHeadStability(gazeOrigin, gazeRotation);
            }

            UpdateRaycast();
            UpdateStabilizationPlane();
        }

        public virtual Vector3 calculateDirection(Transform camera, Transform focused )
        {
            var heading = camera.position - focused.position;
            var distance = heading.magnitude;
            var direction = heading / distance; // This is now the normalized direction.
            return -direction;
        }

        public void shakeOffMagnet()
        {
            if (allowMagnetOff) { 
            magnetOn = 0;
            print("magnetOff");
        }
        }

        /// <summary>
        /// Calculates the Raycast hit position and normal.
        /// </summary>
        private void UpdateRaycast()
        {
            // Get the raycast hit information from Unity's physics system.
            RaycastHit hitInfo;

            if (GazeStabilization != null)
            {
                Hit = Physics.Raycast(GazeStabilization.StableHeadRay, out hitInfo, MaxGazeDistance, RaycastLayerMask);
            }
            else
            {
                Hit = Physics.Raycast(gazeOrigin, gazeDirection, out hitInfo, MaxGazeDistance, RaycastLayerMask);
            }

            GameObject oldFocusedObject = FocusedObject;

            // Update the HitInfo property so other classes can use this hit information.
            HitInfo = hitInfo;

            if (Hit)
            {
                // If the raycast hits a hologram, set the position and normal to match the intersection point.
                Position = hitInfo.point;
                Normal = hitInfo.normal;
                lastHitDistance = hitInfo.distance;
                FocusedObject = hitInfo.collider.gameObject;
                if (FocusedObject.tag == "Button")
                {
                    if (readyMagnet) { 
                    magnetOn = 1;
                    magnetOnCounter = true;
                    readyMagnet = false;
                    magnetFocus = FocusedObject;
                    }
                }else if (FocusedObject.tag == "bigButton")
                {
                    if (readyMagnet)
                    {
                        magnetOn = 1;
                        magnetOnCounter = true;
                        readyMagnet = false;
                        magnetFocus = FocusedObject.transform.parent.gameObject;
                    }
                }
            }
            else
            {
                // If the raycast does not hit a hologram, default the position to last hit distance in front of the user,
                // and the normal to face the user.
                Position = gazeOrigin + (gazeDirection * lastHitDistance);
                Normal = -gazeDirection;
                FocusedObject = null;
            }

            // Check if the currently hit object has changed
            if (oldFocusedObject != FocusedObject)
            {
                if (oldFocusedObject != null)
                {
                    oldFocusedObject.SendMessage("OnGazeLeave", SendMessageOptions.DontRequireReceiver);
                    readyMagnet = true;
                }
                if (FocusedObject != null)
                {
                    FocusedObject.SendMessage("OnGazeEnter", SendMessageOptions.DontRequireReceiver);
                }
            }

        }

        /// <summary>
        /// Adds the stabilization plane modifier if it's enabled and if it doesn't exist yet.
        /// </summary>
        private void UpdateStabilizationPlane()
        {
            // We want to use the stabilization logic.
            if (SetStabilizationPlane)
            {
                // Check if it exists in the scene.
                if (StabilizationPlaneModifier.Instance == null)
                {
                    // If not, add it to us.
                    gameObject.AddComponent<StabilizationPlaneModifier>();
                }
            }

            if (StabilizationPlaneModifier.Instance != null)
            {
                StabilizationPlaneModifier.Instance.SetStabilizationPlane = SetStabilizationPlane;
            }
        }
    }
}