using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.Input;
using UnityEngine;

public class PmdLine : MonoBehaviour, IMixedRealityTouchHandler
{
    public CodeReview codeReview;
    public string line; 
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTouchStarted(HandTrackingInputEventData eventData)
    {
        if (codeReview != null)
        {
            codeReview.setCode(line);
        }
    }

    public void OnTouchCompleted(HandTrackingInputEventData eventData)
    {
        
    }

    public void OnTouchUpdated(HandTrackingInputEventData eventData)
    {
    }
}
