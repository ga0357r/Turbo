using UnityEngine;

namespace Turbo
{
    [System.Serializable]
    public class Location
    {
        /// <summary>
        /// location transform 
        /// </summary>
        public Transform locationTransform;

        /// <summary>
        /// is this location occupied
        /// </summary>
        public bool isOccupied;
    }
}