using UnityEngine;

/// <summary>
/// Car class which the player car and opponent car will inherit from
/// </summary>
namespace Turbo
{
    /// <summary>
    /// Base Class Car 
    /// </summary>
    [System.Serializable]
    public class Car
    {
        /// <summary>
        /// The name of the car
        /// </summary>
        public string _name;

        /// <summary>
        /// The id of the car
        /// </summary>
        public int _id;

        /// <summary>
        /// The look of the car physically
        /// </summary>
        public GameObject _ref;

        //default constructor
        public Car()
        {
            _name = null;
            _id = 0;
            _ref = null;
        }
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="car_name"></param>
        /// <param name="car_id"></param>
        /// <param name="reference_gameobject"></param>
        public Car(string car_name, int car_id, GameObject reference_gameobject)
        {
            _name = car_name;
            _id = car_id;
            _ref = reference_gameobject;
        }

    }
}
