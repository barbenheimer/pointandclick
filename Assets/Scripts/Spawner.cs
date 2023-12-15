using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public Vector2 spawnPos;
    public Item[] itemArr;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < itemArr.Length; i++)
        {
            GameObject go = Instantiate(objectToSpawn, spawnPos, Quaternion.identity);
            go.GetComponent<ItemGameObject>().InitItem(itemArr[i]);
        }
    }
}
