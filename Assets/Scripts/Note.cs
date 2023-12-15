using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class Note : MonoBehaviour
{
    public Canvas textCanvas;
    public Text noteText;
    void Start()
    {
        textCanvas.enabled = false;
    }
    void OnMouseDown()
    {
        if(textCanvas != null)
        {
            textCanvas.enabled = true;
        }
    }
    void OnMouseUp()
    {
        if (textCanvas != null)
        {
            textCanvas.enabled = false;
        }
    }
}
