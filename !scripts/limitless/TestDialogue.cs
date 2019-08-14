using UnityEngine;
using System.Collections;

public class TestDialogue : MonoBehaviour{
    public AudioClip diagloueClip;

    void Update(){
        if (Input.GetKeydown(KeyCode.Space)){
            DialogueManager.Instance.BeginDialogue(diagloueClip);
        }
    }
}