using UnityEngine;

namespace Turbo
{
    public class Rays : MonoBehaviour
    {
        public RaycastHit hit;
        public float rayDistance;
        public bool hitObject = false;
        public string objectTag;

        private void Start()
        {
            objectTag = tag;
        }

        private void FixedUpdate()
        {
            if (CompareTag("Front Middle Sensor"))
            {
                if (Physics.Raycast(transform.position, transform.right, out hit, rayDistance))
                {
                    Debug.DrawLine(transform.position, hit.point);
                    hitObject = true;
                }
                else if (hit.collider == null)
                {
                    hitObject = false;

                }
            }

            else if (CompareTag("Front Left Sensor"))
            {
                if (Physics.Raycast(transform.position, transform.right, out hit, rayDistance))
                {
                    Debug.DrawLine(transform.position, hit.point);
                    hitObject = true;
                }
                else if (hit.collider == null)
                {
                    hitObject = false;

                }
            }

            else if (CompareTag("Front Right Sensor"))
            {
                if (Physics.Raycast(transform.position, transform.right, out hit, rayDistance))
                {
                    Debug.DrawLine(transform.position, hit.point);
                    hitObject = true;
                }
                else if (hit.collider == null)
                {
                    hitObject = false;

                }
            }

            else if (CompareTag("Left Angled Sensor"))
            {
                if (Physics.Raycast(transform.position, Quaternion.AngleAxis(60, transform.up) * transform.forward, out hit, rayDistance))
                {
                    Debug.DrawLine(transform.position, hit.point);
                    hitObject = true;
                }
                else if (hit.collider == null)
                {
                    hitObject = false;

                }


            }
            else if (CompareTag("Right Angled Sensor"))
            {

                if (Physics.Raycast(transform.position, Quaternion.AngleAxis(120, transform.up) * transform.forward, out hit, rayDistance))
                {
                    Debug.DrawLine(transform.position, hit.point);
                    hitObject = true;
                }
                else if (hit.collider == null)
                {
                    hitObject = false;

                }
            }


        }
    }
}
