using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager gameManager;

    public static GameManager Instance
    {
        get { return gameManager; }
    }

    public int currentScore = 0;
    public int bestscore = 0;

    UIManager uiManager;
    public UIManager UIManager { get { return uiManager; } }

    private void Awake()
    {
        if (gameManager != null && gameManager != this)
        {
            Destroy(this.gameObject);
            return;
        }
        gameManager = this;

        uiManager = FindObjectOfType<UIManager>();

    }
    private void Start() // 현재 활성화 X 상태
    {
        // startUI 활성화
        uiManager.ChangeState(UIState.Start);
        Time.timeScale = 0f;
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        Debug.Log("Game Over");
        uiManager.ChangeState(UIState.Restart);
        SaveBestScore();
    }

    public void AddScore(int score)
    {
        currentScore += score;

        Debug.Log("Score: " + currentScore);
        //uiManager.UpdateScore(currentScore);
    }

    public void SaveBestScore()
    {
        PlayerPrefs.SetInt("FPBestScore", bestscore);
        PlayerPrefs.Save();
    }

    public void CallBestScore()
    {
        bestscore = PlayerPrefs.GetInt("FPBestScore", 0);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}