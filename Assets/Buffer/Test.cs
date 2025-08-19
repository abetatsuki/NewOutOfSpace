using System;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        string stringsss = "a,b,c";
        string[]stromgaa = stringsss.Split(',');
        foreach (string s in stromgaa)
        {
           Debug.Log(s);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
