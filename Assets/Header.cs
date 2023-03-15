using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.Input;
using TMPro;
using UnityEngine;

public class Header : MonoBehaviour, IMixedRealityTouchHandler
{

    public TextMeshPro textLine;
    public TextMeshPro textPattern;
    public TextMeshPro textDescription;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setHeader(string line, string pattern, string description)
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

    public void OnTouchStarted(HandTrackingInputEventData eventData)
    {
        try
        {
            UnityEngine.Debug.Log("touched");
        }
        catch (System.NotImplementedException)
        {
            
        }
    }

    public void OnTouchCompleted(HandTrackingInputEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnTouchUpdated(HandTrackingInputEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}