using UnityEngine;

namespace Turbo
{
    public class GameManager : MonoBehaviour
    {

        /// <summary>
        /// Instance of this class
        /// </summary>
        public static GameManager instance;

        /// <summary>
        /// Contains car prefabs
        /// </summary>
        public GameObject[] Cars = new GameObject[3];

        /// <summary>
        /// Runs during script initialization
        /// </summary>
        private void Awake()
        {
            instance = this;
        }

       
    }
}