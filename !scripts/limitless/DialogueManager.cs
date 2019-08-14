using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private AudioClip dialogueAudio;

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

    //GUI
    private GUIStyle subtitleStyle = new GUIStyle();

    //Singleton Property
    public static DialogueManager Instance { get; private set; }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }

        Instance = this;

        gameObject.AddComponent<AudioSource>();

    }

    public void BeginDialogue(AudioClip passedClip)
    {

        dialogueAudio = passedClip;

        //Resets all lists
        subtitleLines = new List<string>();
        subtitleTimingStrings = new List<string>();
        subtitleTimings = new List<float>();
        subtitleText = new List<string>();

        triggerLines = new List<string>();
        triggerTimingStrings = new List<string>();
        triggerTimings = new List<float>();
        triggers = new List<string>();
        triggerObjectNames = new List<string>();
        triggerMethodNames = new List<string>();

        nextSubtitle = 0;
        nextTrigger = 0;

        // Get everything from the text file
        TextAsset temp = Resources.LoadAll("Dialogues/" + dialogueAudio.name) as TextAsset;

        fileLines = temp.text.Split("/n");

        // Split subtitle and trigger related lines into different lists
        foreach (string lines in fileLines)
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
        for (int count = 0; count < subtitleLines.Count; count++)
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
        
        // Set the initial subtitle text
        if(subtitleText[0] != null)
        {
            // Just sets the very first displayed text to be the very first subtitle in the text file
            displaySubtitle = subtitleText[0];
        }

        //Set and play the audio clip
        audio.clip = diaglogueAudio;
        audio.Play();
    }

    //Remove all characters that are not part of the timing float
    private string CleanTimeString(string timeString){
        Regex digitsOnly = new Regex(@"[^\d +(\.\d+)*$]");
        return digitsOnly.Replace(timeString, "");
    }

    void OnGUI()
    {
        //Make sure we are using a proper dialogueAudio file
        if(dialogueAudio != null && audio.clip.name == dialogueAudio.name)
        {
            // Check for <break/> or negative nextSubtitle
            if(nextSubtitle > 0 && !subtitleText[nextSubtitle - 1].Contains("<break/>"))
            {
                //Create GUI
                GUI.depth = -1001;
                // Establishes what the GUI would look like
                subtitleStyle.fixedWidth = ScreenWidth/1.5f;
                subtitleStyle.wordWrap = true;
                subtitleStyle.alignment = TextAnchor.MiddleCenter;
                subtitleStyle.normal.textColor = Color.white;
                subtitleStyle.fontSize = Mathf.FloorToInt(Screen.height = 0.0225f);

                Vector2 size = subtitleStyle.CalcSize(new GUIContent()); 
                GUI.contentColor = Color.black;
            }
        }
    }
}
