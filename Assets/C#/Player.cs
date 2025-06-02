using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public bool bclear = false;
    
    public bool bdead = false;
    
    [SerializeField,Header("移動速度")]
    private float moveSpeed;

    private Vector2 inputDirection;

    private Rigidbody2D rigid;

    [SerializeField, Header("ジャンプ速度")]
    private float jumpSpeed;

    [SerializeField, Header("体力")]
    private int hp;

    [SerializeField, Header("アニメーター")]
    Animator animator;

    private bool bjump = false;

    public bool running = false;

    public bool jumping = false;

    [SerializeField, Header("Source(jump)")]
    private AudioSource audioSource01;

    [SerializeField, Header("Source(damage)")]
    private AudioSource audioSource02;

    [SerializeField, Header("Source(item)")]
    private AudioSource audioSource03;

    [SerializeField, Header("Source(stamp)")]
    private AudioSource audioSource04;

    [SerializeField, Header("SE(jump)")]
    private AudioClip se01;

    [SerializeField, Header("SE(damage)")]
    private AudioClip se02;

    [SerializeField, Header("SE(item)")]
    private AudioClip se03;

    [SerializeField, Header("SE(stamp)")]
    private AudioClip se04;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Move();
        UpdatePlayerAnimator();
    }

    public int GetHP() 
    {
        return hp;
    }

    public void GetItem()
    {
        audioSource03.PlayOneShot(se03);
    }

    public void Damage(int damage) 
    {
        hp = Mathf.Max(hp - damage, 0);

        if(hp <= 0)
        {
            Dead();
        }
    }

    private void Move()
    {
        if(inputDirection.x > 0)
        {
            transform.localScale = new Vector2(1, 1);
        }
        else if(inputDirection.x < 0)
        {
            transform.localScale = new Vector2(-1, 1);
        }
        
        // 入力方向に横方向限定で移動速度分の力を加算
        rigid.velocity = new Vector2(inputDirection.x * moveSpeed, rigid.velocity.y);

        if(inputDirection.x == 0)
        {
            running = false;
        }
        else
        {
            running = true;
        }

        if(!bjump)
        {
            jumping = false;
        }
        else
        {
            jumping = true;
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        // 移動方向の入力情報
        inputDirection = context.ReadValue<Vector2>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Floor") 
        {
            bjump = false;
        }

        if(collision.gameObject.tag == "Enemy01") 
        {
            HitEnemy01(collision.gameObject);
        }

        if(collision.gameObject.tag == "Enemy02") 
        {
            HitEnemy02(collision.gameObject);
        }

        if(collision.gameObject.tag == "Enemy03") 
        {
            HitEnemy03(collision.gameObject);
        }

        if(collision.gameObject.tag == "Enemy04") 
        {
            HitEnemy04(collision.gameObject);
        }

        if(collision.gameObject.tag == "Enemy05") 
        {
            HitEnemy05(collision.gameObject);
        }

        if(collision.gameObject.tag == "Goal") 
        {
            audioSource03.PlayOneShot(se03);
            Clear();
        }

        if(collision.gameObject.tag == "Trap") 
        {
            Dead();
        }

        if(collision.gameObject.tag == "DeadLine") 
        {
            Dead();
        }
    }

    public void OnJump(InputAction.CallbackContext context) 
    {
        if(!context.performed || bjump) 
        {
            return;
        } 

        rigid.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
        bjump = true;
        audioSource01.PlayOneShot(se01);
    }

    private void HitEnemy01(GameObject enemy01) 
    {
        float halfScaleY = transform.localScale.y / 2.0f;
        float enemy01HalfScaleY = transform.localScale.y / 2.0f;
        if(transform.position.y - (halfScaleY - 0.1f) >= enemy01.transform.position.y + (enemy01HalfScaleY - 0.1f)) 
        {
            Destroy(enemy01);
            rigid.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
            audioSource04.PlayOneShot(se04);
        }
        else 
        {
            enemy01.GetComponent<Enemy01>().PlayerDamage(this);
            audioSource02.PlayOneShot(se02);
        }
    }

    private void HitEnemy02(GameObject enemy02) 
    {
        float halfScaleY = transform.localScale.y / 2.0f;
        float enemy02HalfScaleY = transform.localScale.y / 2.0f;
        if(transform.position.y - (halfScaleY - 0.1f) >= enemy02.transform.position.y + (enemy02HalfScaleY - 0.1f)) 
        {
            Destroy(enemy02);
            rigid.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
            audioSource04.PlayOneShot(se04);
        }
        else 
        {
            enemy02.GetComponent<Enemy02>().PlayerDamage(this);
            audioSource02.PlayOneShot(se02);
        }
    }

    private void HitEnemy03(GameObject enemy03) 
    {
        float halfScaleY = transform.localScale.y / 2.0f;
        float enemy03HalfScaleY = transform.localScale.y / 2.0f;
        if(transform.position.y - (halfScaleY - 0.1f) >= enemy03.transform.position.y + (enemy03HalfScaleY - 0.1f)) 
        {
            rigid.AddForce(Vector2.up * jumpSpeed * 0.8f, ForceMode2D.Impulse);
        }
        enemy03.GetComponent<Enemy03>().PlayerDamage(this);
        audioSource02.PlayOneShot(se02);
    }

    private void HitEnemy04(GameObject enemy04) 
    {
        float halfScaleY = transform.localScale.y / 2.0f;
        float enemy04HalfScaleY = transform.localScale.y / 2.0f;
        if(transform.position.y - (halfScaleY - 0.1f) >= enemy04.transform.position.y + (enemy04HalfScaleY - 0.1f)) 
        {
            rigid.AddForce(Vector2.up * jumpSpeed * 0.8f, ForceMode2D.Impulse);
        }
        enemy04.GetComponent<Enemy04>().PlayerDamage(this);
        audioSource02.PlayOneShot(se02);
    }

    private void HitEnemy05(GameObject enemy05) 
    {
        float halfScaleY = transform.localScale.y / 2.0f;
        float enemy05HalfScaleY = transform.localScale.y / 2.0f;
        if(transform.position.y - (halfScaleY - 0.1f) >= enemy05.transform.position.y + (enemy05HalfScaleY - 0.1f)) 
        {
            Destroy(enemy05);
            rigid.AddForce(Vector2.up * jumpSpeed * 1.2f, ForceMode2D.Impulse);
            audioSource04.PlayOneShot(se04);
        }
        else 
        {
            enemy05.GetComponent<Enemy05>().PlayerDamage(this);
            audioSource02.PlayOneShot(se02);
        }
    }

    public void Clear()
    {
        bclear = true;
    }

    public void Dead() 
    {
        Destroy(gameObject);
        bdead = true;
    }

    public void UpdatePlayerAnimator()
    {
        animator.SetBool("running", running);
        animator.SetBool("jumping", jumping);
    }
}
