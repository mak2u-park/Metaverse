using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JKPlayer : MonoBehaviour 
    // Jumping Knight Player
    // 기사가 점프하는 애니메이션을 호출하고, 가시와 충돌했을 때 체력을 감소, 체력이 0이 되었을 때 게임 오버 처리
    // 게임 오버 후에는 재시작 버튼을 눌러서 재시작
{
    Animator animator = null;
    Rigidbody2D _rigidbody = null;

    public float deathCooldown = 0f;
    public bool isDead = false;
    bool isjump = false;


    MiniGameManager miniGameManager;
    ResourceController resourceController;

    // Start is called before the first frame update
    void Start()
    {
        miniGameManager = MiniGameManager.Instance;
        resourceController = GetComponent<ResourceController>(); // 가시를 밟았을 때 체력 감소를 위해서

        animator = transform.GetComponentInChildren<Animator>();
        _rigidbody = transform.GetComponent<Rigidbody2D>();

        if (animator == null)
        {
            Debug.LogError("Not Founded Animator");
        }

        if (_rigidbody == null)
        {
            Debug.LogError("Not Founded Rigidbody");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            if ( deathCooldown <= 0)
            {
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                {
                    // 게임 재시작
                    miniGameManager.RestartGame();
                    // DontDestroyOnLoad 코드가 없기 때문에 MiniGameManager의 인스턴스를 파괴하고 다시 생성
                }
            }
            else
            {
                deathCooldown -= Time.deltaTime;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                isjump = true;
            }
        }
    }

    private void FixedUpdate()
    {
        if (isDead)
            return;

        if (isjump)
        {
            // 기사가 점프하는 애니메이션 호출
            animator.SetBool("IsJump", true);
            // 코루틴을 활용해서 점프 애니메이션이 끝나고 JumpEnd()를 호출
            StartCoroutine(DelayJumpEnd(0.1f));
            // 점프하는 동안은 가시와 충돌하지 않음

            isjump = false;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {

        if (isDead)
            return;

        GetDamage();

        if (resourceController.CurrentHealth <= 0f)
        {
            isDead = true;
            deathCooldown = 1f;
            miniGameManager.GameOver();
        }
        
    }

    
    private void GetDamage()
    {
        animator.SetBool("IsDamage", true);
        resourceController.ChangeHealth(-1f);
        // 코루틴을 활용해서 DamageEnd()를 호출
        StartCoroutine(DelayDamageEnd(0.1f));
    }


    // 원래 계획은 애니메이션 이벤트로 호출
    public void JumpEnd()
    {
        animator.SetBool("IsJump", false);
    }
    public void DamageEnd()
    {
        animator.SetBool("IsDamage", false);
    }

    // 위 코드를 코루틴을 활용해서 호출
    private IEnumerator DelayJumpEnd(float delay)
    {
        yield return new WaitForSeconds(delay);
        JumpEnd();
    }

    private IEnumerator DelayDamageEnd(float delay)
    {
        yield return new WaitForSeconds(delay);
        DamageEnd();
    }

}
