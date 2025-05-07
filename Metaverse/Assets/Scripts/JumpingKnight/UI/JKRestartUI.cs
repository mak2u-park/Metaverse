using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class JKRestartUI : BaseUI
{
    [SerializeField] TextMeshProUGUI bestScoreText;
    [SerializeField] TextMeshProUGUI scoreText;

    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);

        scoreText.text = miniGameManager.currentScore.ToString();
        miniGameManager.bestscore = PlayerPrefs.GetInt("JKBestScore", 0);
    }
    protected override UIState GetUIState()
    {
        return UIState.FPStart;
    }
}
