using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Build.Reporting;
using UnityEngine;

public static class LoadStage
{
    private static string STAGE_PATH;
    private static string FILE_EXTENSION = ".csv";
    public static List<int[]> Load(in string fileName)
    {
#if UNITY_EDITOR
        STAGE_PATH = "Assets/Stage/";
#else
        STAGE_PATH = "Stage/";
#endif
        List<int[]> stage = new List<int[]>();
        string fullPath = STAGE_PATH + fileName + FILE_EXTENSION;
        using (System.IO.StreamReader reader = new System.IO.StreamReader(fullPath))
        {
            string allString = reader.ReadToEnd().TrimEnd();
            string[] lines = allString.Split("\r\n");
            lines.ToList().ForEach(line => stage.Add(line.Split(",").ToList().ConvertAll(int.Parse).ToArray()));
        }
        return stage;
    }
}
