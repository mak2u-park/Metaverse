using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MiniGameInput : MonoBehaviour
{
    public float requiredContactTime = 1f; // 1�� �̻� ���� �����ϸ� �̴ϰ��� ������ �̵�

    private bool isContacted = false;
    private float contactTime = 0f;
    private int Doornum; // �� ���� ��ȣ


    private void Update()
    {
        if (isContacted)
        {
            contactTime += Time.deltaTime;
            if (contactTime >= requiredContactTime)
            {
                EnterMiniGame(Doornum);
                isContacted = false;
            }
        }
        else
        {
            contactTime = 0f;
        }
    }


    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("Player"))
        {
            string name = this.gameObject.name;
            Debug.Log("�� ����");
            switch (name)
            {
                case "Door1":
                    Doornum = 1;
                    break;
                case "Door2":
                    Doornum = 2;
                    break;
                case "Door3":
                    Doornum = 3;
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
            contactTime = 0f;
        }
    }


    private void EnterMiniGame(int doornum)
    {
        switch (doornum)
        {
            case 1:
                SceneManager.LoadScene("FlappyPlane");
                break;
            case 2:
                SceneManager.LoadScene("JumpingKnight");
                break;
            case 3:
                // SceneManager.LoadScene("Dungeon");
                break;
        }

    }

    public void EndMiniGame()
    {
        // �̴ϰ��� ���� �� ���� ������ ���ƿö� ���� �ڸ��� �̵��ϴ� ���� ��ǥ
    }

}
