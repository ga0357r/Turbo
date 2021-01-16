using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System.IO;

namespace Turbo
{
    //SaveData class is static in order not to create multiple versions of this class
    public static class SaveData
    {
        /// <summary>
        /// Save Player car choice
        /// </summary>
        public static void SavePlayerCarChoice()
        {
            BinaryFormatter formatter = new BinaryFormatter();

            //path to store the data, creating a custom file extension ".Save"
            string path = Application.persistentDataPath + "/Player.Car";

            //print it out
            //need a filestream, so data can be read to file, create the file
            FileStream stream = new FileStream(path, FileMode.Create);

            //get the data to be serialized

        }
    }
}