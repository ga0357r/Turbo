using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

namespace Turbo
{
    public class LobbyController : MonoBehaviourPunCallbacks
    {
        /// <summary>
        /// The Race button
        /// </summary>
        public GameObject raceButton;

        /// <summary>
        /// The Cancel button
        /// </summary>
        public GameObject cancelButton;

        /// <summary>
        /// Max number of Players allowed in a room
        /// </summary>
        public int roomSize;


        /// <summary>
        /// Called when the client is connected to the Master Server and ready for matchmaking
        /// </summary>
        public override void OnConnectedToMaster()
        {
            //sync the scene in the master and all clients 
            PhotonNetwork.AutomaticallySyncScene = true;
        }

        /// <summary>
        /// Join a Random Room
        /// </summary>
        public void JoinGame()
        {
            Debug.Log("Joining Room");

            raceButton.SetActive(false);
            cancelButton.SetActive(true);

            //try to join an existing room
            PhotonNetwork.JoinRandomRoom();
        }

        /// <summary>
        /// Run this method if JoinGame() failed
        /// </summary>
        /// <param name="returnCode"></param>
        /// <param name="message"></param>
        public override void OnJoinRandomFailed(short returnCode, string message)
        {
            Debug.Log("Failed to join room");

            //create a room
            CreateRoom();
        }

        /// <summary>
        /// Create a Room
        /// </summary>
        private void CreateRoom()
        {
            Debug.Log("Creating Room");

            //pick a random number between a specified range
            int random_room_number = Random.Range(0, 10000);

            //setup the roomoptions
            RoomOptions room_options = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = (byte)roomSize };

            //try creating a room
            PhotonNetwork.CreateRoom("Turbo" + random_room_number, room_options);

            Debug.Log(random_room_number);
        }

        /// <summary>
        /// Run this method if PhotonNetwork.CreateRoom() failed
        /// </summary>
        /// <param name="returnCode"></param>
        /// <param name="message"></param>
        public override void OnCreateRoomFailed(short returnCode, string message)
        {
            Debug.Log("Failed to create room.... trying again");
            CreateRoom();
        }

        /// <summary>
        /// Cancel
        /// </summary>
        public void Cancel()
        {
            cancelButton.SetActive(false);
            raceButton.SetActive(true);

            PhotonNetwork.LeaveRoom();
        }
    }
}
