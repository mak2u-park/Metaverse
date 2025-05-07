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
        movementDirection = new Vector2(horizontal, vertical).normalized; // 정규화하여 단위벡터로 만들어줌

        Vector2 mousePosition = Input.mousePosition;                      // 스크린에서의 마우스 위치를 픽셀 단위로 반환
        Vector2 worldPos = camera.ScreenToWorldPoint(mousePosition);      // 마우스 포인터 위치를 월드 기준 좌표로 변환
        lookDirection = (worldPos - (Vector2)transform.position);         // 마우스 커서 좌표 - 현재 오브젝트 좌표, 보는 방향 백터

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
