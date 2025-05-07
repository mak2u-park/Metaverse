using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RestartUI : BaseUI
{
    [SerializeField] TextMeshProUGUI bestScoreText;
    [SerializeField] TextMeshProUGUI scoreText;

    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);

        scoreText.text = gameManager.currentScore.ToString();
        gameManager.bestscore = PlayerPrefs.GetInt("FPBestScore", 0);
    }

    protected override UIState GetUIState()
    {
        return UIState.Restart;
        
    }
        
    private void Update()
    {
        // 이 코드를 Update에서 실행하는건 불필요하지 않을까?
        scoreText.text = gameManager.currentScore.ToString();
        if (gameManager.currentScore > gameManager.bestscore)
        {
            gameManager.bestscore = gameManager.currentScore;
        }
        bestScoreText.text = gameManager.bestscore.ToString();
    }

}
