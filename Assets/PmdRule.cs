using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using Microsoft.MixedReality.Toolkit.Input;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class PmdRule : MonoBehaviour, IMixedRealityTouchHandler
{

    private string rule;
    // Start is called before the first frame update
    void Start()
    {
        rule = GetComponent<TextMeshProUGUI>().text.ToLower();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void IsURLExist(string url)
    {
        try
        {
            WebRequest req = WebRequest.Create(url);

            WebResponse res = req.GetResponse();
            
            Debug.Log("Url Exists");
        }
        catch (WebException ex)
        {
            Debug.Log(ex.Message);
            if (ex.Message.Contains("remote name could not be resolved"))
            {
                Debug.Log("Url is Invalid");
            }
        }
    }
    
    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    string url_index_content = webRequest.downloadHandler.text;
                    string url_rule = "";

                    string[] lines = url_index_content.Split('\n');
                    foreach (var line in lines)
                    {
                        if (line.Contains(rule))
                        {
                            url_rule = line.Split(new string[] {"href=\""}, System.StringSplitOptions.None)[1];
                            url_rule = url_rule.Split('\"')[0];
                            Debug.Log(url_rule);
                            break;
                        }
                        
                    }
                    Launch("https://pmd.sourceforge.io/pmd-6.54.0/" + url_rule);
                    break;
            }
        }
    }
    public static void Launch(string url, bool useHoloBrowser = false)
    {
#if WINDOWS_UWP
        UnityEngine.WSA.Application.InvokeOnUIThread(async () =>
        {
            try
            {
                var uri = new Uri(url);
                if (useHoloBrowser)
                {
                    var holoBrowserUri = new Uri($"holo-browser:{url}");
                    var option = new LauncherOptions()
                    {
                        FallbackUri = uri
                    };
                    await Launcher.LaunchUriAsync(holoBrowserUri, option);
                }
                else
                {
                    await Launcher.LaunchUriAsync(uri);
                }
            }
            catch (Exception e)
            {
                Debug.LogWarning(e);
            }
        }, false);
#else
        Application.OpenURL(url);
#endif
    }

    public void OnTouchStarted(HandTrackingInputEventData eventData)
    {
        StartCoroutine(GetRequest("https://pmd.sourceforge.io/pmd-6.54.0/pmd_rules_java.html" ));
    }

    public void OnTouchCompleted(HandTrackingInputEventData eventData)
    {
    }

    public void OnTouchUpdated(HandTrackingInputEventData eventData)
    {
    }
}
