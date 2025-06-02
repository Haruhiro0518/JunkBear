using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy05 : MonoBehaviour
{
    [SerializeField, Header("攻撃力")]
    private int attack;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerDamage(Player player) 
    {
        player.Damage(attack);
    }
}
