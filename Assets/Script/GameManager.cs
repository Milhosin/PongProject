using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Transform playerPaddle;
    public Transform enemyPaddle;

    public BallController ballController;

    public int playerScore = 0;
    public int enemyScore = 0;

    public TextMeshProUGUI textPointsPlayer;
    public TextMeshProUGUI textPointsEnemy;

    public GameObject screenEndGame;
    public TextMeshProUGUI textEndGame; 

    public int winPoints = 2;

    void Start()
    {
        ResetGame();
    }

    public void ResetGame()
    {
        playerPaddle.position = new Vector3(-7f, 0f, 0f);
        enemyPaddle.position = new Vector3(7f, 0f, 0f);
        ballController.ResetBall();

        playerScore = 0;
        enemyScore = 0;

        textPointsEnemy.text = enemyScore.ToString();
        textPointsPlayer.text = playerScore.ToString();

        screenEndGame.SetActive(false);
    }

    public void ScorePlayer()
    {
        playerScore++;
        textPointsPlayer.text = playerScore.ToString();
        CheckWin();
    }

    public void ScoreEnemy()
    {
        enemyScore++;
        textPointsEnemy.text = enemyScore.ToString();
        CheckWin();
    }

    public void CheckWin()
    {
        if (enemyScore >= winPoints || playerScore >= winPoints)
        {
            EndGame();
        }
    }

    public void EndGame()
    {
        screenEndGame.SetActive(true);
        SaveController.Instance.SaveScores(playerScore, enemyScore);

        Debug.Log("Fim de Jogo! Tentando carregar o menu em 2 segundos.");

        Invoke("LoadMenu", 2f);
    }

    private void LoadMenu()
    {
        Debug.Log("Carregando a cena Menu.");
        SceneManager.LoadScene("Menu");
    }

}
