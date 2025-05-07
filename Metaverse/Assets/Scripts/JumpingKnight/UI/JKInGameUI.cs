using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class JKInGameUI : BaseUI
{
    [SerializeField] TextMeshProUGUI bestScoreText;
    [SerializeField] TextMeshProUGUI scoreText;

    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);

    }
    protected override UIState GetUIState()
    {
        return UIState.FPStart;
    }
}
