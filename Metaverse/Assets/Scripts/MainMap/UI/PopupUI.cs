using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PopupUI : MonoBehaviour
{
    private bool isContacted = false;
    private int npcnum; // NPC 구분 번호

    private UIHandler uiHandler;


    private void Start()
    {
        uiHandler = FindObjectOfType<UIHandler>();
    }

    private void OnTriggerEnter2D(Collider2D player)
    {
        if (player.CompareTag("Player"))
        {
            string name = this.gameObject.name;
            switch (name)
            {
                case "Elf":
                    uiHandler.PopupUI(1, this.transform);
                    Debug.Log("Elf");
                    break;
                case "Dwarf":
                    uiHandler.PopupUI(2, this.transform);
                    Debug.Log("Dwarf");
                    break;
                case "Angel":
                    uiHandler.PopupUI(3, this.transform);
                    Debug.Log("Angel");
                    break;
            }

            isContacted = true;

        }
    }

    private void OnTriggerExit2D(Collider2D player)
    {
        if (player.CompareTag("Player"))
        {
            isContacted = false;
            uiHandler.CloseUI();
        }
    }

}
