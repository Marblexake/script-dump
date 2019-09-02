using System;
using System.Collections.Generic;
using UnityEngine;

public class ScriptManager : MonoBehaviour
{
    private Dictionary<string,string> linesDict = new Dictionary<string,string>(StringComparer.OrdinalIgnoreCase);

    public string resourceFile = "script2";

    public string GetText(string textKey)
    {
        string tmp = "";
        if(linesDict.TryGetValue(textKey, out tmp))
        {
            return tmp;
        }
        return string.Empty;
    }

    private void Awake()
    {
        var textAsset = Resources.Load<TextAsset>(resourceFile);
        var voText = JsonUtility.FromJson<VoiceOverText>(textAsset.text);

        foreach (var t in voText.lines)
        {
            linesDict[t.key] = t.line;
        }
    }
}