using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public Text nameText;
    public Text dialogueText;
    public Dialogue dialogue;
    
    public AudioSource audioSource;

    public Animator animator;

    private Queue<string> sentences;
    
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();

        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyUp("e"))
        {
            DisplayNextSentence();
        }
    }


    public void StartDialogue (Dialogue dialogue)
    {
        Debug.Log("Starting conversation with " + dialogue.name);

        this.dialogue = dialogue;

        animator.SetBool("IsOpen", true);

        nameText.text = dialogue.name;

        sentences.Clear();

        #region Get Sentences
        if (dialogue.name == "Shadow Child")
        {
            switch (dialogue.interactions)
            {
                case 0:
                    dialogue.sentences = new[]
                    {
                        "Hello…",
                        "I can’t move, the light will find me…",
                        "I can’t move, the light will find me…"
                    };
                    break;
                case 1:
                    dialogue.sentences = new[]
                    {
                        "I can’t move, the light will find me…"
                    };
                    break;
            }
        }
        else if (dialogue.name == "Curvy Shadow")
        {
            switch (dialogue.interactions)
            {
                case 0:
                    dialogue.sentences = new[]
                    {
                        "Hello, Darling.",
                        "Need anything? How about you just stay right here and I’ll help you relax…"
                    };
                    break;
                case 1:
                    dialogue.sentences = new[]
                    {
                        "Sigh… everybody always leaves and gets caught by the light…"
                    };
                    break;
            }
        }
        else if (dialogue.name == "Shadow Parent")
        {
            switch (dialogue.interactions)
            {
                case 0:
                    dialogue.sentences = new[]
                    {
                        "If you see my two children could you bring them back home?",
                        "They wandered off and I’m afraid the light has found them…"
                    };
                    break;
                case 1:
                    dialogue.sentences = new[]
                    {
                        "Did you find my children?"
                    };
                    break;
            }
        }
        else if (dialogue.name == "Shadow Villager 1")
        {
            switch (dialogue.interactions)
            {
                case 0:
                    dialogue.sentences = new[]
                    {
                        "I try not to leave the village. The light never comes here.",
                        "You’re a brave shadow if you leave this place."
                    };
                    break;
            }
        }
        else if (dialogue.name == "Shadow Villager 2")
        {
            switch (dialogue.interactions)
            {
                case 0:
                    dialogue.sentences = new[]
                    {
                        "The Mother of Shadows told me she loves all of her little shadows.",
                        "Do you think she means it?"
                    };
                    break;
            }
        }
        #endregion

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();

    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopCoroutine(TypeSentence(sentence));
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            audioSource.Play();
            dialogueText.text += letter;
            yield return null;
            audioSource.Stop();
        }
    }

    void EndDialogue()
    {
        Debug.Log("End of Conversation");

        dialogue.interactions++;
        animator.SetBool("IsOpen", false);

        SetInteractable();
    }

    void SetInteractable()
    {
        if (dialogue.interactions > 3 && dialogue.name == "Light Worshiper")
        {
            dialogue.interactable = false;
        }
        else if (dialogue.interactions > 1 && dialogue.name == "Shadow Villager 1")
        {
            dialogue.interactable = false;
        }
        else if (dialogue.interactions > 1 && dialogue.name == "Shadow Villager 2")
        {
            dialogue.interactable = false;
        }
    }

}
