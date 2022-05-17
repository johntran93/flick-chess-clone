using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;

public class MoveThisChessFix : MonoBehaviour
{
    [SerializeField] private List<Transform> _chess = new List<Transform>();
    [SerializeField] private List<Transform> destination = new List<Transform>();
    [SerializeField] private List<Transform> destinationRun1 = new List<Transform>();
    [SerializeField] private List<Transform> destination2 = new List<Transform>();
    [SerializeField] private List<Transform> destinationRun2 = new List<Transform>();

    public Transform destinationRound1, destinationRound2;
    public GameObject CamPlay1, CamPlay2;

    // public bool Round1Play, Round2Play;


    public GameObject floorLane, floorLane2;
    public bool floorLaneActive, floorLane2Active;


    void Start()
    {
        floorLane.SetActive(false);
        floorLane2.SetActive(false);
        floorLaneActive = false;
        floorLane2Active = false;
        CamPlay1.SetActive(false);
        CamPlay2.SetActive(false);
        // Round1Play = false;
        // Round2Play = false;

    }


    public void moveChess()
    {
        // moveTarget = true;
        floorLane.SetActive(true);
        // Round1Play = true;

        for (int i = 0; i < _chess.Count; i++)
        {
            _chess[i].DOMove(destinationRun1[i].position, 5f).SetDelay(0)
            .OnComplete(() =>
            {
                _chess[i].DOMove(destinationRound1.position, 5f);


                for (int j = 0; j < _chess.Count; j++)
                {
                    _chess[j].DOMove(destination[j].position, 5f)
                    .OnComplete(() =>
                    {
                        floorLane.SetActive(false);
                        CamPlay1.SetActive(true);
                    });
                }


            });

        }
    }

    public void moveChess2()
    {
        floorLane2.SetActive(true);
        CamPlay1.SetActive(false);
        // Round1Play = false;
        // Round2Play = true;

        for (int k = 0; k < _chess.Count; k++)
        {
            _chess[k].DOMove(destinationRun2[k].position, 5f)
            .OnComplete(() =>
            {
                _chess[k].DOMove(destinationRound2.position, 5f);

                for (int h = 0; h < _chess.Count; h++)
                {
                    _chess[h].DOMove(destination2[h].position, 5f)
                    .OnComplete(() =>
                    {
                        floorLane2.SetActive(false);
                        CamPlay2.SetActive(true);
                    });
                }

            });
        }
    }
}
