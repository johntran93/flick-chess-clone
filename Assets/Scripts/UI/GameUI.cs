using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameUI : MonoBehaviour
{
    [SerializeField] private Button _winRound1;
    [SerializeField] private Button _winRound2;
    [SerializeField] private Button _lose;

    public GameObject Round2;

    public void Start()
    {
        Round2.SetActive(false);
    }
    private void OnEnable()
    {
        _winRound1.onClick.AddListener(WinRound1);
        _winRound2.onClick.AddListener(WinRound2);
        _lose.onClick.AddListener(Lose);
    }
    private void WinRound1()
    {
        ManagerUI.Instance.UINextRound.gameObject.SetActive(true);
        Round2.SetActive(true);
    }
    private void WinRound2()
    {
        ManagerUI.Instance.UIPopupWin.gameObject.SetActive(true);
    }
    private void Lose()
    {
        ManagerUI.Instance.UIPopupLose.gameObject.SetActive(true);
    }

}
