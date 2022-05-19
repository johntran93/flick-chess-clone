using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerUI : MonoBehaviour
{
    public static ManagerUI Instance;
    [SerializeField] private MenuUI _menuGame;
    [SerializeField] private GameUI _playGame;
    [SerializeField] private SettingUI _settingGame;
    [SerializeField] private PopupColorUI _popupColorGame;
    [SerializeField] private NextRoundUI _nextRoundGame;
    [SerializeField] private PopupWinUI _popupWinGame;
    [SerializeField] private PopupLoseUI _popupLoseGame;

    [SerializeField] private MoveThisChessFix _moveChess;
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private List<ItemColor> _listItem = new List<ItemColor>();
    public List<ItemColor> ListItem => _listItem;

    public MenuUI UIMenu => _menuGame;
    public GameUI UIGamePlay => _playGame;
    public SettingUI UISetting => _settingGame;
    public PopupColorUI UIPopupColor => _popupColorGame;
    public NextRoundUI UINextRound => _nextRoundGame;
    public PopupWinUI UIPopupWin => _popupWinGame;
    public PopupLoseUI UIPopupLose => _popupLoseGame;

    public MoveThisChessFix MoveChess => _moveChess;
    public GameManager gameManager => _gameManager;

   

     private void Awake() {
         if(Instance ==null){
             Instance = this;
         }
         else{
             Destroy(gameObject);
         }
     }
    private void Start() 
    {
        
        _menuGame.gameObject.SetActive(true);
        _settingGame.gameObject.SetActive(false);
        _playGame.gameObject.SetActive(false);
        _popupColorGame.gameObject.SetActive(false);
        _nextRoundGame.gameObject.SetActive(false);
        _popupWinGame.gameObject.SetActive(false);
        _popupLoseGame.gameObject.SetActive(false);  
         
    }
    
}


