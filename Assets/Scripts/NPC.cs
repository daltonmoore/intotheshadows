using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    DialogueTrigger dialogueTrigger;
    DialogueManager dialogueManager;

    [SerializeField] bool canInteract;
    //bool firstInteraction;

    // Start is called before the first frame update
    void Start()
    {
        dialogueTrigger = GetComponent<DialogueTrigger>();
        //canInteract = false;

        dialogueManager = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();
    }

    void Update()
    {
        if (canInteract)
        {
            if (Input.GetKeyUp(KeyCode.E) && !dialogueManager.talk)
            {
                Debug.Log("Interaction with NPC");
                dialogueTrigger.TriggerDialogue();
                //dialogueManager.firstInteraction = true;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //colliding object is player
        if (collision.CompareTag("Player"))
        {
            Debug.Log("in range of NPC");

            canInteract = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        //colliding object is player
        if (collision.CompareTag("Player"))
        {
            Debug.Log("out of range of NPC");

            canInteract = false;
        }
    }
}
