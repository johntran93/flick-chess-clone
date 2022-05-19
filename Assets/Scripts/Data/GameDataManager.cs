using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameDataManager : MonoBehaviour
{
    public static GameDataManager Instance;
    private Data _data;
    private string _paths = "";
    private string _persistanPaths = "";

    public Data Data { get { return _data; } set { _data = value; } }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        CreatPlayerData();
        SetPaths();
    }
    private void CreatPlayerData()
    {
        _data = new Data();
    }
    private void SetPaths()
    {
        _paths = Application.dataPath + Path.AltDirectorySeparatorChar + "SaveData.json";
        _persistanPaths = Application.persistentDataPath + Path.AltDirectorySeparatorChar + "SaveData.json";
    }

    public void SaveData()
    {
        string savePath = _persistanPaths;

        Debug.Log("Saving Data");
        string json = JsonUtility.ToJson(_data);
        Debug.Log(json);

        StreamWriter writer = new StreamWriter(savePath);
        writer.Write(json);
    }
    public void LoadData()
    {
        using StreamReader reader = new StreamReader(_persistanPaths);
        string json = reader.ReadToEnd();

        _data = JsonUtility.FromJson<Data>(json);
        Debug.Log(_data.Level);
    }
}
