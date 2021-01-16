using System.Collections.Generic;
using UnityEngine;

namespace Turbo
{
    /// <summary>
    /// The AI for the car
    /// </summary>
    public class Car_AI : MonoBehaviour
    {
        [Header("AI data")]
        /// <summary>
        /// The AI data
        /// </summary>
        [SerializeField]
        private AI_Manager aiData;


        [Header("Car Waypoint")]
        /// <summary>
        /// Return the path this car will take
        /// </summary>
        [SerializeField]
        private Transform path;

        /// <summary>
        /// Return all the nodes in this scene
        /// </summary>
        [SerializeField]
        private List<Transform> nodes;

        /// <summary>
        /// Keep track of the nodes
        /// </summary>
        [SerializeField]
        private int currentNode = 0;


        [Header("Car Setup")]
        /// <summary>
        /// maximum steer Angle of the car AI
        /// </summary>
        [SerializeField]
        private float maxSteerAngle;

        /// <summary>
        /// The WheelCollider of the car(frontLeftWheel)
        /// </summary>
        [SerializeField]
        private WheelCollider frontLeftWheel;

        /// <summary>
        /// The WheelCollider of the car(frontRightWheel)
        /// </summary>
        [SerializeField]
        private WheelCollider frontRightWheel;
        
        /// <summary>
        /// The WheelCollider of the car(frontLeftWheel)
        /// </summary>
        [SerializeField]
        private WheelCollider RearLeftWheel;

        /// <summary>
        /// The WheelCollider of the car(frontRightWheel)
        /// </summary>
        [SerializeField]
        private WheelCollider RearRightWheel;

        /// <summary>
        /// Max forward force applied
        /// </summary>
        [SerializeField]
        private float maxMotorTorque;

        /// <summary>
        /// The current speed of the car
        /// </summary>
        private float currentSpeed;

        /// <summary>
        /// The max speed of the car
        /// </summary>
        [SerializeField]
        private float maxSpeed;

        /// <summary>
        /// Former position of the car
        /// </summary>
        private Vector3 previousPosition;

        /// <summary>
        /// Brake Torque of the car
        /// </summary>
        public float maxBrakeTorque;

        /// <summary>
        /// is the car braking 
        /// </summary>
        private bool isBraking;

        /// <summary>
        /// store the brake object
        /// </summary>
        public GameObject brakeObject;

        /// <summary>
        /// The car root child of this gameobject
        /// </summary>
        [SerializeField]
        private Transform carRoot;


        [Header("Car Materials")]
        /// <summary>
        /// the material of the red headlights
        /// </summary>
        public Material brakeLight_On;

        /// <summary>
        /// the material of the  headlights when off
        /// </summary>
        public Material brakeLight_Off;

        /// <summary>
        /// store the recent car material
        /// </summary>
        private Material[] carMaterials;

       

        [Header("Sensors")]
        public GameObject sensors;
        public List<Rays> rays;
        public bool avoiding = false;

        [Header("Light")]
        public CarLight carLight;

        private void Awake()
        {
            if (maxMotorTorque >= 1000)
            {
                maxBrakeTorque = 650f;
            }
            else
            {
                maxBrakeTorque = 500f;
            }
        }

        private void Start()
        {
            rays = new List<Rays>();

            for (int i = 0; i < sensors.transform.childCount; i++)
            {
                rays.Add(sensors.transform.GetChild(i).GetComponent<Rays>());
            }

            previousPosition = transform.GetChild(0).position;

            aiData = GetComponent<AI_Manager>();

            //return the transform of each node
            Transform[] path_transforms = path.GetComponentsInChildren<Transform>();

            //make the list empty in the begining
            nodes = new List<Transform>();

            //loop through each path_transform
            for (int i = 0; i < path_transforms.Length; i++)
            {
                //if the path transform is different from this transform 
                if (path_transforms[i] != path.transform)
                {
                    //add the transform to the nodes  
                    nodes.Add(path_transforms[i]);
                }
            }

            carMaterials = new Material[brakeObject.GetComponent<MeshRenderer>().materials.Length];

            carMaterials = brakeObject.GetComponent<MeshRenderer>().materials;
        }

        private void Update()
        {
            Braking();
        }

        //Handle Plysics
        private void FixedUpdate()
        {
            Sensors();

            ApplySteer();

            Drive();

            CheckWayPointDistance();
        }

        /// <summary>
        /// Check for anything hitting the sensors
        /// </summary>
        private void Sensors()
        {
            float avoid_multiplier = 0;

            //Front Middle Ray
            if (rays[0].hitObject == true)
            {
                if (rays[0].CompareTag("Front Middle Sensor"))
                {
                    //hit middle Sensor
                    //print(ray.tag);

                    //brake
                    isBraking = true;

                    avoiding = true;
                }
            }

            //Front Left Ray
            if (rays[1].hitObject == true)
            {
                if (rays[1].CompareTag("Front Left Sensor"))
                {
                    //hit Front left sensor
                    //print(ray.tag);

                    //brake
                    isBraking = true;

                    //steer right
                    avoiding = true;
                    avoid_multiplier += 0.5f;
                }
            }
            //Left Angled Ray
            else if (rays[2].hitObject == true)
            {
                if (rays[2].CompareTag("Left Angled Sensor"))
                {
                    //hit Left Angled Sensor
                    //print(ray.tag);

                    //brake
                    isBraking = true;

                    //steer right
                    avoiding = true;
                    avoid_multiplier += 1f;
                }
            }

            //Front Right Ray
            if (rays[3].hitObject == true)
            {
                if (rays[3].CompareTag("Front Right Sensor"))
                {
                    //hit Front right sensor
                    //print(ray.tag);

                    //brake
                    isBraking = true;

                    //steer left
                    avoiding = true;
                    avoid_multiplier -= 0.5f;
                }
            }
            //Right Angled Ray
            else if (rays[4].hitObject == true)
            {
                if (rays[4].CompareTag("Right Angled Sensor"))
                {
                    //hit right angled sensor
                    //print(ray.tag);

                    //brake
                    isBraking = true;

                    //steer left
                    avoiding = true;
                    avoid_multiplier -= 1f;
                }
            }

            if (rays[0].hitObject == false && rays[1].hitObject == false && rays[2].hitObject == false && rays[3].hitObject == false && rays[4].hitObject == false)
            {
                //avoiding is false
                avoiding = false;

                //braking is false
                isBraking = false;
            }

            if (avoiding == true)
            {
                frontLeftWheel.steerAngle = maxSteerAngle * avoid_multiplier;

                frontRightWheel.steerAngle = maxSteerAngle * avoid_multiplier;
            }
        }

        /// <summary>
        /// Apply Steering to the car AI
        /// </summary>
        private void ApplySteer()
        {
            if (avoiding == true)
            {
                return;
            }

            //store the relative vector of this car to the waypoint which would be used to steer the car in that direction
            Vector3 relative_vector = carRoot.InverseTransformPoint(nodes[currentNode].position);

            //vary the steering
            float random_x = 0f;
            float random_z = 0f;
            Vector3 new_relative_vector = Vector3.zero;

            if (aiData.perfectDriving == true)
            {
                float new_steer_angle = ((relative_vector.x) / relative_vector.magnitude) * maxSteerAngle;

                frontLeftWheel.steerAngle = new_steer_angle;

                frontRightWheel.steerAngle = new_steer_angle;
            }
            else
            {
                //setup the ai data values
                aiData.Setup(out random_x, out random_z);

                //Debug.Log("x :" + random_x);
                //Debug.Log("z :" + random_z);

                if (aiData.operation == "+")
                {

                    new_relative_vector = new Vector3(relative_vector.x + random_x, relative_vector.y, relative_vector.z + random_z);
                }
                else if ((aiData.operation == "-"))
                {
                    new_relative_vector = new Vector3(relative_vector.x - random_x, relative_vector.y, relative_vector.z - random_z);
                }


                //steer angle of the wheel of the car

                float new_steer_angle = ((new_relative_vector.x) / new_relative_vector.magnitude) * maxSteerAngle;

                frontLeftWheel.steerAngle = new_steer_angle;

                frontRightWheel.steerAngle = new_steer_angle;
            }
            

            


        }

        /// <summary>
        /// Drive Towards to point
        /// </summary>
        private void Drive()
        {
            //speed is d/t
            //find the distance bvetween 2 points
            currentSpeed = Vector3.Distance(previousPosition, transform.GetChild(0).position);

            //distance / time
            currentSpeed /= Time.deltaTime;

            //Debug.Log(currentSpeed);

            //if the current speed is less than the max speed and the car is not braking
            if (currentSpeed < maxSpeed && !isBraking)
            {
                //apply the motortorque
                RearLeftWheel.motorTorque = maxMotorTorque;
                RearRightWheel.motorTorque = maxMotorTorque;
            }
            else
            {
                //let the car tires roll
                RearLeftWheel.motorTorque = 0;
                RearRightWheel.motorTorque = 0;
            }

            //the new previous position becomes this position
            previousPosition = transform.GetChild(0).position;
        }

        //Check Distance between nodes
        private void CheckWayPointDistance()
        { 
            float distance = Vector3.Distance(carRoot.position, nodes[currentNode].position);

            if (distance < 20)
            {
                if (currentNode == nodes.Count - 1)
                {
                    currentNode = 0;
                }

                else
                {
                    currentNode += 1;
                }
            }
        }

        /// <summary>
        /// To enable the ai car to brake
        /// </summary>
        public void Braking()
        {
            //if the car is currently braking
            if (isBraking)
            {
                //if the ai car name is megamo
                if (aiData.car._name == "Megamo")
                {
                    //Debug.Log("Braking");

                    //change the car material
                    brakeObject.GetComponent<MeshRenderer>().materials = new Material[7] { carMaterials[0], carMaterials[1], carMaterials[2], carMaterials[3], carMaterials[4], carMaterials[5], brakeLight_On };

                    carLight.TurnOnLights(carLight.rearLights);

                    //let the car roll
                    RearLeftWheel.motorTorque = 0;
                    RearRightWheel.motorTorque = 0;

                    //apply the brake torque
                    RearLeftWheel.brakeTorque = maxBrakeTorque;
                    RearRightWheel.brakeTorque = maxBrakeTorque;
                }
                //if the ai car name is chrollo
                else if (aiData.car._name == "Chrollo")
                {
                    //Debug.Log("Braking");

                    //change the car material
                    brakeObject.GetComponent<MeshRenderer>().materials = new Material[7] { carMaterials[0], carMaterials[1], brakeLight_On, carMaterials[3], carMaterials[4], carMaterials[5], carMaterials[6] };

                    //let the car roll
                    RearLeftWheel.motorTorque = 0;
                    RearRightWheel.motorTorque = 0;

                    //apply the brake torque
                    RearLeftWheel.brakeTorque = maxBrakeTorque;
                    RearRightWheel.brakeTorque = maxBrakeTorque;
                }

                
            }
            //if the car is not braking
            else
            {
                //if the ai car name is megamo
                if (aiData.car._name == "Megamo")
                {
                    //Debug.Log("Not Braking");

                    //change the car material
                    brakeObject.GetComponent<MeshRenderer>().materials = new Material[7] { carMaterials[0], carMaterials[1], carMaterials[2], carMaterials[3], carMaterials[4], carMaterials[5], brakeLight_Off };

                    carLight.TurnOffLights(carLight.rearLights);

                    //apply the brake torque
                    RearLeftWheel.brakeTorque = 0;
                    RearRightWheel.brakeTorque = 0;
                }
                //if the ai car name is chrollo
                else if (aiData.car._name == "Chrollo")
                {
                    //Debug.Log("Not braking");

                    //change the car material
                    brakeObject.GetComponent<MeshRenderer>().materials = new Material[7] { carMaterials[0], carMaterials[1], brakeLight_Off, carMaterials[3], carMaterials[4], carMaterials[5], carMaterials[6] };

                    //apply the brake torque
                    RearLeftWheel.brakeTorque = 0;
                    RearRightWheel.brakeTorque = 0;
                }
               

            }
        }
    }

}