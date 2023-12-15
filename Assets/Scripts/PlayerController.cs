using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D rb;
    //Touch touch;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    //void FixedUpdate()
    //{
    //    if(Input.touchCount > 0)
    //    {
    //        touch = Input.GetTouch(0);
    //        transform.position = Vector2.MoveTowards(transform.position, Camera.main.ScreenToWorldPoint(touch.position), moveSpeed * Time.deltaTime);
    //    }
    //}
}
