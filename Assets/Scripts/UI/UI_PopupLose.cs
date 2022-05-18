using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_PopupLose : MonoBehaviour
{
    [SerializeField] private Button _continue;

    private void OnEnable()
    {   
        _continue.onClick.AddListener(BackLevel);
    }
    private void BackLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}