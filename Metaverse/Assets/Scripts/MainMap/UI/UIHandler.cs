using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    // NPC 별 UI 
    [SerializeField] GameObject FlappyPlaneUI;
    [SerializeField] GameObject JumpingKnightUI;
    [SerializeField] GameObject DungeonUI;

    // UI 위치 설정을 위한 RectTransform
    [SerializeField] RectTransform FlappyPlaneUIRect;
    [SerializeField] RectTransform JumpingKnightUIRect;
    [SerializeField] RectTransform DungeonUIRect;

    [SerializeField] private TextMeshProUGUI FPBestScoreText;


    void Start()
    {
        int bestScore = PlayerPrefs.GetInt("FPBestScore", 0);
        FPBestScoreText.text = bestScore.ToString();
    }

    public void PopupUI(int npcNumber, Transform npcTransorm)
    {
        CloseUI();

        // UI 위치 설정, NPC의 왼쪽에 위치
        Vector3 worldPos = npcTransorm.position + Vector3.left * 5f;
        Vector3 screenPos = Camera.main.WorldToScreenPoint(worldPos);

        switch (npcNumber)
        {
            case 1:
                FlappyPlaneUI?.SetActive(true);
                if (FlappyPlaneUIRect != null)
                {
                    FlappyPlaneUIRect.position = screenPos;
                }
                break;
            case 2:
                JumpingKnightUI?.SetActive(true);
                if (JumpingKnightUIRect != null)
                {
                    JumpingKnightUIRect.position = screenPos;
                }
                break;
            case 3:
                DungeonUI?.SetActive(true);
                if (DungeonUIRect != null)
                {
                    DungeonUIRect.position = screenPos;
                }
                break;
        }
    }

    public void CloseUI()
    {
        FlappyPlaneUI?.SetActive(false);
        JumpingKnightUI?.SetActive(false);
        DungeonUI?.SetActive(false);
        // if (UI != null)
    }

}
