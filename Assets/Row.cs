using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Row : MonoBehaviour
{

    public TextMeshProUGUI textLine;
    public TextMeshProUGUI textPattern;
    public TextMeshPro textDescription;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setRow(string line, string pattern, string description)
    {
        textLine.text = line;
        textPattern.text = pattern;
        textDescription.text = description;
    }

    public void SetFontSize(float new_size)
    {
        textLine.fontSize = new_size;
        textPattern.fontSize = new_size;
        textDescription.fontSize = new_size;
    }
}
