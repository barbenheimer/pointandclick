using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    public Slot[] inventorySlots;
    public GameObject inventoryItemPrefab;
    public List<Item> listItems = new List<Item>();

    private void Awake()
    {
        Instance = this;
    }

    public bool AddItem(Item item) //add item duh
    {
        //find empty slot
        for(int i = 0; i < inventorySlots.Length; i++)
        {
            Slot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            listItems.Add(item);
            if(itemInSlot == null)
            {
                SpawnNewItem(item, slot);
                return true;
            }
        }
        return false;
    }

    //Check if contains item
    public bool GetItem(int ID)
    {
        for(int a = 0; a < listItems.Count; a++)
        {
            if (listItems[a].ID == ID)
            {
                return true;
            }
        }
        return false;
    }

    //make item show up
    void SpawnNewItem(Item item, Slot slot)
    {
        GameObject newItemGo = Instantiate(inventoryItemPrefab, slot.transform);
        InventoryItem inventoryItem = newItemGo.GetComponent<InventoryItem>();
        inventoryItem.InitialiseItem(item);
    }
}
