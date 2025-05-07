using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

// �ٸ� �������� UI�� �����Ҷ��� �� ��ũ��Ʈ�� ����ϱ� ���� enum���� �����ϱ�� �ߴ�.
public enum UIState
{    
    // FlappyPlane UI
    FPStart,
    FPInGame,
    FPRestart,

    // JumpingKnight UI (����)
    JKStart,
    JKInGame,
    JKRestart
    // Dungeon UI (����)

}

public class UIManager : MonoBehaviour
{
    // ���� ���ǿ����� �̱����� ���������� �̹� ���� ���������� static�� ������� �ʴ� ���� ��ǥ�� �Ͽ���.

    UIState currentstate = UIState.FPStart;

    // FlappyPlane UI
    FPStartUI FPstartUI = null;
    FPInGameUI FPinGameUI = null;
    FPRestartUI FPrestartUI = null;

    // JumpingKnight UI (����)
    JKStartUI JKstartUI = null;
    JKInGameUI JKInGameUI = null;
    JKRestartUI JKrestartUI = null;

    // Dungeon UI (����)


    private string sceneName;

    private void Awake()
    {
        // ��Ȱ��ȭ �Ǿ��ִ� ������Ʈ�鵵 ã�� ������ ����
        sceneName = SceneManager.GetActiveScene().name;
        if (sceneName == "FlappyPlane") 
        {
            // FlappyPlane UI
            FPstartUI = GetComponentInChildren<FPStartUI>(true);
            FPstartUI?.Init(this);
            FPrestartUI = GetComponentInChildren<FPRestartUI>(true);
            FPrestartUI?.Init(this);
            FPinGameUI = GetComponentInChildren<FPInGameUI>(true);
            FPinGameUI?.Init(this);
        }
        else if (sceneName == "JumpingKnight")  
        {
            // JumpingKnight UI (����)
            JKstartUI = GetComponentInChildren<JKStartUI>(true);
            JKstartUI?.Init(this);
            JKInGameUI = GetComponentInChildren<JKInGameUI>(true);
            JKInGameUI?.Init(this);
            JKrestartUI = GetComponentInChildren<JKRestartUI>(true);
            JKrestartUI?.Init(this);
        }
        else if (sceneName == "Dungeon") 
        {
            // Dungeon UI (����)
        }
        ChangeState(UIState.FPRestart);
    }

    

    public void ChangeState(UIState state)
    {
        currentstate = state; 
        FPstartUI?.SetActive(currentstate);
        FPinGameUI?.SetActive(currentstate);
        FPrestartUI?.SetActive(currentstate);

        // currentState�� � state������ ���� ������ UIState�� true ���·� Ȱ��ȭ
    }

    // startButton, RestartButton�� �߰��� �Լ�
    public void GameStart()
    {
        Time.timeScale = 1f;
        ChangeState(UIState.FPInGame);
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
