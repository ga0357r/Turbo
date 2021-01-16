using System.IO;
using UnityEngine;
using Photon.Pun;

public class GameSetup : MonoBehaviour
{
    // Start is called on the first frame update
    void Start()
    {
        CreatePlayer();
    }

    private void CreatePlayer()
    {
        //Instantiate the layer
        PhotonNetwork.Instantiate(Path.Combine("NetworkPlayerPrefab", "NetworkPlayer"), Vector3.zero, Quaternion.identity);
    }
}
