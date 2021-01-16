using System.IO;
using System.Collections;
using System.Collections.Generic;
using Turbo;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayerOverNetwork : MonoBehaviour, IPunObservable
{
    /// <summary>
    /// wait period
    /// </summary>
    public float waitPeriod = 3;

    //variables
    /// <summary>
    /// Locations available to spawn objects at
    /// </summary>
    public List<Location> locations = new List<Location>();

    /// <summary>
    /// Instance of Car class
    /// </summary>
    public static Car carData = new Car();

    /// <summary>
    /// has player been created
    /// </summary>
    public bool hasPlayerBeenCreated;

    /// <summary>
    /// The photonview attached to this object
    /// </summary>
    [SerializeField]
    private PhotonView photonView;

    



    /// <summary>
    /// Called first frame
    /// </summary>
    private void Start()
    {
        StartCoroutine(CreatePlayerAfterSeconds(waitPeriod));

      

        
    }

    /// <summary>
    /// Instantiate Player Car
    /// </summary>
    private IEnumerator CreatePlayerAfterSeconds(float seconds_to_wait)
    {

        //wait for some time
        yield return new WaitForSeconds(seconds_to_wait);

        carData._ref = ReturnSelectedCar(carData._id, carData);

            //switch through the id of the car
            switch (carData._id)
            {
                case 0:
                    {
                        //if the car name is Megamo

                        //modify the transform component

                        //the position component
                        carData._ref.transform.position = new Vector3(0f, 2.4f, -0.34f);

                        //the rotation component
                        carData._ref.transform.rotation = Quaternion.Euler(new Vector3(0f, 90f, 0f));

                    
                        for (int i = 0; i < locations.Capacity; i++)
                        {
                            if (!locations[i].isOccupied && !hasPlayerBeenCreated)
                            {
                                print("Creating Player");
                                PhotonNetwork.Instantiate(Path.Combine("NetworkPlayerPrefab", "NetworkPlayer"), locations[i].locationTransform.position, carData._ref.transform.rotation * Quaternion.identity);

                                locations[i].isOccupied = true;
                                hasPlayerBeenCreated = true;
                            }
                        
                        }


                    }
                    break;
                case 1:
                {
                    //if the car name is Maora

                    //modify the transform component

                    //the position component
                    carData._ref.transform.position = new Vector3(0.13f, 0f, -0.3f);

                    //the rotation component
                    carData._ref.transform.rotation = Quaternion.Euler(new Vector3(0f, 90f, 0f));

                    if (photonView.IsMine)
                    {
                        for (int i = 0; i < locations.Capacity; i++)
                        {
                            if (!locations[i].isOccupied && !hasPlayerBeenCreated)
                            {
                                print("Creating Player");
                                PhotonNetwork.Instantiate(Path.Combine("NetworkPlayerPrefab", "NetworkPlayer"), locations[i].locationTransform.position, Quaternion.identity);

                                locations[i].isOccupied = true;
                                hasPlayerBeenCreated = true;
                            }
                        }
                    }
                }
                    break;
                case 2:
                {
                    //if the car name is Chrollo

                    //modify the transform component

                    //the position component
                    carData._ref.transform.position = new Vector3(-0.04f, 1.75f, -0.4f);

                    //the rotation component
                    carData._ref.transform.rotation = Quaternion.Euler(new Vector3(1f, 90f, 0f));

                    if (photonView.IsMine)
                    {
                        for (int i = 0; i < locations.Capacity; i++)
                        {
                            if (!locations[i].isOccupied && !hasPlayerBeenCreated)
                            {
                                print("Creating Player");
                                PhotonNetwork.Instantiate(Path.Combine("NetworkPlayerPrefab", "NetworkPlayer"), locations[i].locationTransform.position, Quaternion.identity);

                                locations[i].isOccupied = true;
                                hasPlayerBeenCreated = true;
                            }
                        }
                    }
                }
                    break;
                default:
                    break;
            }


    }

    /// <summary>
    /// Return Selected car and Instantiate it in the scene
    /// </summary>
    /// <param name="car_id"></param>
    /// <param name="car"></param>
    /// <returns></returns>
    private GameObject ReturnSelectedCar(int car_id, Car car)
    {
        switch (car_id)
        {
            case 0:
                {
                    //this is megamo
                    //car id = 0
                    car._id = 0;
                    car._name = "Megamo";

                    //return the car
                    return GameManager.instance.Cars[0];
                }
            case 1:
                {
                    //this is Maora
                    //car id = 1
                    car._id = 1;
                    car._name = "Maora";

                    //return the car
                    return GameManager.instance.Cars[1];
                }

            case 2:
                {
                    //this is Chrollo
                    //car id = 2
                    car._id = 2;
                    car._name = "Chrollo";

                    //return the car
                    return GameManager.instance.Cars[2];
                }

            default:
                {
                    //exception
                    //return null
                    return null;
                }

        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {

        if (stream.IsWriting)
        {
            //Debug.Log("is writing");
            for (int i = 0; i < locations.Capacity; i++)
            {
                stream.SendNext(locations[i].isOccupied);
            }

        }

        else if (stream.IsReading)
        {
            //Debug.Log("is reading");
            for (int i = 0; i < locations.Capacity; i++)
            {
                locations[i].isOccupied = (bool)stream.ReceiveNext();
            }

        }
    }

}
 
