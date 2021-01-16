using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Turbo
{
         
    public class Player : MonoBehaviour
    {

        /// <summary>
        /// Instance of Car class
        /// </summary>
        [SerializeField]
        private Car car;

        /// <summary>
        /// Information about the axles
        /// </summary>
        [SerializeField]
        private List<AxleData> axles;

        /// <summary>
        /// Maximum Rotational Force the motor can apply to the wheel
        /// </summary>
        public float maxMotorTorque;

        /// <summary>
        /// Max steering angle the wheel can have
        /// </summary>
        public float maxSteeringAngle;

        /// <summary>
        /// The torque applied when braking
        /// </summary>
        public float brakeTorque;

        /// <summary>
        /// The force applied to the car wheels to make it rotate
        /// </summary>
        private float motor;

        /// <summary>
        /// store the car materials
        /// </summary>
        public Material[] carMaterials;

        /// <summary>
        /// store the brake object
        /// </summary>
        public GameObject brakeObject;

        /// <summary>
        /// store the material when the brake light is on, red
        /// </summary>
        public Material brakeLight_On;

        /// <summary>
        /// store the material when the brake light is off, white
        /// </summary>
        public Material brakeLight_Off;

        /// <summary>
        /// Reference to the car light
        /// </summary>
        public CarLight carLight;

        private void Awake()
        {
            
        }

        private void Start()
        {
            //generate car data
            car = new Car(SpawnPlayer.carData._name, SpawnPlayer.carData._id, SpawnPlayer.carData._ref);

            //find the brake object
            brakeObject = transform.GetChild(0).transform.Find("Car Body").gameObject;

            //store the car materials
            carMaterials = new Material[brakeObject.GetComponent<MeshRenderer>().materials.Length];
            carMaterials = brakeObject.GetComponent<MeshRenderer>().materials;
        }

        /// <summary>
        /// Runs every frame
        /// </summary>
        private void Update()
        {
            //brake when needed
            Brake();
        }

        private void FixedUpdate()
        {
            //for car movement
            CarMovement();
        }

        /// <summary>
        /// Movement of Player
        /// </summary>
        public void CarMovement()
        {
            if (car._name == "Megamo")
            {
                motor = maxMotorTorque * Input.GetAxis("Vertical");
            }
            else if (car._name == "Chrollo")
            {
                motor = maxMotorTorque * Input.GetAxis("Vertical");
            }
           
            float steering = maxSteeringAngle * Input.GetAxis("Horizontal");

            //if user holds space brake is equal to brake torque else brake is equal to 0
            float brake = Input.GetKey(KeyCode.Space) ? brakeTorque : 0;

            foreach (AxleData axleData in axles)
            {
                //if the axle can steer
                if (axleData.steering == true)
                {
                    axleData.leftWheel.steerAngle = steering;
                    axleData.rightWheel.steerAngle = steering;
                }
                //if the axle can generate force to push the car forward
                if (axleData.motor == true)
                {
                    axleData.leftWheel.motorTorque = motor;
                    axleData.rightWheel.motorTorque = motor;

                    //brake torque
                    //if space is pressed quickly stop the car
                    if (Input.GetKey(KeyCode.Space))
                    {
                        axleData.leftWheel.motorTorque = 0;
                        axleData.rightWheel.motorTorque = 0;

                        axleData.leftWheel.brakeTorque = brake;
                        axleData.rightWheel.brakeTorque = brake;
                    }
                    else
                    {
                        axleData.leftWheel.motorTorque = motor;

                        axleData.rightWheel.motorTorque = motor;

                        axleData.leftWheel.brakeTorque = 0;
                        axleData.rightWheel.brakeTorque = 0;
                    }
                }
            }
        }


        /// <summary>
        /// Edit the car attributes
        /// </summary>
        /// <param name="car_id"></param>
        /// <param name="car"></param>
        private void GetSelectedCar(int car_id, Car car)
        {
            switch (car_id)
            {
                case 0:
                    {
                        //this is megamo
                        //car id = 0
                        car._id = 0;
                        car._name = "Megamo";
                    }
                    break;
                case 1:
                    {
                        //this is Maora
                        //car id = 1
                        car._id = 1;
                        car._name = "Maora";
                    }
                    break;
                case 2:
                    {
                        //this is Chrollo
                        //car id = 2
                        car._id = 2;
                        car._name = "Chrollo";
                    }
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Brake
        /// </summary>
        public void Brake()
        {
            //if s or space is pressed and held
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.DownArrow))
            {
                if (car._name == "Megamo")
                {
                    
                    brakeObject.GetComponent<MeshRenderer>().materials = new Material[7] { carMaterials[0], carMaterials[1], carMaterials[2], carMaterials[3], carMaterials[4], carMaterials[5], brakeLight_On };

                    carLight.TurnOnLights(carLight.rearLights);
                }
                else if (car._name == "Chrollo")
                {
                    brakeObject.GetComponent<MeshRenderer>().materials = new Material[7] { carMaterials[0], carMaterials[1], brakeLight_On, carMaterials[3], carMaterials[4], carMaterials[5], carMaterials[6] };

                    carLight.TurnOnLights(carLight.rearLights);
                }
            }
            else
            {
                if (car._name == "Megamo")
                {
                    brakeObject.GetComponent<MeshRenderer>().materials = new Material[7] { carMaterials[0], carMaterials[1], carMaterials[2], carMaterials[3], carMaterials[4], carMaterials[5], brakeLight_Off };

                    carLight.TurnOffLights(carLight.rearLights);
                }

                else if (car._name == "Chrollo")
                {
                    brakeObject.GetComponent<MeshRenderer>().materials = new Material[7] { carMaterials[0], carMaterials[1], brakeLight_Off, carMaterials[3], carMaterials[4], carMaterials[5], carMaterials[6] };

                    carLight.TurnOffLights(carLight.rearLights);
                }
            }
        }
    } 
}
