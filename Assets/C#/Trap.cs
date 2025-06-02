using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    private Rigidbody2D rigid;
    
    [Header("接触判定")]
    public Trigger03 trigger03;
    
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.bodyType = RigidbodyType2D.Kinematic;
    }

    // Update is called once per frame
    void Update()
    {
        TriggerTrap();
    }

    private void TriggerTrap()
    {
        if(trigger03.bfall)
        {
            rigid.bodyType = RigidbodyType2D.Dynamic;
        }
    }
}
