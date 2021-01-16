using UnityEngine;

namespace Turbo
{
    //will select the car 
    public class CarSelector : MonoBehaviour
    {
        /// <summary>
        /// car id
        /// </summary>
        public static int car_id = 0;

        /// <summary>
        /// reference to the cars gameobject
        /// </summary>
        public GameObject[] g_cars = new GameObject[3];

        //List of Cars available 
        public enum Cars
        {
            /// <summary>
            /// Megamo car
            /// </summary>
            Megamo = 0,

            /// <summary>
            /// Maora car
            /// </summary>
            Maora = 1,

            /// <summary>
            /// Chrollo Car
            /// </summary>
            Chrollo = 2
        }

        //making it static, not an object 
        public static Cars selected_car = Cars.Megamo;

        //method runs when the user clicks the left and right arrows
        private void OnMouseDown()
        {

            //when the left arrow key is hit
            if (gameObject.name == "Left_Arrow_Button")
            {
                //turn the cars off and on

                //if the button can still move left and is not equal to megamo
                if (selected_car != Cars.Megamo)
                {
                    //disable the current car selection 
                    g_cars[(int)selected_car].SetActive(false);


                    //decrement selected car to be the previous car in the series
                    selected_car = selected_car - 1;


                    //enable the previous car selection
                    g_cars[(int)selected_car].SetActive(true);

                    //get me the id of the car chosen
                    car_id = (int)selected_car;
                }
            }

            else if (gameObject.name == "Right_Arrow_Button")
            {

                //if the button can still move right and is not equal to Chrollo
                if (selected_car != Cars.Chrollo)
                {
                    //disable the current car selection 
                    g_cars[(int)selected_car].SetActive(false);


                    //increment selected car to be the next car in the series
                    selected_car = selected_car + 1;


                    //enable the next car selection
                    g_cars[(int)selected_car].SetActive(true);

                    //get me the id of the car chosen
                    car_id = (int)selected_car;

                }
            }

        }
    }
}
