using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public Text nameText;
    public Text dialogueText;
    public Dialogue dialogue;
    
    //public AudioSource audioSource;

    public Animator animator;

    public bool talk;

    

    private Queue<string> sentences;
    
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();

        //audioSource = GetComponent<AudioSource>();

        talk = false;

        
    }

    void Update()
    {
        
        if (Time.timeScale == 1f) //Stops player from continueing dialogue while game is paused
        {
            if (Input.GetKeyUp("e") && talk == true)
            {
                Debug.Log("called from update");

                DisplayNextSentence();
            }
        }
    }


    public void StartDialogue (Dialogue dialogue)
    {
        Debug.Log("Starting conversation with " + dialogue.name);

        talk = true;

        this.dialogue = dialogue;

        animator.SetBool("IsOpen", true);

        nameText.text = dialogue.name;

        sentences.Clear();

        //Dialogue interactions for each character
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
                        "<i><size=12>Do you think she means it?</size></i>"
                    };
                    break;
            }
        }
        else if (dialogue.name == "Mother of Shadows")
        {
            switch (dialogue.interactions)
            {
                case 0: //Start
                    dialogue.sentences = new[]
                    {
                        "Hello, young Shadow, I am the Mother of Shadows.",
                        "It’s not safe out here right now, and I’ve come to guide you to a safe place.",
                        "Follow the path, sweet shadow. (A & D)"
                    };
                    break;
                case 1: //Jump
                    dialogue.sentences = new[]
                    {
                        "Watch out, little Shadow, you’ll need to jump (Spacebar or W) over this obstacle."
                    };
                    break;
                case 2: //LightDMG
                    dialogue.sentences = new[]
                    {
                        "Little Shadow, you’ll need to stay away from the light.",
                        "The light will hurt you if it sees you.",
                        "Please be careful!"
                    };
                    break;
                case 3: //LightHeal
                    dialogue.sentences = new[]
                    {
                        "This is a shadow light, they can heal your wounds, young Shadow."
                    };
                    break;
                case 4: //Dash
                    dialogue.sentences = new[]
                    {
                        "Sweet Shadow, to overcome this gap, you’ll need to jump and dash (Shift) across.",
                    };
                    break;
                case 5: //Interact
                    dialogue.sentences = new[]
                    {
                        "Little Shadow, sometimes it is nice to interact (E) with your fellow shadows.",
                    };
                    break;
            }
        }
        else if (dialogue.name == "Light Worshiper")
        {
            switch (dialogue.interactions)
            {
                case 0:
                    dialogue.sentences = new[]
                    {
                        "May the Light consume us all!"
                    };
                    break;
                case 1:
                    dialogue.sentences = new[]
                    {
                        "Let the light consume you, shadow.",
                        "So you can be sent into the light’s rays of grace!"

                    };
                    break;
                case 2:
                    dialogue.sentences = new[]
                    {
                        "Me?",
                        "I must stay here to help the children of the shadows see the light!"
                    };
                    break;
            }
        }
        //else if (dialogue.name == "Mother of Shadows Jump")
        //{
        //    switch (dialogue.interactions)
        //    {
        //        case 0: //Jump
        //            dialogue.sentences = new[]
        //            {
        //                "Watch out, little Shadow, you’ll need to jump (Spacebar or W) over this gap."
        //            };
        //            break;
        //    }
        //}
        //else if (dialogue.name == "Mother of Shadows LightDMG")
        //{
        //    switch (dialogue.interactions)
        //    {
        //        case 0: //LightDMG
        //            dialogue.sentences = new[]
        //            {
        //                "Little Shadow, you’ll need to stay away from the light.",
        //                "The light will hurt you if it sees you.",
        //                "Please be careful!"
        //            };
        //            break;
        //    }
        //}
        //else if (dialogue.name == "Mother of Shadows LightHeal")
        //{
        //    switch (dialogue.interactions)
        //    {
        //        case 0: //LightHeal
        //            dialogue.sentences = new[]
        //            {
        //                "This is a shadow light, they can heal your wounds, young Shadow."
        //            };
        //            break;
        //    }
        //}
        //else if (dialogue.name == "Mother of Shadows Dash")
        //{
        //    switch (dialogue.interactions)
        //    {
        //        case 0: //Dash
        //            dialogue.sentences = new[]
        //            {
        //                "Sweet Shadow, to overcome this obstacle, you’ll need to jump and dash (Shift) across.",
        //            };
        //break;
        //    }
        //}
        //else if (dialogue.name == "Mother of Shadows Interact")
        //{
        //    switch (dialogue.interactions)
        //    {
        //        case 0: //Interact
        //            dialogue.sentences = new[]
        //            {
        //                "Little Shadow, sometimes it is nice to interact (E) with your fellow shadows.",
        //            };
        //break;
        //    }
        //}
        #endregion

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();

    }

    public void DisplayNextSentence()
    {

        Debug.Log("Next Sentence");
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopCoroutine(TypeSentence(sentence));
        StartCoroutine(TypeSentence(sentence));
    }

    //dialogue appears letter by letter
    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            //audioSource.Play();
            dialogueText.text += letter;
            yield return null;
            //audioSource.Stop();
        }
    }

    void EndDialogue()
    {
        Debug.Log("End of Conversation");

        dialogue.interactions++;
        animator.SetBool("IsOpen", false);

        talk = false;

        SetInteractable();
    }

    void SetInteractable()
    {
        if (dialogue.interactions > 3 && dialogue.name == "Light Worshiper") //stops player from interacting with character after 3rd interaction
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
