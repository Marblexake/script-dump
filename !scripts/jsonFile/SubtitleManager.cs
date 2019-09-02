using System.Collections.Generic;
using System;
using UnityEngine;

public class SubtitleManager : MonoBehaviour
{
    /// <summary>
    /// //
    /// </summary>

    private List<string> subtitleLines = new List<string>();

    private List<string> subtitleTimingStrings = new List<string>();
    public List<float> subtitleTimings = new List<float>();

    public List<string> subtitleText = new List<string>();

    private int nextSubtitle = 0;

    private string displaySubtitle;

    /// <summary>
    /// /////////////////////////////
    /// </summary>

    public string resourceFile = "script";

    private void Awake()
    {
        var subtitleFile = Resources.Load<TextAsset>(resourceFile);
        var subtitleJson = JsonUtility.FromJson<SubtitleArray>(subtitleFile.text);

        Debug.Log(subtitleJson);

        foreach(var t in subtitleJson.subtitle)
        {
            subtitleText.Add(t.subtitle);
            subtitleTimings.Add(float.Parse(t.time));
        }

    }
}
