using System;
using System.Collections.Generic;
using UnityEngine;

public class ScriptManager : Monobehaviour
{
    private Dictionary<string,string> lines = new Dictionary<string,string>(StringComparer.OrdinalIgnoreCase);

    public string resourceFile = "script";

    public string GetText(string textKey)
    {
        string tmp = "";
        if(lines.TryGetValue(textKey, out tmp))
        {
            return tmp;
        }
        return string.Empty;
    }

    private void Awake()
    {
        var textAsset = Resources.Load<TextAsset>(resourceFile);
        var voText = JSONUtility.FromJSON<VoiceOverText>(textAsset.text);

        foreach (var t in voText.lines)
        {
            lines[t.key] = t.line;
            
        }
    }
}