using UnityEngine;

namespace Turbo
{


    public class LoadingScreen : MonoBehaviour
    {
        //variables
        //store the most recent instance of this class
        public static LoadingScreen loading_screen;

        //display this in the inspector for manipulation
        public int seconds;
        
        //has scene finished loading
        public bool scene_has_loaded = false;

        /// <summary>
        /// Runs during script initialization
        /// </summary>
        private void Awake()
        {
            //assign it to the most recent instance of this class
            loading_screen = this;
        }

        /// <summary>
        /// start the loading procedure
        /// </summary>
        public void StartLoadingTheScene()
        {
            //Load the terrain

            //load the garage

            //load the house


        }

        /// <summary>
        /// Runs first frame
        /// </summary>
        private void Start()
        {
            StartCoroutine(Turbo.Extension.WaitForSecondsBeforeCompletelyLoadingTheScene(seconds));
        }
    }
}