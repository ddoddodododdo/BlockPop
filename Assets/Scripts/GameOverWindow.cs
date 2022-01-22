using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverWindow : MonoBehaviour
{
    public const string BEST_SCORE_KEY = "BestScore";

    public GameManager gameManager;

    public Text bestScoreText;


    private void OnEnable()
    {
        SetBestScore();
    }

    public void SetBestScore()
    {
        int score = gameManager.score;
        int bestScore = PlayerPrefs.GetInt(BEST_SCORE_KEY, 0);

        if (score > bestScore)
        {
            PlayerPrefs.SetInt(BEST_SCORE_KEY, score);
            bestScore = score;
        }

        bestScoreText.text = "" + bestScore;
    }


    public void Button_GoToHome()
    {
        gameManager.gameWindow.gameObject.SetActive(false);
        gameManager.blockManager.gameObject.SetActive(false);
        gameManager.homeWindow.gameObject.SetActive(true);

        gameObject.SetActive(false);
    }


}
