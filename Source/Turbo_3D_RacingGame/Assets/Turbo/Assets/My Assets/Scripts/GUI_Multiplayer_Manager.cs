using UnityEngine;
using UnityEngine.SceneManagement;

namespace Turbo
{
    public class GUI_Multiplayer_Manager : MonoBehaviour
    {

        /// <summary>
        /// object of class extension
        /// </summary>
        private Extension e;

        /// <summary>
        /// animator component of the garage door
        /// </summary>
        private Animator garage_door;

        /// <summary>
        /// store the gui_camera
        /// </summary>
        
        //store the gameobjects_housing the UI menu elements
        private GameObject gui_camera;
        private GameObject Main_Menu;
        private GameObject Left_Arrow_Button;
        private GameObject Right_Arrow_Button;
        private GameObject Back_Button_1;
        private GameObject Race_Button;
        private GameObject Cancel_Button;

        /// <summary>
        /// gameobject array
        /// </summary>
        private GameObject[] gameObjects;

        /// <summary>
        /// network manager
        /// </summary>
        [SerializeField]
        private NetworkManager networkManager;

        /// <summary>
        /// Lobby Controller
        /// </summary>
        [SerializeField]
        private LobbyController lobbyController;

        /// <summary>
        /// private float f to handle color manipulation
        /// </summary>
        private float f;

        /// <summary>
        /// runs during script initialization first frame
        /// </summary>
        private void Awake()
        {
            ManageMainMenuSceneInAwake();
        }

        /// <summary>
        /// runs in first frame
        /// </summary>
        private void Start()
        {
            ManageMultiplayerMenuSceneInStart();
        }

        /// <summary>
        /// Runs every frame
        /// </summary>
        private void Update()
        {
            ManageMainMenuSceneInUpdate();
        }

        /// <summary>
        /// Manage the main menu scene before script intitialisation
        /// </summary>
        public void ManageMainMenuSceneInAwake()
        {

            //asign variables
            //object e
            e = new Extension();


            //find the garage door's animator component
            garage_door = GameObject.FindGameObjectWithTag("Garage_Door").GetComponent<Animator>();

            //find the GUICam
            gui_camera = GameObject.FindGameObjectWithTag("GUI_Camera");

            //find the mainmenu gameobject
            Main_Menu = GameObject.FindGameObjectWithTag("Main_Menu");

        }

        /// <summary>
        /// Manage the main menu scene in the first frame
        /// </summary>
        public void ManageMultiplayerMenuSceneInStart()
        {
            Left_Arrow_Button = Main_Menu.transform.Find("Canvas").Find("Left_Arrow_Button").gameObject;
            Right_Arrow_Button = Main_Menu.transform.Find("Canvas").Find("Right_Arrow_Button").gameObject;
            Back_Button_1 = Main_Menu.transform.Find("Canvas").Find("Back_Button_1").gameObject;
            Race_Button = Main_Menu.transform.Find("Canvas").Find("Race_Button").gameObject;
            Cancel_Button = Main_Menu.transform.Find("Canvas").Find("Cancel_Button").gameObject;

            //assign this variable after its indexes have been found
            gameObjects = new GameObject[5] { Left_Arrow_Button, Right_Arrow_Button, Back_Button_1, Race_Button, Cancel_Button };

            //deactivate the new game,loadgame and back buttons and text
            Extension.DisableGameobjects(gameObjects);

        }

        /// <summary>
        /// Manage the main menu scene every frame
        /// </summary>
        public void ManageMainMenuSceneInUpdate()
        {
            //if both garage door and guicamera is null from leaving the main menu scene and the coming back to the main menu scene
            if (garage_door && gui_camera == null)
            {
                //find the garage_door
                garage_door = GameObject.FindGameObjectWithTag("Garage_Door").GetComponent<Animator>();

                //find the guicamera
                gui_camera = gui_camera = GameObject.FindGameObjectWithTag("GUI_Camera");

            }

            //if any of the variables are empty reassign each of them, even if they are 
            if (garage_door || gui_camera || Main_Menu || Left_Arrow_Button || Right_Arrow_Button || Back_Button_1 || Race_Button == null)
            {

            }

            //play the camera GUI animation after Turbo has successfully loaded into the main menu scene

            //if the current animator state of the GUI Cam is idle
            if (gui_camera.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            {
                //if the scene has loaded
                if (LoadingScreen.loading_screen.scene_has_loaded == true)
                {
                    //play the zoom and focus animation
                    gui_camera.GetComponent<Animator>().SetBool("HasLoaded", true);
                }



            }
            //if the current animator state of the GUI Cam is GUI_Cam_Focus
            if (gui_camera.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("GUI_Cam_Focus"))
            {
                //if GUI_Cam_Focus has completely played the animation
                if (gui_camera.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
                {
                    //slowly animate the GUI Text to display 
                    if (f < 0.06)
                    {
                        //open the garage door
                        garage_door.SetBool("Has_Clicked_Play", true);

                        //set the Has_Clicked_Back  parameter to false
                        garage_door.SetBool("Has_Clicked_Back", false);

                        //assign the global variables
                        //will be activating this variable
                        gameObjects = new GameObject[5] { Left_Arrow_Button, Right_Arrow_Button, Back_Button_1, Race_Button, Cancel_Button };

                        //activate the Play_Button,Credits_Button and Exit_Button and their texts 
                        Extension.EnableGameobjects(gameObjects);
                    }

                }
            }

        }

        /// <summary>
        /// Go back to mainmenu when back is pressed
        /// </summary>
        public void GoBackToMainMenu()
        {
            SceneManager.LoadSceneAsync("Main_Menu");
        }

        /// <summary>
        /// start the multiplayer game when race button is pressed
        /// </summary>
        public void HostAndRace()
        {
            //connect to the master server
            networkManager.Connect();

            //Join a game
            lobbyController.JoinGame();
        }
    }
}
