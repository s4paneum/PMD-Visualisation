using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class CodeReview : MonoBehaviour
{
    
    public TextMeshProUGUI textNumbers;
    public TextMeshProUGUI textCode;
    public Scrollbar verticalScrollbar;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }


    public void setCode(string path_with_line)
    {
        textNumbers.text = "";
        textCode.text = "";
        
        string[] split = path_with_line.Split(new string[] {":"}, System.StringSplitOptions.None);
        string path = split[0] + ":" + split[1];
        int line_number = int.Parse(split[2]);
        int line_max = 0;
        
        StreamReader sr = new StreamReader(path);
        for (int i = 0; !sr.EndOfStream; i++) {
            string line = sr.ReadLine ();
            line_max++;

            textNumbers.text += (i+1) + "\n";
            if (line_number == i + 1)
            {
                textCode.text += "<mark>" + line + "</mark>" + "\n";
            }else
                textCode.text += line + "\n";
        }
        
        
        // set vertical scroll position to marked spot
        float scrollValue = 1 - (line_number * textCode.fontSize)/(line_max * textCode.fontSize);
        Debug.Log(scrollValue);
        verticalScrollbar.value = scrollValue;
    }
}
