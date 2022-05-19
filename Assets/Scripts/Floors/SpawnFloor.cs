using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFloor : MonoBehaviour
{
    public int LevelGame;
    private int NumberObject;

    [SerializeField] private Transform _spawnPos;
    private void Start()
    {
        NumberObject = LevelGame - 1;
        if (LevelGame < 20)
        {
            SpawnFloorLv();
        }
        else
            SpawnFloorRandom();
    }
    public void SpawnFloorLv()
    {
        Vector3 pos = _spawnPos.transform.position;

        GameObject go = Instantiate(FloorManager.Instance.ListFloor[NumberObject].gameObject);
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
