using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    #region Declarations

    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }

    public string currentPlayerName;
    public string bestPlayerName;
    public int bestScore = -1;

    #endregion

    #region Awake

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        LoadBestScoreData();
    }

    #endregion

    #region Save Data Class

    [System.Serializable]
    class BestScore
    {
        public string name;

        public int score;
    }

    #endregion

    #region Save Data

    public void SaveBestScoreData()
    {
        BestScore data = new BestScore();

        data.name = bestPlayerName;

        data.score = bestScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/bestScoreData.json", json);
    }

    #endregion

    #region Load Data
    
    public void LoadBestScoreData()
    {
        string path = Application.persistentDataPath + "/bestScoreData.json";

        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);

            BestScore data = JsonUtility.FromJson<BestScore>(json);

            bestPlayerName = data.name;

            bestScore = data.score;
        }
    }
    #endregion
}
