using UnityEngine;
            
namespace Turbo
{
    /// <summary>
    ///  Manage AI Systems
    /// </summary>
    public class AI_Manager : MonoBehaviour
    {
        /// <summary>
        /// The car information
        /// </summary>
        public Car car;

        /// <summary>
        /// What type of AI being used
        /// </summary>
        public enum AI_Type
        {
            /// <summary>
            /// No AI Type
            /// </summary>
            None = 0,

            /// <summary>
            /// AI Type is Megamo
            /// </summary>
            Megamo = 1,

            /// <summary>
            /// AI Type is Chrollo
            /// </summary>
            Chrollo = 2,


        }

        /// <summary>
        /// What type of AI is being used
        /// </summary>
        public AI_Type aiType;

        [Header("AI Settings")]
        /// <summary>
        /// is this car perfect when driving
        /// </summary>
        [SerializeField]
        public bool perfectDriving;

        /// <summary>
        /// The operation that will be performed on the relative vector 
        /// </summary>
        [HideInInspector]
        public string operation;


        /// <summary>
        /// runs during script initialization
        /// </summary>
        private void Start()
        {
            //check the ai type
            switch (aiType)
            {
                //if no ai type has been selected
                case AI_Type.None:
                    {
                        //warn the developer
                        Debug.LogWarning("No AI Type has been selected, please assign an AI Type");
                    }
                    break;
                //if the ai type is megamo
                case AI_Type.Megamo:
                    {
                        // generate the car data
                        car = new Car("Megamo", 0, GameManager.instance.Cars[0]);
                    }
                    break;
                //if the ai type is chrollo
                case AI_Type.Chrollo:
                    {
                        // generate the car data
                        car = new Car("Chrollo", 2, GameManager.instance.Cars[3]);
                    }
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Setup the AI Data
        /// </summary>
        public void Setup(out float x, out float z)
        {
            //if perfect driver is off

            //2 random numbers 
            //x
            x = Random.Range(0f, 5f);
            //z
            z = Random.Range(0f, 5f);

            //turn left if the number is 0 , turn right if the number is 1
            float varied_steering = Random.Range(0, 1);

            switch (varied_steering)
            {
                case 0:
                    {
                        //turn left
                        operation = "+";
                    }
                    break;
                case 1:
                    {
                        //turn right
                        operation = "-";
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
