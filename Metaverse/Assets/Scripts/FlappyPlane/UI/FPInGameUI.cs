using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FPInGameUI : BaseUI
{
    [SerializeField] TextMeshProUGUI bestScoreText;
    [SerializeField] TextMeshProUGUI scoreText;

    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);
        
        bestScoreText.text = miniGameManager.bestscore.ToString();

        miniGameManager.bestscore = PlayerPrefs.GetInt("FPBestScore", 0);
    }

    protected override UIState GetUIState()
    {
        return UIState.FPInGame;
        
    }

    private void Update()
    {
        
        scoreText.text = miniGameManager.currentScore.ToString();
        if (miniGameManager.currentScore >= miniGameManager.bestscore)
        {
            miniGameManager.bestscore = miniGameManager.currentScore;
            bestScoreText.text = miniGameManager.bestscore.ToString();

        }
        else
        {
            bestScoreText.text = miniGameManager.bestscore.ToString();
        }
    }
}
