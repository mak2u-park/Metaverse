using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class BaseUI : MonoBehaviour
{
    protected GameManager gameManager;
    protected UIManager uiManager;

    public virtual void Init(UIManager uiManager)
    {
        gameManager = GameManager.Instance;
        this.uiManager = uiManager;
    }
    
    protected abstract UIState GetUIState();

    public void SetActive(UIState state)
    {
        bool isActive = GetUIState() == state;
        Debug.Log($"{gameObject.name} SetActive({isActive}) for state {state}");
        gameObject.SetActive(GetUIState() == state);
    }

}
