using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;


    void update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        TriggerDialogue();
    }
    
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        //Time.timeScale=0;
    }

    
}
