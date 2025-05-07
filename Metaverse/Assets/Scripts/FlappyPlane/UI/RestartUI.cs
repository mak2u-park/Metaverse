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
        // �� �ڵ带 Update���� �����ϴ°� ���ʿ����� ������?
        scoreText.text = gameManager.currentScore.ToString();
        if (gameManager.currentScore > gameManager.bestscore)
        {
            gameManager.bestscore = gameManager.currentScore;
        }
        bestScoreText.text = gameManager.bestscore.ToString();
    }

}
