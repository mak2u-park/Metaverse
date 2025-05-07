using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

// 다른 씬에서의 UI를 관리할때도 이 스크립트를 사용하기 위해 enum으로 관리하기로 했다.
public enum UIState
{    
    // FlappyPlane UI
    Start,
    InGame,
    Restart

    // JumpingKnight UI (예정)

    // Dungeon UI (예정)

}

public class UIManager : MonoBehaviour
{
    // 원래 강의에서는 싱글톤을 선언했지만 이번 개인 과제에서는 static을 사용하지 않는 것을 목표로 하였다.

    UIState currentstate = UIState.Start;

    // FlappyPlane UI
    StartUI startUI = null;
    InGameUI inGameUI = null;
    RestartUI restartUI = null;

    // JumpingKnight UI (예정)

    // Dungeon UI (예정)

    private void Awake()
    {
        // 비활성화 되어있는 오브젝트들도 찾기 때문에 안전

        // FlappyPlane UI
        startUI = GetComponentInChildren<StartUI>(true);
        startUI?.Init(this);
        restartUI = GetComponentInChildren<RestartUI>(true);
        restartUI?.Init(this);
        inGameUI = GetComponentInChildren<InGameUI>(true);
        inGameUI?.Init(this);

        // JumpingKnight UI (예정)

        // Dungeon UI (예정)

        ChangeState(UIState.Restart);
    }

    

    public void ChangeState(UIState state)
    {
        currentstate = state; 
        startUI?.SetActive(currentstate);
        inGameUI?.SetActive(currentstate);
        restartUI?.SetActive(currentstate);

        // currentState가 어떤 state인지에 따라 동일한 UIState만 true 상태로 활성화
    }

    // startButton, RestartButton에 추가할 함수
    public void GameStart()
    {
        Time.timeScale = 1f;
        ChangeState(UIState.InGame);
    }

    public void MainMenu()
    {
        Time.timeScale = 0f;
        SceneManager.LoadScene("FlappyPlane");
    }

    public void GameExit()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMap");
    }

}
