using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger02 : MonoBehaviour
{
    public bool bturn = false;

    private void OnTriggerExit2D(Collider2D collision)
    {
        bturn = !bturn;
    }
}
