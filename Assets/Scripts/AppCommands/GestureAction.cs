// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using HoloToolkit.Unity.InputModule;
using UnityEngine;

namespace Academy
{
    /// <summary>
    /// GestureAction performs custom actions based on 
    /// which gesture is being performed.
    /// </summary>
    public class GestureAction : MonoBehaviour, INavigationHandler, IManipulationHandler, ISpeechHandler
    {
        [Tooltip("Rotation max speed controls amount of rotation.")]
        [SerializeField]
        private float RotationSensitivity = 1.0f;

        private bool isNavigationEnabled = false;
        public bool IsNavigationEnabled
        {
            get { return isNavigationEnabled; }
            set { isNavigationEnabled = value; }
        }

        private Vector3 manipulationOriginalPosition = Vector3.zero;

        void INavigationHandler.OnNavigationStarted(NavigationEventData eventData)
        {
            InputManager.Instance.PushModalInputHandler(gameObject);
        }

        void INavigationHandler.OnNavigationUpdated(NavigationEventData eventData)
        {
            if (isNavigationEnabled)
            {
                /* TODO: DEVELOPER CODING EXERCISE 2.c */

                // 2.c: Calculate a float rotationFactor based on eventData's NormalizedOffset.x multiplied by RotationSensitivity.
                // This will help control the amount of rotation.
                float rotationFactorX = eventData.NormalizedOffset.x * RotationSensitivity;
                float rotationFactorY = eventData.NormalizedOffset.y * RotationSensitivity;
                float rotationFactorZ = eventData.NormalizedOffset.z * RotationSensitivity;

                // 2.c: transform.Rotate around the Y axis using rotationFactor.
                transform.Rotate(new Vector3(-1 * rotationFactorY, -1 * rotationFactorZ, -1 * rotationFactorX));
            }
        }

        void INavigationHandler.OnNavigationCompleted(NavigationEventData eventData)
        {
            InputManager.Instance.PopModalInputHandler();
        }

        void INavigationHandler.OnNavigationCanceled(NavigationEventData eventData)
        {
            InputManager.Instance.PopModalInputHandler();
        }

        void IManipulationHandler.OnManipulationStarted(ManipulationEventData eventData)
        {
            if (!isNavigationEnabled)
            {
                InputManager.Instance.PushModalInputHandler(gameObject);

                manipulationOriginalPosition = transform.position;
            }
        }

        void IManipulationHandler.OnManipulationUpdated(ManipulationEventData eventData)
        {
            if (!isNavigationEnabled)
            {
                /* TODO: DEVELOPER CODING EXERCISE 4.a */

                // 4.a: Make this transform's position be the manipulationOriginalPosition + eventData.CumulativeDelta
                transform.position = manipulationOriginalPosition + eventData.CumulativeDelta;
            }
        }

        void IManipulationHandler.OnManipulationCompleted(ManipulationEventData eventData)
        {
            InputManager.Instance.PopModalInputHandler();
        }

        void IManipulationHandler.OnManipulationCanceled(ManipulationEventData eventData)
        {
            InputManager.Instance.PopModalInputHandler();
        }

        void ISpeechHandler.OnSpeechKeywordRecognized(SpeechEventData eventData)
        {
            //if (eventData.RecognizedText.ToLower().Equals("move"))
            //{
            //    isNavigationEnabled = false;
            //}
            //else if (eventData.RecognizedText.ToLower().Equals("rotate"))
            //{
            //    isNavigationEnabled = true;
            //}
            //else
            //{
            //    return;
            //}

            eventData.Use();
        }

        public void onSizeUp()
        {
            Debug.Log("Increasing object size");
            this.transform.localScale += new Vector3(1, 1, 1);

        }

        public void onSizeDown()
        {
            if (transform.localScale.x > 1 && transform.localScale.y > 1 && transform.localScale.z > 1)
            {
                Debug.Log("Decreasing object size");
                this.transform.localScale -= new Vector3(1, 1, 1);

            }

        }
    }
    
}