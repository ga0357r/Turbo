using UnityEngine.SceneManagement;
using UnityEngine;

namespace Turbo
{
    public class Scenes_Dictionary : MonoBehaviour
    {
        //to get the recent instance 
        public static Scenes_Dictionary instance;


        //assign this scene in the inspector
        public Scene main_menu;
        public Scene credits;
        public Scene level_1;

        private void Awake()
        {
            //instance is set to the most current instance of this class
            instance = this;

            //if active scene is main menu
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Main_Menu"))
            {
                //if the main menu variable is not assigned right
                if (main_menu == null || main_menu != SceneManager.GetSceneByName("Main_Menu"))
                {
                    //assign it correctly 
                    main_menu = SceneManager.GetSceneByName("Main_Menu");

                }

            }
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Credits"))
            {
                //if the main menu variable is not assigned right
                if (credits == null || credits != SceneManager.GetSceneByName("Credits"))
                {
                    //assign it correctly 
                    credits = SceneManager.GetSceneByName("Credits");

                }

            }

            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level_1"))
            {
                //if the level_1 variable is not assigned right
                if (level_1 == null || level_1 != SceneManager.GetSceneByName("Level_1"))
                {
                    //assign it correctly 
                    level_1 = SceneManager.GetSceneByName("Level_1");

                }

            }

        }

        public void Update()
        {
            //if active scene is main menu
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Main_Menu"))
            {
                //if the main  menu variable is not assigned right
                if (main_menu == null || main_menu != SceneManager.GetSceneByName("Main_Menu"))
                {
                    //assign it correctly 
                    main_menu = SceneManager.GetSceneByName("Main_Menu");

                }

}
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Credits"))
            {
                //if the credits variable is not assigned right
                if (credits == null || credits != SceneManager.GetSceneByName("Credits"))
                {
                    //assign it correctly 
                    credits = SceneManager.GetSceneByName("Credits");

                }

            }
            
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level_1"))
            {
                //if the level_1 variable is not assigned right
                if (level_1 == null || level_1 != SceneManager.GetSceneByName("Level_1"))
                {
                    //assign it correctly 
                    level_1 = SceneManager.GetSceneByName("Level_1");

                }

            }
        }

    }
}
