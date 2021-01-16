using UnityEngine;

/// <summary>
/// Contains the materials needed to have different coloured cars
/// </summary>

namespace Turbo
{
    //give different colours to the AI cars 
    public class CarColours : MonoBehaviour
    {
        /// <summary>
        /// The material to be applied to the car
        /// </summary>
        public Material[] material;

        /// <summary>
        /// Will Tell the AI whether or not the color can be used 
        /// </summary>
        public bool can_be_used;

        /// <summary>
        /// Random number chosen
        /// </summary>
        public int random_number;

        /// <summary>
        /// The Car AI
        /// </summary>
        public Car_AI carAI;

        /// <summary>
        /// Runs on the first frame
        /// </summary>
        private void Start()
        {
            //pick any random number from 0 to material.length
            random_number = Random.Range(0, material.Length);

            //edit the first material of the car mesh renderer
            //transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().material = material[random_number];
            carAI.brakeObject.GetComponent<MeshRenderer>().material = material[random_number];
        }
    }

}
