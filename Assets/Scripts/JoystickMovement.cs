using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject joystickBG;
    public GameObject joystick;

    private Vector2 joystickVec;
    private Vector2 joystickTouchPos;
    private Vector2 joystickOgPos;

    private Rect joystickLocation;

    private float joystickRadius;
    public float joystickHitBox = 2.0f;
    public float joystickOffset = 4.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //Save og pos to return back to
        joystickOgPos = joystickBG.transform.position;

        //Offset is how far the stick will travel to the edge
        joystickRadius = joystickBG.GetComponent<RectTransform>().rect.size.y / joystickOffset;

        //Creates the box where the joystick wo;; react to input
        joystickLocation = new Rect(joystickOgPos.x - joystickRadius * joystickOffset, joystickOgPos.y - joystickRadius * joystickOffset, joystickBG.GetComponent<RectTransform>().rect.size.x * joystickHitBox, joystickBG.GetComponent<RectTransform>().rect.size.y * joystickHitBox);
    }

    // Update is called once per frame
    void Update()
    {
        //Get all touch
        foreach(Touch touch in Input.touches)
        {
            //if a touch is dragged across the screen
            if(touch.phase == TouchPhase.Moved)
            {
                //Set our current touch position
                joystickTouchPos = touch.position;
                //If our current touch pos is inside the rectangle location
                if (joystickLocation.Contains(joystickTouchPos))
                {
                    //Normalize the value to get a value between -1 and 1
                    joystickVec = (touch.position - joystickOgPos).normalized;
                    //Get the distance between our current touch and the joystick og pos
                    float joystickDist = Vector2.Distance(joystickOgPos, touch.position);
                    //If we are inside joystick area
                    if (joystickDist < joystickRadius)
                    {
                        joystick.transform.position = joystickOgPos + joystickVec * joystickDist;
                    }
                    else
                    {
                        //Max out how far the joystick can go
                        joystick.transform.position = joystickOgPos + joystickVec * joystickRadius;
                    }
                }
            }
            //If player takes touch input off device
            if(touch.phase == TouchPhase.Ended)
            {
                //Change speed to 0
                joystickVec = Vector2.zero;
                //return back to og pos
                joystick.transform.position = joystickOgPos;
                joystickBG.transform.position = joystickOgPos;
            }
        }
    }
    void FixedUpdate()
    {
        //Speed is the joystick velocity * player speed
        rb.velocity = new Vector2(joystickVec.x * GetComponent<PlayerController>().moveSpeed, joystickVec.y * GetComponent<PlayerController>().moveSpeed);
    }
}
