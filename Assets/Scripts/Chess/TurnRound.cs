using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnRound : MonoBehaviour
{
    private bool _isPlayerTurn;

    public bool IsPlayerTurn
    {
        get
        {
            return _isPlayerTurn;
        }
        set
        {
            _isPlayerTurn = value;
            Debug.Log($"Is {(_isPlayerTurn ? "Player" : "Enemy")} Turn");
        }
    }
    private Coroutine _waitForChangeToPlayer;

    private void Awake()
    {
        IsPlayerTurn = true;
    }
    IEnumerator CheckTurnPlayer()
    {   
            yield return new WaitForSeconds(3f);
            IsPlayerTurn = true;
    }
    public void ChangeTeam(bool isPlayerTurn)
    {   
        IsPlayerTurn = isPlayerTurn;
        if(!_isPlayerTurn)
        {
            if(_waitForChangeToPlayer != null)
            {
                StopCoroutine(_waitForChangeToPlayer);
            }
            _waitForChangeToPlayer = StartCoroutine(CheckTurnPlayer());
        }
    }
}
