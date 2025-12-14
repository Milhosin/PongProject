using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveController : MonoBehaviour
{
    public Color colorPlayer = Color.white;
    public Color colorEnemy = Color.white;

    private static SaveController _instance;

    public string namePlayer;
    public string nameEnemy;

    public string scorePlayerKey = "ScorePlayer";
    public string scoreEnemyKey = "ScoreEnemy";

    public static SaveController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<SaveController>();

                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject(typeof(SaveController).Name);
                    _instance = singletonObject.AddComponent<SaveController>();
                }
            }
            return _instance;
        }

    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        DontDestroyOnLoad(this.gameObject);
    }

    public string GetName(bool isPlayer)
    {
        return isPlayer ? namePlayer : nameEnemy;
    }

    public void Reset()
    {
        nameEnemy = "";
        namePlayer = "";
        colorEnemy = Color.white;
    }


    public void SaveScores(int playerScore, int enemyScore)
    {
        PlayerPrefs.SetInt(scorePlayerKey, playerScore);
        PlayerPrefs.SetInt(scoreEnemyKey, enemyScore);
        PlayerPrefs.Save(); 
    }

    public int GetPlayerScore()
    {
        return PlayerPrefs.GetInt(scorePlayerKey, 0);
    }

    public int GetEnemyScore()
    {
        return PlayerPrefs.GetInt(scoreEnemyKey, 0);
    }



    public void ClearSave()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
