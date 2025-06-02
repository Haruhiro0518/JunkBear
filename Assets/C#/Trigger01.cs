using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger01 : MonoBehaviour
{
    public bool bturn = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Floor") 
        {
            bturn = !bturn;
        }
    }
}
