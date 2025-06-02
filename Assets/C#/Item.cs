using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{   
    private ItemCounter counter;
    
    // Start is called before the first frame update
    void Start()
    {
        counter = FindObjectOfType<ItemCounter>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player") 
        {
            counter.score++;
            collision.GetComponent<Player>().GetItem();
            gameObject.SetActive(false);
        }
    }
}
