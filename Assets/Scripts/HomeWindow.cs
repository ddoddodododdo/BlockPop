using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeWindow : MonoBehaviour
{
    public GameManager gameManager;

    public void Button_StartPlay()
    {
        gameManager.PlayGame();
        gameObject.SetActive(false);
    }

    public void Button_Quit()
    {
        Application.Quit();
    }

}
