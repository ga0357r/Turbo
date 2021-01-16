using UnityEngine;
using Photon.Pun;

namespace Turbo
{
    public class RoomController : MonoBehaviourPunCallbacks
    {
        /// <summary>
        /// The scene index of the multiplayer racing scene
        /// </summary>
        public int multiplayerSceneIndex;

        public override void OnEnable()
        {
            PhotonNetwork.AddCallbackTarget(this);
        }

        public override void OnDisable()
        {
            PhotonNetwork.RemoveCallbackTarget(this);
        }

        public override void OnJoinedRoom()
        {
            Debug.Log("Joined Room");

            StartGame();
        }

        /// <summary>
        /// Start game
        /// </summary>
        private void StartGame()
        {
            if (PhotonNetwork.IsMasterClient)
            {
                Debug.Log("Starting Game...");

                PhotonNetwork.LoadLevel(multiplayerSceneIndex);
            }
        }
    }
}