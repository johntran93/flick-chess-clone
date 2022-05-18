using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_PopupWin : MonoBehaviour
{
    [SerializeField] private Button _continue;

    private void OnEnable()
    {   
        _continue.onClick.AddListener(NextLevel);
    }
    private void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
