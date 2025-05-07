using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameManager : MonoBehaviour
{
    static MiniGameManager mimiGameManager;

    public static MiniGameManager Instance
    {
        get { return mimiGameManager; }
    }

    public int currentScore = 0;
    public int bestscore = 0;

    UIManager uiManager;

    private string sceneName;

    public UIManager UIManager { get { return uiManager; } }

    private void Awake()
    {
        if (mimiGameManager != null && mimiGameManager != this)
        {
            Destroy(this.gameObject);
            return;
        }
        mimiGameManager = this;

        uiManager = FindObjectOfType<UIManager>();

    }
    private void Start() // 현재 활성화 X 상태
    {
        sceneName = SceneManager.GetActiveScene().name;
        // 씬 이름에 따라 다른 startUI 활성화
        if (sceneName == "FlappyPlane")
        {
            uiManager.ChangeState(UIState.FPStart);
            Time.timeScale = 0f;
        }
        else if (sceneName == "JumpingKnight")
        {
            //uiManager.ChangeState(UIState.JKStart);
        }
        else if (sceneName == "Dungeon")
        {
            //uiManager.ChangeState(UIState.DGStart);
        }
        
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        Debug.Log("Game Over");
        uiManager.ChangeState(UIState.FPRestart);
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
        // 씬 이름에 따라 다른 PlayerPrefs에 저장
        if (sceneName == "FlappyPlane")
        {
            PlayerPrefs.SetInt("FPBestScore", bestscore);
        }
        else if (sceneName == "JumpingKnight")
        {
            PlayerPrefs.SetInt("JKBestScore", bestscore);
        }
        else if (sceneName == "Dungeon" )
        {
            PlayerPrefs.SetInt("DGBestScore", bestscore);
        }
        PlayerPrefs.Save();
    }

    public void CallBestScore()
    {
        if (sceneName == "FlappyPlane")
        {
            bestscore = PlayerPrefs.GetInt("FPBestScore", 0);
        }
        else if (sceneName == "JumpingKnight")
        {
            bestscore = PlayerPrefs.GetInt("JKBestScore", 0);
        }
        else if (sceneName == "Dungeon")
        {
            bestscore = PlayerPrefs.GetInt("DGBestScore", 0);
        }        
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}