using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/**
* DataPersistenceManager is responsible for managing the game's data persistence, such as saving and loading game data.
*/
public class DataPersisteneManager : MonoBehaviour
{
    [Header("File Storage Config")]
    [SerializeField] private string fileName;

    private GameData gameData;

    private List<IDataPersistence> dataPersistenceObjects;
    private FileDataHandler dataHandler;

    public static DataPersisteneManager instance { get; private set; }


    /**
    * Awake is called when the script instance is being loaded.
    * Check if there is more than one instance of DataPersisteneManager in the scene.
    */
    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("found mroe than one persistence manager in scene");
        }
        instance = this;
    }

    /**
    * Start is called before the first frame update.
    * Initialize the file data handler and find all data persistence objects in the scene.
    */
    void Start()
    {
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
    }

    /**
    * Creates a new game data object.
    */
    public void NewGame()
    {
        this.gameData = new GameData();
    }

    /**
    * Loads game data from file and pushes the data to all data persistence objects in the scene.
    */
    public void LoadGame()
    {
        this.gameData = dataHandler.Load();

        if (this.gameData == null)
        {
            Debug.Log("No data found");
            NewGame();
        }
        // todo push the loaded data
        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.LoadData(gameData);
        }

        Debug.Log("Loaded player health " + gameData.playerHealth);
    }

    /**
    * Saves game data to file and pushes the data to all data persistence objects in the scene.
    */
    public void SaveGame()
    {
        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.SaveData(ref gameData);
        }

        Debug.Log("Saved player health " + gameData.playerHealth);

        dataHandler.Save(gameData);
    }

    /**
    * Find all data persistence objects in the scene.
    * @return A list of all IDataPersistence objects in the scene.
    */
    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();
        
        return new List<IDataPersistence>(dataPersistenceObjects);
    }



}
