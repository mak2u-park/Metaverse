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
        // 이 코드를 Update에서 실행하는건 불필요하지 않을까?
        scoreText.text = miniGameManager.currentScore.ToString();
        if (miniGameManager.currentScore > miniGameManager.bestscore)
        {
            miniGameManager.bestscore = miniGameManager.currentScore;
        }
        bestScoreText.text = miniGameManager.bestscore.ToString();
    }

}
