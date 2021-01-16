using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Turbo
{
    /// <summary>
    /// Contains information about the axle specific to the car type
    /// </summary>
    [System.Serializable]
    public class AxleData
    {
        /// <summary>
        /// Direction of the axle
        /// </summary>
        public string directionName;

        /// <summary>
        /// The WheelCollider of the left wheel
        /// </summary>
        public WheelCollider leftWheel;

        /// <summary>
        /// The WheelCollider of the right wheel
        /// </summary>
        public WheelCollider rightWheel;

        /// <summary>
        /// Is a motor attached to this axle or wheel
        /// </summary>
        public bool motor;

        /// <summary>
        /// Can this axle or wheel steer 
        /// </summary>
        public bool steering;
    }
}