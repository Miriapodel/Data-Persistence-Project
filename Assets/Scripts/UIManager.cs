using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEditor;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    #region Declarations

    public TextMeshProUGUI playerNameText;
    public TextMeshProUGUI bestScoreText;

    string playerName;
       

    #endregion

    #region Start

    // Start is called before the first frame update
    void Start()
    {
        ShowBestScore();
    }

    #endregion

    #region Get Player Name

    public void GetPlayerName()
    {
        playerName = playerNameText.text;

        GameManager.Instance.currentPlayerName = playerName;
    }

    #endregion

    #region Start Game Button

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    #endregion

    #region End Game Button

    public void EndGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    #endregion

    #region Show Best Score

    public void ShowBestScore()
    {
        if(GameManager.Instance.bestScore > -1)
        {
            bestScoreText.text = "Beste Score: " + GameManager.Instance.bestPlayerName + "-" + GameManager.Instance.bestScore;
        }
    }

    #endregion

}
