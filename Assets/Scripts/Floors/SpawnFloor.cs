using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFloor : MonoBehaviour
{
    public int LevelGame;
    private int _numberObject;
    [SerializeField] private Transform _spawnPos;
    private void Start()
    {
        _numberObject = LevelGame - 1;
        if (_numberObject > FloorManager.Instance.ListFloor.Count)
        {
            SpawnFloorRandom();
        }
        else
        {
            SpawnFloorLv();
        }
    }
    public void SpawnFloorLv()
    {
        Vector3 pos = _spawnPos.transform.position;

        GameObject go = Instantiate(FloorManager.Instance.ListFloor[_numberObject].gameObject);
        go.transform.position = pos;
    }
    public void SpawnFloorRandom()
    {
        int floor = Random.Range(0, FloorManager.Instance.ListFloor.Count);
        Vector3 pos = _spawnPos.transform.position;

        GameObject go = Instantiate(FloorManager.Instance.ListFloor[floor].gameObject);
        go.transform.position = pos;
    }

}
