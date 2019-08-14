using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class audio_subtitle_tutorial_ : MonoBehaviour
{
    private string[] fileLines;
    
    //Subtitle variables
    private List<string> subtitleLines = new List<string>();
    
    private List<string> subtitleTimingStrings = new List<string>();
    private List<float> subtitleTimings = new List<float>();

    public List<string> subtitleText = new List<string>();

    private int nextSubtitle = 0;

    private string displaySubtitle;

    //Trigger variables
    private List<string> triggerLines = new List<string>();
    
    private List<string> triggerTimingStrings = new List<string>();
    public List<float> triggerTimings = new List<float>();

    private List<string> triggers = new List<string>();
    public List<string> triggerObjectNames = new List<string>();
    public List<string> triggerMethodNames = new List<string>();

    private int nextTrigger = 0;

    
    //Singleton Property
    public static DialogueManager Instance{get; private set;}

    void Awake()
    {
        if(Instance != null && Instance != this){
            Destroy(gameObject);
        }

        Instance = this;

        gameObject.AddComponent<AudioSource>();
    
    }

    public void BeginDialogue(AudioClip passedClip){
        //Set and play the audio clip
        audio.clip = passedClip;

        audio.Play();
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
        subtitleTimings.Add(float.Parse(CleanTimeString(subtitleTimingsStrings[count])));
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
























