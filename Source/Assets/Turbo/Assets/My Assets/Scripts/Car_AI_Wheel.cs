using UnityEngine;

namespace Turbo
{
    /// <summary>
    /// To mimic the virtual wheel movement
    /// </summary>
    public class Car_AI_Wheel : MonoBehaviour
    {
        /// <summary>
        /// The target wheel 
        /// </summary>
        public WheelCollider targetWheel;

        /// <summary>
        /// The position of the virtual wheel
        /// </summary>
        public Vector3 wheelPosition = new Vector3();

        /// <summary>
        /// The rotation of the virtual wheel
        /// </summary>
        public Quaternion wheelRotation = new Quaternion();

        /// <summary>
        /// The Y rotation of the car
        /// </summary>
        private float wheelRotationY;

        /// <summary>
        /// Runs during script initialisation
        /// </summary>
        private void Awake()
        {
            wheelRotationY = transform.localEulerAngles.y;
        }

        /// <summary>
        /// Runs once on the first frame
        /// </summary>
        private void Start()
        {
            //properly setup the wheel orientation when the car has been instantiated
            if (wheelRotationY == 270)
            {
                wheelRotationY = 270f;
            }
            else if (wheelRotationY == 90)
            {
                wheelRotationY = 90f;
            }
        }

        /// <summary>
        /// Runs every frame
        /// </summary>
        private void Update()
        {
            //output the position and rotation of the virtual wheel
            targetWheel.GetWorldPose(out wheelPosition, out wheelRotation);

            //make the physical wheels move
            transform.position = wheelPosition;

            //make the physical wheels rotate
            transform.rotation = wheelRotation * Quaternion.Euler(0f, wheelRotationY, 0f);
        }

    }
}