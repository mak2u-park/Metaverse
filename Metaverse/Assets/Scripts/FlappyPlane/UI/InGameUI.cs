using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InGameUI : BaseUI
{
    [SerializeField] TextMeshProUGUI bestScoreText;
    [SerializeField] TextMeshProUGUI scoreText;

    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);
        
        bestScoreText.text = gameManager.bestscore.ToString();

        gameManager.bestscore = PlayerPrefs.GetInt("FPBestScore", 0);
    }

    protected override UIState GetUIState()
    {
        return UIState.InGame;
        
    }

    private void Update()
    {
        
        scoreText.text = gameManager.currentScore.ToString();
        if (gameManager.currentScore >= gameManager.bestscore)
        {
            gameManager.bestscore = gameManager.currentScore;
            bestScoreText.text = gameManager.bestscore.ToString();

        }
        else
        {
            bestScoreText.text = gameManager.bestscore.ToString();
        }
    }
}
