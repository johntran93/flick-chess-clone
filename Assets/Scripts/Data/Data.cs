using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Data
{
    private int _coin;
    private int _level;
    private Material _material;
    private int _indexGameObject;
    private int _indexInGridl;

    public Data()
    {
        
    }

    public int Coin
    {
        get { return _coin; }
        set { _coin = value; }
    }
    public int Level
    {
        get { return _level; }
        set { _level = value; }
    }
    public int IndexGameObject
    {
        get { return _indexGameObject; }
        set { _indexGameObject = value; }
    }
    public int IndexInGrid
    {
        get { return _indexInGridl; }
        set { _indexInGridl = value; }
    }
    public Material material
    {
        get { return _material; }
        set { _material = value; }
    }
   
}

public class ListData
{
    private static ListData instance = null;
    private List<Data> data = new List<Data>();

    public List<Data> Data
    {
        get { return data; }
        //set { data = value; }
    }

    public static ListData Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new ListData();
            }
            return instance;
        }
    }

}
