using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

namespace Turbo
{
    /// <summary>
    /// GUI Manager of the menu system
    /// </summary>
    public class GUI_Manager : MonoBehaviour
    {
        /// <summary>
        /// object of class extension
        /// </summary>
        private Extension e;

        /// <summary>
        /// animator component of the garage door
        /// </summary>
        [SerializeField]
        private Animator garage_door;

        /// <summary>
        /// store the gui_camera
        /// </summary>
        [SerializeField]
        private GameObject gui_camera;

        //store the gameobjects_housing the UI menu elements
        [SerializeField]
        private GameObject Main_Menu;
        [SerializeField]
        private GameObject NewGame_Button;
        [SerializeField]
        private GameObject LoadGame_Button;
        [SerializeField]
        private GameObject Multiplayer_Button;
        [SerializeField]
        private GameObject Back_Button;
        [SerializeField]
        private GameObject Play_Button;
        [SerializeField]
        private GameObject Credits_Button;
        [SerializeField]
        private GameObject Exit_Button;
        [SerializeField]
        private GameObject Left_Arrow_Button;
        [SerializeField]
        private GameObject Right_Arrow_Button;
        [SerializeField]
        private GameObject Back_Button_1;
        [SerializeField]
        private GameObject Race_Button;

        /// <summary>
        /// gameobject array
        /// </summary>
        [SerializeField]
        private GameObject[] gameObjects;

        //store float values for and of colors
        //for buttons
        private float r_button;
        private float g_button;
        private float b_button;
        //for texts
        private float r_text;
        private float g_text;
        private float b_text;


        /// <summary>
        /// private float f to handle color manipulation
        /// </summary>
        private float f;

        //store the speed and seconds which will be manipulated in the inspector
        public int animation_speed;
        public float seconds;

        /// <summary>
        /// runs in first frame
        /// </summary>
        private void Start()
        {
            //manage the Mainmenu GUI in Awake, before the game even begins
            ManageMainMenuSceneInAwake();

            //manage the Mainmenu GUI in Start, on the first frame
            ManageMainMenuSceneInStart();
        }

        /// <summary>
        /// Runs every frame
        /// </summary>
        private void Update()
        {
            // manage the Mainmenu GUI in Update, every frame frame
            ManageMainMenuSceneInUpdate();
        }

        /// <summary>
        /// run this method if the play button is pressed
        /// </summary>
        public void Play_Button_Pressed_Animation()
        {
            //variables
            //will be deactivating this variables
            GameObject[] go = new GameObject[3] { Play_Button, Credits_Button, Exit_Button };

            //assign the global variables
            //will be activating this variables
            gameObjects = new GameObject[4] { NewGame_Button, LoadGame_Button, Multiplayer_Button,  Back_Button };

            //set the culling mode back to always animate if it is something else
            if (Main_Menu.GetComponent<Animator>().cullingMode != AnimatorCullingMode.AlwaysAnimate)
            {
                Main_Menu.GetComponent<Animator>().cullingMode = AnimatorCullingMode.AlwaysAnimate;
            }

            //activate the new game,loadgame and back buttons and text
            Extension.EnableGameobjects(gameObjects);

            Extension.DisableGameobjects(go);
        }

        /// <summary>
        /// run this method if the credits button is pressed
        /// </summary>
        public void Credits_Button_Pressed_Animation()
        {
            //go to a new scene and display the credits
            SceneManager.LoadSceneAsync("Credits");
        }

        /// <summary>
        /// if the Exit button is pressed, run this method
        /// </summary>
        public void Exit_Button_Pressed_Animation()
        {
            //quit the application
            Application.Quit();
        }

        /// <summary>
        /// run this method if the new game button is pressed
        /// </summary>
        public void New_Game_Button_Pressed_Animation()
        {
            //variables
            //will be deactivating this variable
            GameObject[] go = new GameObject[4] { NewGame_Button, LoadGame_Button, Multiplayer_Button, Back_Button };

            //assign the global variables
            //will be activating this variable
            gameObjects = new GameObject[4] { Left_Arrow_Button, Right_Arrow_Button, Back_Button_1, Race_Button };

            //activate the Play_Button,Credits_Button and Exit_Button and their texts 
            Extension.EnableGameobjects(gameObjects);

            //disable  NewGame_Button LoadGame_Button Back_Button
            Extension.DisableGameobjects(go);

            //open the garage door
            garage_door.SetBool("Has_Clicked_Play", true);

            //set the Has_Clicked_Back  parameter to false
            garage_door.SetBool("Has_Clicked_Back", false);

        }


        /// <summary>
        /// run this method if the load game button is pressed
        /// </summary>
        public void Load_Game_Button_Pressed_Animation()
        {
            //variables
            //will be deactivating this variable
            GameObject[] go = new GameObject[4] { NewGame_Button, LoadGame_Button, Multiplayer_Button, Back_Button };

            //assign the global variables
            //will be activating this variable
            gameObjects = new GameObject[4] { Left_Arrow_Button, Right_Arrow_Button, Back_Button_1, Race_Button };

            //activate the Play_Button,Credits_Button and Exit_Button and their texts 
            Extension.EnableGameobjects(gameObjects);

            //disable  NewGame_Button LoadGame_Button Back_Button
            Extension.DisableGameobjects(go);

            //open the garage door
            garage_door.SetBool("Has_Clicked_Play", true);

            //set the Has_Clicked_Back  parameter to false
            garage_door.SetBool("Has_Clicked_Back", false);

            //remember the player decided to load his saved game
            //load the game

        }


        /// <summary>
        /// run this method if the back button is pressed
        /// </summary>
        public void Back_Button_Pressed_Animation()
        {
            //variables
            //will be deactivating this variable
            GameObject[] go = new GameObject[4] { NewGame_Button, LoadGame_Button, Multiplayer_Button, Back_Button };

            //assign the global variables
            //will be activating this variable
            gameObjects = new GameObject[3] { Play_Button, Credits_Button , Exit_Button};

            //activate the Play_Button,Credits_Button and Exit_Button and their texts 
            Extension.EnableGameobjects(gameObjects);

            //disable  NewGame_Button LoadGame_Button Back_Button
            Extension.DisableGameobjects(go);
           
        }

        /// <summary>
        /// Open Multiplayer Scene
        /// </summary>
        public void Open_MultiplayerScene()
        {
            SceneManager.LoadSceneAsync("Multiplayer_Menu"); 
        }

        /// <summary>
        /// load the level 1
        /// </summary>
        public void Race_Button_Pressed()
        {
            SceneManager.LoadSceneAsync("Level_1");
        }

        /// <summary>
        /// Go back from the garage menu
        /// </summary>
        public void GoBack_From_CarGarageMenu()
        {
            //variables
            //will be deactivating this variable
            GameObject[] go = new GameObject[4] { Left_Arrow_Button, Right_Arrow_Button, Back_Button_1, Race_Button };

            //assign the global variables
            //will be activating this variable
            GameObject[] gameObjects = new GameObject[4] { NewGame_Button, LoadGame_Button, Multiplayer_Button, Back_Button };

            //close the garage
            garage_door.SetBool("Has_Clicked_Back", true);

            //set the Has_Clicked_Play parameter to false
            garage_door.SetBool("Has_Clicked_Play", false);

            //deactivate the Left_Arrow_Button, Right_Arrow_Button, Back_Button_1, Race_Button
            Extension.DisableGameobjects(go);

            //activate the NewGame_Button,LoadGame_Button and Back_Button and their texts 
            Extension.EnableGameobjects(gameObjects);


        }

        /// <summary>
        /// Run this method if the back button from the credits menu is pressed
        /// </summary>
        public void FromCreditsMenu_BackButton()
        {
            //load the main menu scene
            SceneManager.LoadSceneAsync("Main_Menu");
        }
        

        /// <summary>
        /// Manage the main menu scene before script intitialisation
        /// </summary>
        public void ManageMainMenuSceneInAwake()
        {

            //if this is currently the main menu scene
            if (SceneManager.GetActiveScene() == Scenes_Dictionary.instance.main_menu)
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


                //change the alpha values to 0 of all the button and text
                //all buttons
                r_button = Main_Menu.transform.Find("Canvas").Find("Play_Button").GetComponent<Image>().color.r;
                g_button = Main_Menu.transform.Find("Canvas").Find("Play_Button").GetComponent<Image>().color.g;
                b_button = Main_Menu.transform.Find("Canvas").Find("Play_Button").GetComponent<Image>().color.b;
                //all text
                r_text = Main_Menu.transform.Find("Canvas").Find("Play_Button").Find("Play_Text (TMP)").GetComponent<TextMeshProUGUI>().color.r;
                g_text = Main_Menu.transform.Find("Canvas").Find("Play_Button").Find("Play_Text (TMP)").GetComponent<TextMeshProUGUI>().color.g;
                b_text = Main_Menu.transform.Find("Canvas").Find("Play_Button").Find("Play_Text (TMP)").GetComponent<TextMeshProUGUI>().color.b;

                //set the play button transparent
                Main_Menu.transform.Find("Canvas").Find("Play_Button").GetComponent<Image>().color = new Color(r_button, g_button, b_button, 0f);
                //set the Play_Text (TMP) transparent
                Main_Menu.transform.Find("Canvas").Find("Play_Button").Find("Play_Text (TMP)").GetComponent<TextMeshProUGUI>().color = new Color(r_text, g_text, b_text, 0f);

                //set the credits button transparent
                Main_Menu.transform.Find("Canvas").Find("Credits_Button").GetComponent<Image>().color = new Color(r_button, g_button, b_button, 0f);
                //set the Play_Text (TMP) transparent
                Main_Menu.transform.Find("Canvas").Find("Credits_Button").Find("Credits_Text (TMP)").GetComponent<TextMeshProUGUI>().color = new Color(r_text, g_text, b_text, 0f);

                //set the exit button transparent
                Main_Menu.transform.Find("Canvas").Find("Exit_Button").GetComponent<Image>().color = new Color(r_button, g_button, b_button, 0f);
                //set the Play_Text (TMP) transparent
                Main_Menu.transform.Find("Canvas").Find("Exit_Button").Find("Exit_Text (TMP)").GetComponent<TextMeshProUGUI>().color = new Color(r_text, g_text, b_text, 0f);

                //set the play button transparent
                Main_Menu.transform.Find("Canvas").Find("Play_Button").GetComponent<Image>().color = new Color(r_button, g_button, b_button, 0f);
                //set the Play_Text (TMP) transparent
                Main_Menu.transform.Find("Canvas").Find("Play_Button").Find("Play_Text (TMP)").GetComponent<TextMeshProUGUI>().color = new Color(r_text, g_text, b_text, 0f);

                //set the credits button transparent
                Main_Menu.transform.Find("Canvas").Find("Credits_Button").GetComponent<Image>().color = new Color(r_button, g_button, b_button, 0f);
                //set the Play_Text (TMP) transparent
                Main_Menu.transform.Find("Canvas").Find("Credits_Button").Find("Credits_Text (TMP)").GetComponent<TextMeshProUGUI>().color = new Color(r_text, g_text, b_text, 0f);

                //set the exit button transparent
                Main_Menu.transform.Find("Canvas").Find("Exit_Button").GetComponent<Image>().color = new Color(r_button, g_button, b_button, 0f);
                //set the Play_Text (TMP) transparent
                Main_Menu.transform.Find("Canvas").Find("Exit_Button").Find("Exit_Text (TMP)").GetComponent<TextMeshProUGUI>().color = new Color(r_text, g_text, b_text, 0f);
            }

        }

        /// <summary>
        /// Manage the main menu scene in the first frame
        /// </summary>
        public void ManageMainMenuSceneInStart()
        {
            //assign variables


            //if this is currently the main menu scene
            if (SceneManager.GetActiveScene() == Scenes_Dictionary.instance.main_menu)
            {


                //play the camera GUI animation after Turbo has successfully loaded into the main menu scene

                //assign the variables
                Play_Button = Main_Menu.transform.Find("Canvas").Find("Play_Button").gameObject;
                Credits_Button = Main_Menu.transform.Find("Canvas").Find("Credits_Button").gameObject;
                Exit_Button = Main_Menu.transform.Find("Canvas").Find("Exit_Button").gameObject;
                NewGame_Button = Main_Menu.transform.Find("Canvas").Find("NewGame_Button").gameObject;
                LoadGame_Button = Main_Menu.transform.Find("Canvas").Find("LoadGame_Button").gameObject;
                Multiplayer_Button = Main_Menu.transform.Find("Canvas").Find("Multiplayer_Button").gameObject;
                Back_Button = Main_Menu.transform.Find("Canvas").Find("Back_Button").gameObject;
                Left_Arrow_Button = Main_Menu.transform.Find("Canvas").Find("Left_Arrow_Button").gameObject;
                Right_Arrow_Button = Main_Menu.transform.Find("Canvas").Find("Right_Arrow_Button").gameObject;
                Back_Button_1 = Main_Menu.transform.Find("Canvas").Find("Back_Button_1").gameObject;
                Race_Button = Main_Menu.transform.Find("Canvas").Find("Race_Button").gameObject;
                

                //assign this variable after its indexes have been found
                gameObjects = new GameObject[8] { NewGame_Button, LoadGame_Button, Multiplayer_Button, Back_Button, Left_Arrow_Button, Right_Arrow_Button, Back_Button_1, Race_Button };

                //deactivate the new game,loadgame and back buttons and text
                Extension.DisableGameobjects(gameObjects);

                //assign this variable after its indexes have been found
                gameObjects = new GameObject[8] { NewGame_Button, LoadGame_Button, Multiplayer_Button, Back_Button, Left_Arrow_Button, Right_Arrow_Button, Back_Button_1, Race_Button };

                //deactivate the new game,loadgame and back buttons and text
                Extension.DisableGameobjects(gameObjects);

            }
        }

        /// <summary>
        /// Manage the main menu scene every frame
        /// </summary>
        public void ManageMainMenuSceneInUpdate()
        {
            //if this is currently the main menu scene
            if (SceneManager.GetActiveScene() == Scenes_Dictionary.instance.main_menu)
            {
                //manipulate the GUI

                
                //if both garage door and guicamera is null from leaving the main menu scene and the coming back to the main menu scene
                if (garage_door && gui_camera == null)
                {
                    //find the garage_door
                    garage_door = GameObject.FindGameObjectWithTag("Garage_Door").GetComponent<Animator>();

                    //find the guicamera
                    gui_camera  = GameObject.FindGameObjectWithTag("GUI_Camera");

                }

                //if any of the variables are empty reassign each of them, even if they are 
                if (garage_door || gui_camera || Main_Menu || Play_Button || Credits_Button || Exit_Button || NewGame_Button || LoadGame_Button || Back_Button == null )
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
                            //set the play button visible
                            Main_Menu.transform.Find("Canvas").Find("Play_Button").GetComponent<Image>().color = new Color(r_button, g_button, b_button, (f += 0.0001f) * animation_speed);
                            //set the Play_Text (TMP) visible
                            Main_Menu.transform.Find("Canvas").Find("Play_Button").Find("Play_Text (TMP)").GetComponent<TextMeshProUGUI>().color = new Color(r_text, g_text, b_text, (f += 0.0001f) * animation_speed);

                            //set the credits button visible
                            Main_Menu.transform.Find("Canvas").Find("Credits_Button").GetComponent<Image>().color = new Color(r_button, g_button, b_button, (f += 0.0001f) * animation_speed);
                            //set the Play_Text (TMP) visible
                            Main_Menu.transform.Find("Canvas").Find("Credits_Button").Find("Credits_Text (TMP)").GetComponent<TextMeshProUGUI>().color = new Color(r_text, g_text, b_text, (f += 0.0001f) * animation_speed);

                            //set the exit button visible
                            Main_Menu.transform.Find("Canvas").Find("Exit_Button").GetComponent<Image>().color = new Color(r_button, g_button, b_button, (f += 0.0001f) * animation_speed);
                            //set the Play_Text (TMP) visible
                            Main_Menu.transform.Find("Canvas").Find("Exit_Button").Find("Exit_Text (TMP)").GetComponent<TextMeshProUGUI>().color = new Color(r_text, g_text, b_text, (f += 0.0001f) * animation_speed);
                        }

                    }
                }
            }

            //if this is currently the credits scene 
            if (SceneManager.GetActiveScene() == Scenes_Dictionary.instance.credits)
            {
                //if the back button is null
                if (Back_Button == null)
                {
                    //add a button event to the back_button_text only if the onclick event listener is empty

                    //find the back button
                    Back_Button = GameObject.Find("Back_Button");

                    //add a non persistent eventlistener to the back button object only if the back_button_variable is null

                    Back_Button.GetComponent<Button>().onClick.AddListener(FromCreditsMenu_BackButton);
                }

                

            }
        }

 

    }

    }


