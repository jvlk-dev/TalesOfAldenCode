using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* Represents the game data that needs to be persisted across game sessions
*/
[System.Serializable]
public class GameData
{
    public float playerHealth;

    /**
    * Initializes a new instance of the GameData class with default player health value of 100.
    */
    public GameData()
    {
        this.playerHealth = 100f;
    }
}
