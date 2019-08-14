using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class audio_subtitle_tutorial_ : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Get everything from the text file
    TextAsset temp = Resources.LoadAll("Dialogues/" + dialogueAudio.name) as TextAsset;

    fileLines = temp.text.Split('/n');

    // Split subtitle and trigger related lines into different lists
    foreach(string lines in fileLines)
    {
        if (line.Contains("<trigger/>"))
        {
            triggerLines.Add(line);
        }
        else
        {
            subtitleLines.Add(Line);
        }
    }

    //Split out our subtitle elements
    for(int count = 0; count < subtitleLines.Count; count++)
    {
        string[] splitTemp = subtitleLines[count].Split('|');
        subtitleTimingStrings.Add(splitTemp[0]);
        subtitleTiming.Add(float.Parse(CleanTimeString(subtitleTimingStrings[count])));
        subtitleText.Add(splitTemp[1]);
    }

    //Split out our trigger elements
    for (int count = 0; count < triggerLines.Count; count++)
    {
        string[] splitTemp1 = triggerLines[count].Split('|');
        triggerTimingStrings.Add(splitTemp[0]);
        triggerTiming.Add(float.Parse(CleanTimeString(triggerTimingStrings[count])));

        triggers.Add(splitTemp1[1]);
        string[] splitTemp2 = triggers[count].Split('-');
        splitTemp2[0] = splitTemp2[0].Replace("<trigger/>");
        triggerObjectNames.Add(splitTemp2[0]);
        triggerObjectNames.Add(splitTemp2[1]);
    }
}
























