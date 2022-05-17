using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public int Coin {get; set;}
    public int Level {get; set;}
    public GameObject ChessObject { get; set; }
    public ChessPiece Chess { get; set; }
    public ChessTeam Team { get; set; }
}
