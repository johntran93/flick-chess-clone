using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextRoundUI : MonoBehaviour
{
    [SerializeField] private Button _continue;

    private void OnEnable()
    {   
        _continue.onClick.AddListener(NextMap);
    }
    private void NextMap()
    {
        ManagerUI.Instance.UINextRound.gameObject.SetActive(false);
        ManagerUI.Instance.MoveChess.moveChess2();
    }

}
