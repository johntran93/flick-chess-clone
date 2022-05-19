using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;

public class MoveThisChess : MonoBehaviour
{
    public Transform ChessFull, ChessKing, ChessLane1, ChessLane2;
    public Transform destinationRound1, destinationRound2, destination, destination1, destination2;


    //public Transform ChessFull, ChessKing, ChessLane1, ChessLane2, ChessLane3, ChessLane4, ChessLane5, ChessLane6, ChessLane7, ChessLane8, ChessLane9;
   // public Transform destinationRound1, destinationRound2, destination, destination1, destination2, destination3, destination4, destination5, destination6, destination7, destination8, destination9;

    // public float lerpSpeed, lerpSpeed2;
    // public float moveValue;
   

    public GameObject floorLane, floorLane2;
    public bool floorLaneActive, floorLane2Active;


    void Start()
    {
        floorLane.SetActive(false);
        floorLane2.SetActive(false);
        floorLaneActive = false;
        floorLane2Active = false;

    }
    

    public void moveChess()
    {
        // moveTarget = true;
       floorLane.SetActive(true);
        
        ChessFull.DOMove(destinationRound1.position, 5f);
            // .SetEase(Ease.InOutSine)
            // .OnComplete(() => Debug.Log("abc"));
        // Chess2.DOMove(destination2.position, 5f);
    }
    public void moveChess2()
    {
        floorLane2.SetActive(true);
        ChessKing.DOMove(destination.position, 5f);
        ChessLane1.DOMove(destination1.position, 5f);
        ChessLane2.DOMove(destination2.position, 5f)
       
        .OnComplete(() =>
        {
            ChessFull.DOMove(destinationRound2.position, 5f);
        });


    }

}
