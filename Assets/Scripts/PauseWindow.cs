using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseWindow : MonoBehaviour
{
    private void OnEnable()
    {
        Time.timeScale = 0;
    }

    private void Update()
    {
        CheckPauseCancel();
    }

    private void CheckPauseCancel()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ContinueGame();
        }
    }

    private void ContinueGame()
    {
        gameObject.SetActive(false);
    }

    public void Button_Continue()
    {
        ContinueGame();
    }

    private void OnDisable()
    {
        Time.timeScale = 1;
    }
}
