using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowGrid : MonoBehaviour
{

    [SerializeField] private Transform _girdCellPrefabs;
    [SerializeField] private int _width;
    [SerializeField] private int _coin = 50;

    private int _valuaeCoinAfterBuy;
    private int _count;
    private Vector3 _lastPos;
    private List<Transform> _listCell = new List<Transform>();

    private int _coinData;

    public List<Transform> ListCell => _listCell;
    private void Awake() {
        CreatGrid();
    }
    void Start()
    {
        _valuaeCoinAfterBuy = 1;
        _count = 0;
        
        gameObject.transform.position = gameObject.transform.position;
        _coinData = GameDataManager.Instance.Data.Coin;
    }
    public void CreatGrid()
    {
        for (int i = 0; i < 4; i++)
        {
            Vector3 pos = new Vector3(gameObject.transform.position.x - i * 2, gameObject.transform.position.y, gameObject.transform.position.z);
            Transform obj = Instantiate(_girdCellPrefabs, pos, Quaternion.identity);
            obj.SetParent(gameObject.transform);
            _listCell.Add(obj);
            _lastPos = obj.localPosition;
        }
    }

    public void AddNewGrid()
    {

        if (_coin < 0)
        {
            return;
        }
        _valuaeCoinAfterBuy = _valuaeCoinAfterBuy * 2;
        _coin = _coin - _valuaeCoinAfterBuy;
        _count += 2;
        if (_lastPos.x == -6)
        {
            Vector3 pos = new Vector3(gameObject.transform.position.x + _lastPos.x - 2, gameObject.transform.position.y, gameObject.transform.position.z);
            Transform obj = Instantiate(_girdCellPrefabs, pos, Quaternion.identity);
            
            obj.SetParent(gameObject.transform);
            _listCell.Add(obj);
            _lastPos = obj.localPosition;
            _lastPos.x = 0;
        }
        if (_count >= 4 && _count < 13)
        {
            Vector3 pos1 = new Vector3(gameObject.transform.position.x + 4 - _count, gameObject.transform.position.y, gameObject.transform.position.z + 2);
            Transform obj1 = Instantiate(_girdCellPrefabs, pos1, Quaternion.identity);
            obj1.SetParent(gameObject.transform);
            _listCell.Add(obj1);
            _lastPos = obj1.localPosition;
            _lastPos.x = 0;
        }
    }
}
