using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_Game : MonoBehaviour
{
    [SerializeField] private Button _winRound1;
    [SerializeField] private Button _winRound2;
    [SerializeField] private Button _lose;

    private void OnEnable()
    {
        _winRound1.onClick.AddListener(WinRound1);
        _winRound2.onClick.AddListener(WinRound2);
        _lose.onClick.AddListener(Lose);
    }
    private void WinRound1()
    {
        ManagerUI.Instance.NextRoundGame.gameObject.SetActive(true);
    }
    private void WinRound2()
    {
        ManagerUI.Instance.PopupWinGame.gameObject.SetActive(true);
    }
    private void Lose()
    {
        ManagerUI.Instance.PopupLoseGame.gameObject.SetActive(true);
    }

}
