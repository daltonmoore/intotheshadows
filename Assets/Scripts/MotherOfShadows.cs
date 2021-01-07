using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherOfShadows : MonoBehaviour
{

    DialogueTrigger dialogueTrigger;

    //public bool triggered;

    //public GameObject shadow1;
    //public GameObject shadow2;
    //public GameObject shadow3;
    //public GameObject shadow4;
    //public GameObject shadow5;
    //public GameObject shadow6;

    void Start()
    {
        dialogueTrigger = GetComponent<DialogueTrigger>();
        //triggered = false;
    }

    void Update()
    {
        //if(triggered == true)
        //{
        //    Debug.Log("We collided");
        //    dialogueTrigger.TriggerDialogue();
        //}
    }
    void OnTriggerEnter2D(Collider2D collision)
    {

        //colliding object is player
        if (collision.tag == "Player")
        {
            //triggered = true;
            Debug.Log("We collided");
            dialogueTrigger.TriggerDialogue();
        }

    }

    void OnTriggerExit2D(Collider2D collision)
    {

        //colliding object is player
        if (collision.tag == "Player")
        {
            //triggered = false;
            Destroy(gameObject);
        }

    }

}
