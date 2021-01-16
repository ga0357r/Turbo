using UnityEngine;
using Photon.Pun;

namespace Turbo
{
    public class NetworkCameraControl : MonoBehaviour, IPunObservable
    {
        /// <summary>
        /// Which player is currently connected
        /// </summary>
        //[SerializeField]
        public int playerNumber;

        /// <summary>
        /// Store the camera
        /// </summary>
        public new Camera camera;

        /// <summary>
        /// The photon view of the gameobject
        /// </summary>
        public PhotonView photonView;

        /// <summary>
        /// The audiolistener attached to this gameobject
        /// </summary>
        public AudioListener audioListener;

        /// <summary>
        /// The parent of this gameobject
        /// </summary>
        public GameObject parent;

        private void Awake()
        {
            Debug.Log("Target Display is " + camera.targetDisplay);

            if (PhotonNetwork.IsMasterClient)
            {
                if (photonView.IsMine)
                {
                    Debug.Log("This is the Master Client");

                    //set the camera
                    playerNumber = 0;

                    //set the target display
                    camera.targetDisplay = playerNumber;

                    //set the tag to Player 1
                    parent.tag = "Player 1";
                }


            }
            else
            {
                if (photonView.IsMine)
                {
                    Debug.Log("This is not the Master Client");

                    playerNumber = 1;

                    camera.targetDisplay = playerNumber;

                    //set the tag to Player 2
                    parent.tag = "Player 2";
                }

            }
        }

        private void Start()
        {
            if (playerNumber == 0)
            {
                //set the tag to Player 1
                parent.tag = "Player 1";

                //set the display for player 1
                camera.targetDisplay = playerNumber;

                audioListener.enabled = true;
            }

            else if (playerNumber == 1)
            {
                //set the tag to Player 2
               parent.tag = "Player 2";

                //set the display for player 2
                camera.targetDisplay = playerNumber;

                audioListener.enabled = false;

                for (int i = 0; i < Display.displays.Length; i++)
                {
                    Display.displays[i].Activate(1920, 1080, 60);
                }
            }

        }

        public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {
            if (stream.IsWriting)
            {
                stream.SendNext(playerNumber);

                //the player tag
                stream.SendNext("Player 2");

                //the camera target display 
                stream.SendNext(1);
            }

            else if (stream.IsReading)
            {
                playerNumber = (int)stream.ReceiveNext();

                //the player tag
                parent.tag = (string)stream.ReceiveNext();

                // the camera target display
                camera.targetDisplay = (int)stream.ReceiveNext();
            }
        }
    }
}
