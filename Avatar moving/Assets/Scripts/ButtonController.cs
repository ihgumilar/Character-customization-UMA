using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.Events;

namespace Gumilar.VR
{
    public class ButtonController : MonoBehaviour
    {
        // 1. We'll select a label from the Unity inspector
        // 2. We'll find the object that corresponds to that label
        // 2.1. We need to get the label of the user selection
        // 2.2 Find the object in the dictionary

        // 3. We need to use the object we found (done)

        static readonly Dictionary<string, InputFeatureUsage<bool>> availableFeatures = new Dictionary<string, InputFeatureUsage<bool>>
        {
            { "triggerButton", CommonUsages.triggerButton },
            { "gripButton", CommonUsages.gripButton },
            { "thumbrest", CommonUsages.thumbrest },
            { "primary2DAxisClick", CommonUsages.primary2DAxisClick },
            { "primary2DAxisTouch", CommonUsages.primary2DAxisTouch },
            { "menuButton", CommonUsages.triggerButton },
            { "secondaryButton", CommonUsages.secondaryButton },
            { "secondaryTouch", CommonUsages.secondaryTouch },
            { "primaryButton", CommonUsages.primaryButton },
            { "primaryTouch", CommonUsages.primaryTouch },
        };

        public enum FeatureOptions
        {
            triggerButton,
            gripButton,
            thumbrest,
            primary2DAxisClick,
            primary2DAxisTouch,
            menuButton,
            secondaryButton,
            secondaryTouch,
            primaryButton
        }
                        
        [Tooltip("Input device role (left / right hand)")]
        public InputDeviceRole deviceRole;

        [Tooltip("Select an input feature")]
        public FeatureOptions feature;

        [Tooltip("Event when the button starts being pressed")]
        public UnityEvent OnPress;

        [Tooltip("Event when the button is released")]
        public UnityEvent OnRelease;

        // Keep devices that are detected
        List<InputDevice> listDevices;

        // Keep value of the button press
        bool listInputValue;

        // Keep track of whether we are pressing the button
        bool isPressed;

        // Selected feature object
        InputFeatureUsage<bool> selectedFeature;
     
      
        void Awake()
        {
            listDevices = new List<InputDevice>();
            
            // Get label selected by the user
            string featureLabel = Enum.GetName(typeof(FeatureOptions), feature);

            // Find dictionary entry
            availableFeatures.TryGetValue(featureLabel, out selectedFeature);

        }
        
        // Update is called once per frame
        void Update()
        {
            // Get the device we want to check
            InputDevices.GetDevicesWithRole(deviceRole, listDevices);

            // Go through our devices
            for(int i = 0; i < listDevices.Count; i++)
            {

                // Check whether our button is being pressed
                // 1) Check whether we can read the state of our button
                // 2) The button's value should be true
                if (listDevices[i].TryGetFeatureValue(selectedFeature, out listInputValue) && listInputValue)
                {
                    // Check if we are already pressing
                    if (!isPressed)
                    {
                        // Update the flag
                        isPressed = true;

                        // Trigger the OnPress event
                        OnPress.Invoke();
                    }
                else if (isPressed)
                    {
                        // Update our flag
                        isPressed = !isPressed;

                        // Trigger the OnRelease event
                        OnRelease.Invoke();
                    }

                    
                    // Say hello on the console
                    Debug.Log("Being pressed");
                }


               
            }


        }
    }
}