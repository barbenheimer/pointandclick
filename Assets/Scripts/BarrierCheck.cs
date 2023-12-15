using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class BarrierCheck : MonoBehaviour
{
    public int ID;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("collision detected");
            if (InventoryManager.Instance.GetItem(ID))
                Destroy(gameObject);
        }
    }
}
