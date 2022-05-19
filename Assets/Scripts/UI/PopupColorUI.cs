using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupColorUI : MonoBehaviour
{

    [SerializeField] private Button _openRandom;
    [SerializeField] private Button _backMenu;

    private void OnEnable()
    {   
        _openRandom.onClick.AddListener(OpenRandomColor);
        _backMenu.onClick.AddListener(BackMenu);
    }
    private void OpenRandomColor()
    {
        
    }
    private void BackMenu()
    {
        ManagerUI.Instance.UIPopupColor.gameObject.SetActive(false);
    }
}
