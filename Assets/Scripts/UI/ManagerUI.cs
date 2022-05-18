using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerUI : MonoBehaviour
{
    public static ManagerUI Instance;
    [SerializeField] public UI_Menu MenuGame;
    [SerializeField] public UI_Game PlayGame;
    [SerializeField] public UI_Setting SettingGame;
    [SerializeField] public UI_PopupColor PopupColorGame;
    [SerializeField] public UI_NextRound NextRoundGame;
    [SerializeField] public UI_PopupWin PopupWinGame;
    [SerializeField] public UI_PopupLose PopupLoseGame;

    [SerializeField] public MoveThisChessFix MoveChess;
    [SerializeField] public GameManager GameController;
   
    // [SerializeField] public 

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
        
        MenuGame.gameObject.SetActive(true);
        SettingGame.gameObject.SetActive(false);
        PlayGame.gameObject.SetActive(false);
        PopupColorGame.gameObject.SetActive(false);
        NextRoundGame.gameObject.SetActive(false);
        PopupWinGame.gameObject.SetActive(false);
        PopupLoseGame.gameObject.SetActive(false);  
         
    }
    
}


