using UnityEngine;

namespace Turbo
{
    public class PlayerWheels : MonoBehaviour
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


        private float wheelRotationY;

        private void Awake()
        {
            wheelRotationY = transform.localEulerAngles.y;
        }

        private void Start()
        {
            if (wheelRotationY == 270)
            {
                wheelRotationY = 90f;
            }
            else if (wheelRotationY == 90f)
            {
                wheelRotationY = 270f;
            }
        }
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