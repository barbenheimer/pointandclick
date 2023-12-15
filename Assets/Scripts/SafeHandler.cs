using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SafeState
{
    Open, Close, Claimed
}

public class SafeHandler : MonoBehaviour
{
    public SafeState state;
    public GameObject codeCanvas;
    public Item[] itemToPickup;
    public GameObject objectToDestroy;

    public void OnMouseDown()

    {
        if (state == SafeState.Claimed)
        {
            return;
        }
        if (state == SafeState.Open)
        {
            PickupItem(itemToPickup[0].ID);
        }
        else
        {
            codeCanvas.SetActive(true);
        }
    }

    public void OnComplete()
    {
        state = SafeState.Open;
        //change sprite later
        GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
    }


    public void PickupItem(int id)
    {
        bool result = InventoryManager.Instance.AddItem(itemToPickup[id]);
        if (result == true)
        {
            Debug.Log("Item picked up");
            state = SafeState.Claimed;
            Destroy(objectToDestroy);
        }
        else
        {
            Debug.Log("Inventory full");
        }
    }
}
