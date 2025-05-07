using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FPStartUI : BaseUI
{    
    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);

    }

    protected override UIState GetUIState()
    {
        return UIState.FPStart;
    }

    
}
