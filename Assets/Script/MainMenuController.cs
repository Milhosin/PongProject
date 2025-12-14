using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuManager : MonoBehaviour
{
    // Arraste seus objetos de texto da UI do Menu para estas referências no Inspector
    public TextMeshProUGUI lastPlayerScoreText;
    public TextMeshProUGUI lastEnemyScoreText;

    void Start()
    {
        LoadAndDisplayLastScores();
    }

    public void LoadAndDisplayLastScores()
    {
        // Pede ao SaveController para buscar os dados que estão salvos no PlayerPrefs
        int pScore = SaveController.Instance.GetPlayerScore();
        int eScore = SaveController.Instance.GetEnemyScore();

        string pName = SaveController.Instance.namePlayer;
        string eName = SaveController.Instance.nameEnemy;


        // Atualiza os elementos de texto na tela do Menu
        if (lastPlayerScoreText != null)
        {
            lastPlayerScoreText.text = pName + " Pontuação: " + pScore.ToString();
        }

        if (lastEnemyScoreText != null)
        {
            lastEnemyScoreText.text = eName + " Pontuação: " + eScore.ToString();
        }
    }

    // Você pode adicionar um botão no Menu para chamar esta função, se quiser limpar o save
    public void ClearSavedDataButton()
    {
        SaveController.Instance.ClearSave();
        LoadAndDisplayLastScores(); // Atualiza o texto imediatamente para mostrar 0
    }
}
