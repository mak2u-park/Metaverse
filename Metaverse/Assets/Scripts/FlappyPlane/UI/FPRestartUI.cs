using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FPRestartUI : BaseUI
{
    [SerializeField] TextMeshProUGUI bestScoreText;
    [SerializeField] TextMeshProUGUI scoreText;

    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);

        scoreText.text = miniGameManager.currentScore.ToString();
        miniGameManager.bestscore = PlayerPrefs.GetInt("FPBestScore", 0);
    }

    protected override UIState GetUIState()
    {
        return UIState.FPRestart;
        
    }
        
    private void Update()
    {
        // �� �ڵ带 Update���� �����ϴ°� ���ʿ����� ������?
        scoreText.text = miniGameManager.currentScore.ToString();
        if (miniGameManager.currentScore > miniGameManager.bestscore)
        {
            miniGameManager.bestscore = miniGameManager.currentScore;
        }
        bestScoreText.text = miniGameManager.bestscore.ToString();
    }

}
