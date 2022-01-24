using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
   
    public enum GameState
    {
        Play, Ready
    }

    public static GameManager instance;

    public Text scoreText;
    public Text bestScoreText;
    public Image remainTimeImage;
    public GameObject gameOverWindow;
    public GameObject homeWindow;
    public GameObject gameWindow;
    public GameObject blockButtons;
    public BlockManager blockManager;

    [HideInInspector] public GameState nowState;
    [HideInInspector] public int score = 0;

    private float remainTime = 0;
    private float maxRemainTime = 5;


    private void Awake()
    {
        instance = this;
        SetApplication();
        homeWindow.SetActive(true);
        gameWindow.SetActive(false);
        gameOverWindow.SetActive(false);
        blockManager.gameObject.SetActive(false);
        nowState = GameState.Ready;
    }

    private void SetApplication()
    {
        Application.targetFrameRate = 60;
    }

    private void Update()
    {
        CheckTap();
        SetRemainTimeImage();
    }

    private void CheckTap()
    {
        if (nowState != GameState.Play)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
            TapBlockButton(0);
        else if (Input.GetKeyDown(KeyCode.RightArrow))
            TapBlockButton(1);
    }
    private void SetRemainTimeImage()
    {
        if (nowState != GameState.Play) return;

        remainTime -= Time.deltaTime;
        remainTimeImage.fillAmount = remainTime / maxRemainTime;

        if (remainTime <= 0) GameOver();
    }

    public void PlayGame()
    {
        score = 0;
        maxRemainTime = 5;
        nowState = GameState.Play;
        blockManager.gameObject.SetActive(true);
        remainTime = maxRemainTime;
        gameWindow.SetActive(true);
        blockButtons.SetActive(true);
        SetScoreText();
    }

    public void UpScore()
    {
        score++;
        remainTime = maxRemainTime;
        maxRemainTime -= 0.1f;
        if (maxRemainTime < 1) maxRemainTime = 1;

        SetScoreText();
    }

    private void SetScoreText()
    {
        scoreText.text = "" + score;
    }

    public void GameOver()
    {
        nowState = GameState.Ready;
        blockButtons.SetActive(false);
        gameOverWindow.SetActive(true);
    }


    #region 버튼함수


    public void Button_LeftTap()
    {
        TapBlockButton(0);
    }

    public void Button_RightTap()
    {
        TapBlockButton(1);
    }

    private void TapBlockButton(int idx)
    {
        if (!blockManager.TryBreakBlock(idx))
        {
            GameOver();
        }
    }

    #endregion
}
