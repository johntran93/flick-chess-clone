using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UI_Menu : MonoBehaviour
{
    [SerializeField] private Button _startGame;
    [SerializeField] private Button _createGrid;
    [SerializeField] private Button _createChess;
    [SerializeField] private Button _Choosencolor;
    [SerializeField] private Button _Setting;
    // [SerializeField] private Button _RewardAds;

    private void OnEnable()
    {   
        _startGame.onClick.AddListener(StartGame);
        _Setting.onClick.AddListener(OpenSetting);
        _Choosencolor.onClick.AddListener(ChoosenNewColor);
        _createChess.onClick.AddListener(Give1chess);
        _createGrid.onClick.AddListener(Give1Gird);
      
    }

    private void StartGame()
    {
        ManagerUI.Instance.PlayGame.gameObject.SetActive(true);
        ManagerUI.Instance.MenuGame.gameObject.SetActive(false);
        ManagerUI.Instance.MoveChess.moveChess();
        ManagerUI.Instance.GameController.SetGameIsPlay();
    }
    private void OpenSetting()
    {
        ManagerUI.Instance.SettingGame.gameObject.SetActive(true);
    }
    private void ChoosenNewColor()
    {
        ManagerUI.Instance.PopupColorGame.gameObject.SetActive(true);
    }
    private void Give1chess()
    {
        
    }
    private void Give1Gird()
    {

    }
    
}
