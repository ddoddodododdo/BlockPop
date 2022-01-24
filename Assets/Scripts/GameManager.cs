using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public GameObject gameOverWindow;
    public GameObject homeWindow;
    public GameObject gameWindow;
    public BlockManager blockManager;

    [HideInInspector] public int score = 0;


    private void Awake()
    {
        instance = this;
        homeWindow.SetActive(true);
        gameWindow.SetActive(false);
        gameOverWindow.SetActive(false);
        blockManager.gameObject.SetActive(false);
        SetApplication();
    }

    private void SetApplication()
    {
        Application.targetFrameRate = 60;
    }


    public void PlayGame()
    {
        gameWindow.SetActive(true);
    }

    public void GameOver()
    {
        gameOverWindow.SetActive(true);
    }


}
