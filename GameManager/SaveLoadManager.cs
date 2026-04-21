using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveLoadManager
{
    public static void SavePlayerHealth(PlayerHealthManager playerHealth)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string savePath = Application.persistentDataPath + "/playerHealth.sav";
        FileStream stream = new FileStream(savePath, FileMode.Create);

        PlayerHealthData data = new PlayerHealthData(playerHealth);

        formatter.Serialize(stream, data);
        stream.Close();

        Debug.Log("Player health saved at " + savePath);
    }

    public static void LoadPlayerHealth(PlayerHealthManager playerHealth)
    {
        string savePath = Application.persistentDataPath + "/playerHealth.sav";

        if (File.Exists(savePath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(savePath, FileMode.Open);

            PlayerHealthData data = (PlayerHealthData)formatter.Deserialize(stream);
            stream.Close();

            playerHealth.MaxHealth = data.maxHealth;
            playerHealth.CurrentHealth = data.currentHealth;
            playerHealth.Alive = data.isAlive;

            Debug.Log("Player health loaded from " + savePath);
        }
        else
        {
            Debug.LogWarning("No player health save file found at " + savePath);
        }
    }
}

[System.Serializable]
public class PlayerHealthData
{
    public float maxHealth;
    public float currentHealth;
    public bool isAlive;

    public PlayerHealthData(PlayerHealthManager playerHealth)
    {
        maxHealth = playerHealth.MaxHealth;
        currentHealth = playerHealth.CurrentHealth;
        isAlive = playerHealth.Alive;
    }
}