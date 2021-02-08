using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    DialogueTrigger dialogueTrigger;

    string objectTag;

    // Start is called before the first frame update
    void Start()
    {
        objectTag = this.gameObject.tag;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //when the player has 
    void OnTriggerEnter2D(Collider2D collision)
    {
        //colliding object is player
        if (collision.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (objectTag == "NPC")
                {
                    dialogueTrigger.TriggerDialogue();
                }
                else if (objectTag == "Pushable")
                {

                }
            }
        }
    }

}
