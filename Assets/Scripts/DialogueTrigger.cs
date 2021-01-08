using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    
    public Dialogue dialogue;

    public AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void TriggerDialogue()
    {
        audioSource.Play();
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
