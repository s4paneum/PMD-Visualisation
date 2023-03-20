using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.Input;
using TMPro;
using UnityEngine;

public class Row : MonoBehaviour
{

    public TextMeshProUGUI textLine;
    public TextMeshProUGUI textPattern;
    public TextMeshProUGUI textDescription;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetRow(string line, string pattern, string description, CodeReview codeReview)
    {
        textLine.text = line;
        textLine.GetComponent<PmdLine>().codeReview = codeReview;
        textLine.GetComponent<PmdLine>().line = line;
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