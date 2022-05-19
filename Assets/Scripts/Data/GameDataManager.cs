using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameDataManager : MonoBehaviour
{
    public static GameDataManager Instance;
    private Data data;
    private string paths = "";
    private string persistanPaths = "";

    public Data Data { get { return data; } set { data = value; } }
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
        data = new Data();
    }
    private void SetPaths()
    {
        paths = Application.dataPath + Path.AltDirectorySeparatorChar + "SaveData.json";
        persistanPaths = Application.persistentDataPath + Path.AltDirectorySeparatorChar + "SaveData.json";
    }

    public void SaveData()
    {
        string savePath = persistanPaths;

        Debug.Log("Saving Data");
        string json = JsonUtility.ToJson(data);
        Debug.Log(json);

        StreamWriter writer = new StreamWriter(savePath);
        writer.Write(json);
    }
    public void LoadData()
    {
        using StreamReader reader = new StreamReader(persistanPaths);
        string json = reader.ReadToEnd();

        data = JsonUtility.FromJson<Data>(json);
        Debug.Log(data.Level);
    }
}
