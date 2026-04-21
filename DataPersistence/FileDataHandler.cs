using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

/**
* Class for handling game data in files
*/
public class FileDataHandler
{
    private string dataDirPath = "";
    private string dataFileName = "";

    /**
    * Constructor for initializing a FileDataHandler instance
    * @param dataDirPath The directory path where data files are stored
    * @param dataFileName The name of the data file
    */
    public FileDataHandler(string dataDirPath, string dataFileName)
    {
        this.dataDirPath = dataDirPath;
        this.dataFileName = dataFileName;
    }

    /**
    * Method for loading game data from a file
    * @return The loaded game data as a GameData object, or null if the file does not exist or an error occurs
    */
    public GameData Load()
    {
        string fullPath = Path.Combine(dataDirPath, dataFileName);
        GameData loadedData = null;
        if (File.Exists(fullPath))
        {
            try
            {
                string dataToLoad = "";
                using (FileStream stream = new FileStream(fullPath, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        dataToLoad = reader.ReadToEnd();
                    }
                }
                loadedData = JsonUtility.FromJson<GameData>(dataToLoad);
            }
            catch (Exception e)
            {
                Debug.LogError("Error occured while trying to laod data from file " + fullPath + "n" + e);
            }
        }
        return loadedData;
    }

    /**
    * Method for saving game data to a file
    * @param data The game data to be saved as a GameData object
    */
    public void Save(GameData data)
    {
        string fullPath = Path.Combine(dataDirPath, dataFileName);
        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

            string dataToStore = JsonUtility.ToJson(data, true);

            using (FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(dataToStore);
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Error occured while traying to save data to file: " + fullPath + "n" + e);
        }
    }
}
