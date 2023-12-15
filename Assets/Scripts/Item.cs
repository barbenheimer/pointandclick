using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Item", menuName = "Scriptable object/Item")]
public class Item : ScriptableObject
{
    [Header("Only gameplay")]

    public ItemType type;
    [Header("Only UI")]
    [Header("Both")]
    public int ID;
    public Sprite image;
}

public enum ItemType
{
    Keys,
    Puzzles,
    Furniture
}