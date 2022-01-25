using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameWindow : MonoBehaviour
{
    public Text scoreText;
    public GameObject pauseWindow;
    public Image remainTimeImage;
    public BlockManager blockManager;
    public GameObject blockButtons;

    [HideInInspector] public int score;

    private float remainTime;
    private float maxRemainTime;
    private bool isPlaying;

    private void Awake()
    {

        isPlaying = false;
    }
    private void OnEnable()
    {
        ResetGame();
    }

    private void Update()
    {
        if (!isPlaying) return;

        SetRemainTimeImage();
        CheckPause();
    }

    private void CheckPause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    private void Pause()
    {
        pauseWindow.SetActive(true);
    }

    private void SetRemainTimeImage()
    {
        remainTime -= Time.deltaTime;
        remainTimeImage.fillAmount = remainTime / maxRemainTime;

        if (remainTime <= 0)
        {
            GameOver();
        }
    }
    public void UpScore()
    {
        score++;
        remainTime = maxRemainTime;
        maxRemainTime -= 0.1f;
        if (maxRemainTime < 1) maxRemainTime = 1;

        SetScoreText();
    }

    public void ResetGame()
    {
        score = 0;
        maxRemainTime = 5;
        isPlaying = true;
        remainTime = maxRemainTime;

        blockButtons.SetActive(true);
        blockManager.gameObject.SetActive(true);
        SetScoreText();
    }

    private void SetScoreText()
    {
        scoreText.text = "" + score;
    }
    
    private void GameOver()
    {
        isPlaying = false;
        blockButtons.SetActive(false);
        GameManager.instance.score = score;
        GameManager.instance.GameOver();
    }

    #region ¹öÆ° & ÅÇ
    public void Button_LeftTap()
    {
        TapBlockButton(0);
    }

    public void Button_RightTap()
    {
        TapBlockButton(1);
    }

    public void Button_Pause()
    {
        Pause();
    }

    private void TapBlockButton(int idx)
    {
        if (!blockManager.TryBreakBlock(idx))
        {
            GameOver();
        }
        else
        {
            UpScore();
        }
    }
    #endregion

}
