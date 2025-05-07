using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JKPlayer : MonoBehaviour 
    // Jumping Knight Player
    // ��簡 �����ϴ� �ִϸ��̼��� ȣ���ϰ�, ���ÿ� �浹���� �� ü���� ����, ü���� 0�� �Ǿ��� �� ���� ���� ó��
    // ���� ���� �Ŀ��� ����� ��ư�� ������ �����
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
        resourceController = GetComponent<ResourceController>(); // ���ø� ����� �� ü�� ���Ҹ� ���ؼ�

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
                    // ���� �����
                    miniGameManager.RestartGame();
                    // DontDestroyOnLoad �ڵ尡 ���� ������ MiniGameManager�� �ν��Ͻ��� �ı��ϰ� �ٽ� ����
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
            // ��簡 �����ϴ� �ִϸ��̼� ȣ��
            animator.SetBool("IsJump", true);
            // �ڷ�ƾ�� Ȱ���ؼ� ���� �ִϸ��̼��� ������ JumpEnd()�� ȣ��
            StartCoroutine(DelayJumpEnd(0.1f));
            // �����ϴ� ������ ���ÿ� �浹���� ����

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
        // �ڷ�ƾ�� Ȱ���ؼ� DamageEnd()�� ȣ��
        StartCoroutine(DelayDamageEnd(0.1f));
    }


    // ���� ��ȹ�� �ִϸ��̼� �̺�Ʈ�� ȣ��
    public void JumpEnd()
    {
        animator.SetBool("IsJump", false);
    }
    public void DamageEnd()
    {
        animator.SetBool("IsDamage", false);
    }

    // �� �ڵ带 �ڷ�ƾ�� Ȱ���ؼ� ȣ��
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
