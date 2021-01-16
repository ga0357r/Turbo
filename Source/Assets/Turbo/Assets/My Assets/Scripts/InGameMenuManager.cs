using UnityEngine;

namespace Turbo
{
    public class InGameMenuManager : MonoBehaviour
    {
        /// <summary>
        /// Canvas gameobject
        /// </summary>
        public GameObject inGameMenuCanvas;

        /// <summary>
        /// Runs during script initialization
        /// </summary>
        private void Awake()
        {

        }

        /// <summary>
        /// runs on the first frame
        /// </summary>
        private void Start()
        {

        }

        /// <summary>
        /// runs every frame
        /// </summary>
        private void Update()
        {

        }

        /// <summary>
        /// Turn off the menu
        /// </summary>
        /// <param name="menu_object"></param>
        private void TurnOffInGameMenu(GameObject menu_object)
        {
            menu_object.SetActive(false);
        }
    }
}
