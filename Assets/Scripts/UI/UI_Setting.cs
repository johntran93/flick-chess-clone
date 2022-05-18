using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Setting : MonoBehaviour
{
    [SerializeField] private Button _backMenu;

    private void OnEnable()
    {   
        _backMenu.onClick.AddListener(BackMenu);
    }
    private void BackMenu()
    {
        ManagerUI.Instance.SettingGame.gameObject.SetActive(false);
    }
}
