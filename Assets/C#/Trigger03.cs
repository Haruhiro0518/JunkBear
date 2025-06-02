using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger03 : MonoBehaviour
{
    public bool bfall = false;

    private AudioSource se;

    void Start()
    {
        se = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player") 
        {
            bfall = true;
            se.Play();
        }
    }
}
