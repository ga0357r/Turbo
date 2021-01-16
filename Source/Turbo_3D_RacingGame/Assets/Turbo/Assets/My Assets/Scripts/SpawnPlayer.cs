using UnityEngine;
using UnityEngine.SceneManagement;


namespace Turbo
{
    public class SpawnPlayer : MonoBehaviour
    {
        //variables
        /// <summary>
        /// Spawn Location
        /// </summary>
        [SerializeField]
        private GameObject SpawnLocation;

        /// <summary>
        /// Instance of Car class
        /// </summary>
        //[]
        public static Car carData = new Car();

        /// <summary>
        /// The Player Gameobject
        /// </summary>
        public GameObject playerParent;


        /// <summary>
        /// Called first frame
        /// </summary>
        private void Awake()
        {
            InstantiatePlayerCar();
        }

        /// <summary>
        /// Instantiate Player Car
        /// </summary>
        private void InstantiatePlayerCar()
        {
            //instantiate the player car 
            carData._ref = ReturnSelectedCar(CarSelector.car_id, carData);

            //if this is currently the Level_1 scene
            if (SceneManager.GetActiveScene() == Scenes_Dictionary.instance.level_1)
            {
                // make changes to the tranform component of the car to be instantiated

                //switch through the id of the car
                switch (carData._id)
                {
                    case 0:
                        {
                            //if the car name is Megamo

                            //modify the transform component

                            //the position component
                            carData._ref.transform.position = new Vector3(0f, 2.4f, -0.34f);

                            //the rotation component
                            carData._ref.transform.rotation = Quaternion.Euler(new Vector3(0f, 90f, 0f));
                        }
                        break;
                    case 1:
                        {
                            //if the car name is Maora

                            //modify the transform component

                            //the position component
                            carData._ref.transform.position = new Vector3(0.13f, 0f, -0.3f);

                            //the rotation component
                            carData._ref.transform.rotation = Quaternion.Euler(new Vector3(0f, 90f, 0f));
                        }
                        break;
                    case 2:
                        {
                            //if the car name is Chrollo

                            //modify the transform component

                            //the position component
                            carData._ref.transform.position = new Vector3(-0.04f, 1.75f, -0.4f);

                            //the rotation component
                            carData._ref.transform.rotation = Quaternion.Euler(new Vector3(1f, 90f, 0f));
                        }
                        break;
                    default:
                        break;
                }



            }

            //instantiate the player car 
            Instantiate(carData._ref,new Vector3(27.57f, 3.28f, -141.05f), carData._ref.transform.rotation);
            
        }

        /// <summary>
        /// Return Selected car and Instantiate it in the scene
        /// </summary>
        /// <param name="car_id"></param>
        /// <param name="car"></param>
        /// <returns></returns>
        private GameObject ReturnSelectedCar(int car_id, Car car)
        {
            switch (car_id)
            {
                case 0:
                    {
                        //this is megamo
                        //car id = 0
                        car._id = 0;
                        car._name = "Megamo";

                        //return the car
                        return GameManager.instance.Cars[0];
                    }
                case 1:
                    {
                        //this is Maora
                        //car id = 1
                        car._id = 1;
                        car._name = "Maora";

                        //return the car
                        return GameManager.instance.Cars[1];
                    }

                case 2:
                    {
                        //this is Chrollo
                        //car id = 2
                        car._id = 2;
                        car._name = "Chrollo";

                        //return the car
                        return GameManager.instance.Cars[2];
                    }

                default:
                    {
                        //exception
                        //return null
                        return null;
                    }

            }
        }

    }
}
