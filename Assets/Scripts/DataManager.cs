using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public void SaveData(int coin, int level, ChessPiece chess  ){
        Player player = new Player();
        player.Coin = coin;
        player.Level = level;
        player.Chess = chess;
        var data = JsonUtility.ToJson(player);
        File.WriteAllText(Application.dataPath + "/DataPlayer.json", data);
    }
}
[System.Serializable]
public class Player
{
    public int Coin {get; set;}
    public int Level {get; set;}
    public GameObject ChessObject { get; set; }
    public ChessPiece Chess { get; set; }
    public ChessTeam Team { get; set; }
}

public enum ChessTeam
{
    Enemy = 0,
    Player = 1
}


public enum ChessPiece
{
    None = 0,
    Pawn = 1,
    Rook = 2,
    Knight = 3,
    Bishop = 4,
    Queen = 5,
    King = 6

}

