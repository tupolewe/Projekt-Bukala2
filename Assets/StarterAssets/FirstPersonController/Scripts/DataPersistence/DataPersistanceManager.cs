using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPersistanceManager : MonoBehaviour
{
   public static DataPersistanceManager instance { get; private set ; }

    private GameData gameData;

    private List<IDataPersistence> dataPersistenceObjects; 
    private void Awake()
    {     
        if (instance != null)
        {
            Debug.LogError("Found more than one Data Manager");

            
        }
        instance = this;
    }

    public void Start()
    {
        LoadGame();
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
    }

    public void NewGame()
    {
        this.gameData = new GameData();
    }

    public void LoadGame()
    {
        //TODO load any saved data from a file using the data handler
        // if no data, initialize to a new game 
        if (this.gameData == null)
        {
            Debug.Log("No data found");
            NewGame();
        }

        //TODO push the loaded data to all other scripts that need it

        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.LoadData(gameData);
        }

        Debug.Log("Load" + gameData.level);
    }

    public void SaveGame()
    {
        // TODO pass the data to other scripts so they can update their data 
        // TODO save that data to a file using the data handler 

        

        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.SaveData(ref gameData);
        }
        Debug.Log("Saved");

    }

    

    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>()
            .OfType<IDataPersistence>();

        return new List<IDataPersistence>(dataPersistenceObjects);

    }

    public void OnApplicationQuit()
    {
        SaveGame();
    }
}
