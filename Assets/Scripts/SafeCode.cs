using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class SafeCode : MonoBehaviour
{
    public Text codeText;
    string codeTextValue = "";

    public SafeHandler safe;

    // Update is called once per frame
    void Update()
    {
        codeText.text = codeTextValue;
        if (codeTextValue == "1984")
        {
            safe.OnComplete();
        }
        if (codeTextValue.Length >= 4)
        {
            codeTextValue = "";
        }
    }

    public void AddDigits(string digits)
    {
        codeTextValue += digits;
    }
}
