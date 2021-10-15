using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

// [System.Serializable]
// public class PrimaryButtonEvent : UnityEvent<bool>
// {
// }
//
// public class PrimaryButtonWatcher : MonoBehaviour
// {
//     public PrimaryButtonEvent primaryButtonPress;
//     private bool lastButtonState = false;
//     private List<UnityEngine.XR.InputDevice> allDevices;
//     private List<UnityEngine.XR.InputDevice> devicesWithPrimaryButton;
//
//     void Start()
//     {
//         if (primaryButtonPress == null)
//         {
//             primaryButtonPress = new PrimaryButtonEvent();
//         }
//
//         allDevices = new List<UnityEngine.XR.InputDevice>();
//         devicesWithPrimaryButton = new List<UnityEngine.XR.InputDevice>();
//         InputTracking.nodeAdded += InputTracking_nodeAdded;
//     }
//
//     // check for new input devices when new XRNode is added
//     private void InputTracking_nodeAdded(XRNodeState obj)
//     {
//         updateInputDevices();
//     }
//
//     void Update()
//     {
//         bool tempState = false;
//         bool invalidDeviceFound = false;
//         foreach (var device in devicesWithPrimaryButton)
//         {
//             bool buttonState = false;
//             tempState = device.isValid // the device is still valid
//                         && device.TryGetFeatureValue(CommonUsages.primaryButton, out buttonState) // did get a value
//                         && buttonState // the value we got
//                         || tempState; // cumulative result from other controllers
//
//             if (!device.isValid)
//                 invalidDeviceFound = true;
//         }
//
//         if (tempState != lastButtonState) // Button state changed since last frame
//         {
//             primaryButtonPress.Invoke(tempState);
//             lastButtonState = tempState;
//         }
//
//         if (invalidDeviceFound || devicesWithPrimaryButton.Count == 0) // refresh device lists
//             updateInputDevices();
//     }
//
//     // find any devices supporting the desired feature usage
//     void updateInputDevices()
//     {
//         devicesWithPrimaryButton.Clear();
//         UnityEngine.XR.InputDevices.GetDevices(allDevices);
//         bool discardedValue;
//
//         foreach (var device in allDevices)
//         {
//             if (device.TryGetFeatureValue(CommonUsages.primaryButton, out discardedValue))
//             {
//                 devicesWithPrimaryButton.Add(device); // Add any devices that have a primary button.
//             }
//         }
//     }
// }
//
//
// public class PrimaryReactor : MonoBehaviour
// {
//     public PrimaryButtonWatcher watcher;
//     public bool IsPressed = false; // public to show button state in the Unity Inspector window
//
//     void Start()
//     {
//         watcher.primaryButtonPress.AddListener(onPrimaryButtonEvent);
//     }
//
//     public void onPrimaryButtonEvent(bool pressed)
//     {
//         IsPressed = pressed;
//         if (pressed)
//         {
//             var playerCam = GameObject.Find("Main Camera").transform;
//             float throwForce = 20;
//             GetComponent<Rigidbody>().AddForce(playerCam.forward * throwForce);
//         }
//     }
// }

public class ThrowTheBall : MonoBehaviour
{
    // public PrimaryButtonWatcher watcher;
    // public bool IsPressed = false; // public to show button state in the Unity Inspector window
    //
    // void Start()
    // {
    //     watcher.primaryButtonPress.AddListener(onPrimaryButtonEvent);
    // }
    //
    // public void onPrimaryButtonEvent(bool pressed)
    // {
    //     IsPressed = pressed;
    //     if (pressed)
    //     {
    //         GetComponent<Rigidbody>().isKinematic = false;
    //         transform.parent = null;
    //         var playerCam = GameObject.Find("Main Camera").transform;
    //         float throwForce = 20;
    //         GetComponent<Rigidbody>().AddForce(playerCam.forward * throwForce);
    //     }
    // }

    public Transform hand;

    public void ThrowObject(SelectExitEventArgs eventArgs)
    {
        hand = eventArgs.interactor.transform;
        float throwForce = 200;
        float throwForceUp = 50;
        GetComponent<Rigidbody>().AddForce(hand.transform.forward.normalized * throwForce);
        GetComponent<Rigidbody>().AddForce(hand.transform.up* throwForceUp);
    }
}
