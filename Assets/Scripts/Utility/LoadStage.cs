using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
#if UNITY_EDITOR
using UnityEditor.Build.Reporting;
#endif
using UnityEngine;
using UnityEngine.Networking;


public static class LoadStage
{
    private static string STAGE_PATH;
    private static string FILE_EXTENSION = ".csv";

    private static List<int[]> STAGE = new List<int[]>();

    public static string A = "";

    public static List<int[]> Load(in string fileName)
    {
        STAGE_PATH = $"{Application.streamingAssetsPath}/";
        string fullPath = STAGE_PATH + fileName + FILE_EXTENSION;
#if UNITY_WEBGL || PLATFORM_WEBGL
        //if (STAGE.Count == 0)
        //    WebRequest(fullPath);
        if (STAGE.Count == 0)
        {
            STAGE.Add(new int[] { 1, 4, 3, 4, 1 });
            STAGE.Add(new int[] { 1, 2, 4, 2, 1 });
            STAGE.Add(new int[] { 3, 3, 5, 3, 3 });
            STAGE.Add(new int[] { 1, 2, 4, 2, 1 });
            STAGE.Add(new int[] { 1, 4, 3, 4, 1 });
        }
#elif UNITY_EDITOR
        if (STAGE.Count == 0)
        {
            using (System.IO.StreamReader reader = new System.IO.StreamReader(fullPath))
            {
                string allString = reader.ReadToEnd().TrimEnd();
                string[] lines = allString.Split("\r\n");
                lines.ToList().ForEach(line => STAGE.Add(line.Split(",").ToList().ConvertAll(int.Parse).ToArray()));
            }
        }
#endif
        return STAGE;
    }


    private static async void WebRequest(string fullPath)
    {
        UnityWebRequest webRequest = UnityWebRequest.Get(fullPath);
        await webRequest.SendWebRequest();
        string allString = webRequest.downloadHandler.text.TrimEnd();
        string[] lines = allString.Split("\r\n");
        lines.ToList().ForEach(line => STAGE.Add(line.Split(",").ToList().ConvertAll(int.Parse).ToArray()));
    }
}
