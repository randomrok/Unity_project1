using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Motobike
{
    [RequireComponent(typeof(motorbike_controller))]
    public class Motobike_user_control : MonoBehaviour
    {
        private motorbike_controller m_Car; // the controller we want to use


        private void Awake()
        {
            // get the controller
            m_Car = GetComponent<motorbike_controller>();
        }


        private void FixedUpdate()
        {
            // pass the input to the car!
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            float v = CrossPlatformInputManager.GetAxis("Vertical");
#if !MOBILE_INPUT
            float handbrake = CrossPlatformInputManager.GetAxis("Jump");
            m_Car.Move(h, v, v, handbrake);
#else
            m_Car.Move(h, v, v, 0f);
#endif
        }
    }
}