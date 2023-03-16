using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PmdFetcher : MonoBehaviour
{

    public String pmd_path = "";
    public String ruleset_path = "";

    public String code_path = "";
    public GameObject panel;
    public GameObject headerPrefab;
    public GameObject rowPrefab;
    public ScrollView scrollView;
    public CodeReview codeReview;
    
    // Start is called before the first frame update
    void Start()
    {
        ExecutePMD(code_path);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private GameObject createRow(String line)
    {
        string correct_spaces = Regex.Replace(line, @"\s+", " ");
        string[] result = correct_spaces.Split(new string[] {": "}, System.StringSplitOptions.None);

        GameObject row = Instantiate(headerPrefab, new Vector3(0,0,0), Quaternion.identity);
        row.GetComponent<Header>().setHeader(result[0], result[1], result[2], codeReview);

        return row;
    }
    private void ExecutePMD(string _code_path)
    {
        try
        {
            // create Header
            GameObject header = Instantiate(headerPrefab, new Vector3(0,0,0), Quaternion.identity);
            header.GetComponent<Header>().setHeader("Line", "Rule", "Description", null);
            header.GetComponent<Header>().SetFontSize(72);
            header.transform.SetParent(panel.transform, false);
            header.transform.localScale = Vector3.one;
            
            // run pmd
            ProcessStartInfo startInfo = new ProcessStartInfo()
            {
                FileName = pmd_path,
                UseShellExecute = false,
                RedirectStandardError = true,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                CreateNoWindow = true,
                Arguments = " -d " + _code_path + " -R " + ruleset_path
            };
            Process myProcess = new Process
            {
                StartInfo = startInfo
            };
            
            
            myProcess.Start();
            string line = myProcess.StandardOutput.ReadLine();
            
            // create row for each output line from pmd 
            while (line != null)
            {
                GameObject row = createRow(line);
                row.transform.SetParent(panel.transform, false);
                row.transform.localScale = Vector3.one;

                line = myProcess.StandardOutput.ReadLine();
            }
            
            myProcess.WaitForExit();

        }
        catch (Exception e)
        {
            print(e);
        }
    }
}