using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGameObject : MonoBehaviour
{
    private Item item;
    public SpriteRenderer render;
    
    public void InitItem(Item itm)
    {
        item = itm;
        render.sprite = item.image;
    }
}
