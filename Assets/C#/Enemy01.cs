using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy01 : MonoBehaviour
{
    [SerializeField, Header("移動速度")]
    private float movespeed;
    private Rigidbody2D rigid;

    [SerializeField, Header("攻撃力")]
    private int attack;

    [Header("接触判定")]
    public Trigger01 trigger01;
   
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

  
    void Update()
    {
        Move();
    }

    private void Move() 
    {
        if(!trigger01.bturn)
        {
            rigid.velocity = new Vector2(Vector2.left.x * movespeed, rigid.velocity.y); 
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            rigid.velocity = new Vector2(Vector2.right.x * movespeed, rigid.velocity.y);
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    public void PlayerDamage(Player player) 
    {
        player.Damage(attack);
        Destroy(gameObject);
    }
}
