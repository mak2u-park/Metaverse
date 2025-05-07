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
    Start,
    InGame,
    Restart

    // JumpingKnight UI (����)

    // Dungeon UI (����)

}

public class UIManager : MonoBehaviour
{
    // ���� ���ǿ����� �̱����� ���������� �̹� ���� ���������� static�� ������� �ʴ� ���� ��ǥ�� �Ͽ���.

    UIState currentstate = UIState.Start;

    // FlappyPlane UI
    StartUI startUI = null;
    InGameUI inGameUI = null;
    RestartUI restartUI = null;

    // JumpingKnight UI (����)

    // Dungeon UI (����)

    private void Awake()
    {
        // ��Ȱ��ȭ �Ǿ��ִ� ������Ʈ�鵵 ã�� ������ ����

        // FlappyPlane UI
        startUI = GetComponentInChildren<StartUI>(true);
        startUI?.Init(this);
        restartUI = GetComponentInChildren<RestartUI>(true);
        restartUI?.Init(this);
        inGameUI = GetComponentInChildren<InGameUI>(true);
        inGameUI?.Init(this);

        // JumpingKnight UI (����)

        // Dungeon UI (����)

        ChangeState(UIState.Restart);
    }

    

    public void ChangeState(UIState state)
    {
        currentstate = state; 
        startUI?.SetActive(currentstate);
        inGameUI?.SetActive(currentstate);
        restartUI?.SetActive(currentstate);

        // currentState�� � state������ ���� ������ UIState�� true ���·� Ȱ��ȭ
    }

    // startButton, RestartButton�� �߰��� �Լ�
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
