using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BaseController
{
    private Camera camera;

    protected override void Start()
    {
        base.Start();
        camera = Camera.main;
    }

    protected override void HandleAction()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        movementDirection = new Vector2(horizontal, vertical).normalized; // ����ȭ�Ͽ� �������ͷ� �������

        Vector2 mousePosition = Input.mousePosition;                      // ��ũ�������� ���콺 ��ġ�� �ȼ� ������ ��ȯ
        Vector2 worldPos = camera.ScreenToWorldPoint(mousePosition);      // ���콺 ������ ��ġ�� ���� ���� ��ǥ�� ��ȯ
        lookDirection = (worldPos - (Vector2)transform.position);         // ���콺 Ŀ�� ��ǥ - ���� ������Ʈ ��ǥ, ���� ���� ����

        if (lookDirection.magnitude < 0.9f)
        {
            lookDirection = Vector2.zero;
        }
        else
        {
            lookDirection = lookDirection.normalized;
        }

        isAttacking = Input.GetMouseButton(0);
    }
}
