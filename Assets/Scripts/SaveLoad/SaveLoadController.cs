using UnityEngine;
using System.IO;

public class SaveLoadController : MonoBehaviour
{
    private string jsonSavePath;
    public PlayerData _playerData;
    PlayerStatsController _playerStats;
    public MapController _mapController;

    void Awake()
    {
        jsonSavePath = Application.persistentDataPath + "/Data.json";
        _playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStatsController>();

        try
        {
            Load();
        }
        catch (System.Exception)
        {
            Save();
        }
    }

    public void Save()
    {
        //Creating file
        FileStream File1 = new FileStream(jsonSavePath, FileMode.OpenOrCreate);

        //Data to save
        _playerData.coins = _playerStats.coins;
        _playerData.energyPoints = PlayerUpgrades.energyPoints;
        _playerData.chargingPoints = PlayerUpgrades.fastChargingPoints;
        _playerData.lastMapEnded = _mapController.lastMapEnded;

        //Saving data
        string jsonData = JsonUtility.ToJson(_playerData, true);

        File1.Close();
        File.WriteAllText(jsonSavePath, jsonData);
    }

    public void Load()
    {
        //Loading data
        string json = ReadFromFile();
        JsonUtility.FromJsonOverwrite(json, _playerData);

        _playerStats.coins = _playerData.coins;
        PlayerUpgrades.energyPoints = _playerData.energyPoints;
        PlayerUpgrades.fastChargingPoints = _playerData.chargingPoints;
        _mapController.lastMapEnded = _playerData.lastMapEnded;
    }

    private string ReadFromFile()
    {
        using (StreamReader Reader = new StreamReader(jsonSavePath))
        {
            string json = Reader.ReadToEnd();
            return json;
        }
    }
}
