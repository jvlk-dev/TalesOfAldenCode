using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* Interface for data persistence operations
*/
public interface IDataPersistence
{
    /**
    * Loads game data from the provided GameData object
    * @param The GameData object to load data from
    */
    void LoadData(GameData data);
    /**
    * Saves game data to the provided GameData object
    * @param The GameData object to save data to (passed by reference)
    */
    void SaveData(ref GameData data);
}
