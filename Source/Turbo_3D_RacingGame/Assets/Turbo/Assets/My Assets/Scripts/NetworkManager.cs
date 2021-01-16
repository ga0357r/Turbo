using UnityEngine;
using Photon.Pun;

namespace Turbo
{
    public class NetworkManager : MonoBehaviourPunCallbacks
    {

        private void Start()
        {
            Connect();
        }

        /// <summary>
        /// Connect to photon as configured in the PhotonServerSettings File 
        /// </summary>
        public void Connect()
        {
            if (!PhotonNetwork.IsConnected)
            {
                PhotonNetwork.ConnectUsingSettings();
            }

        }

        /// <summary>
        /// Called when the client is connected to the Master Server and ready for matchmaking
        /// </summary>
        public override void OnConnectedToMaster()
        {
            Debug.Log("Connected to " + PhotonNetwork.CloudRegion + " server!");
        }
    }
}