using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.AI;

public class BambooDialog4_5_6 : MonoBehaviour
{
    public Message2_2[] messages_1, messages_2;
    public Actor2_2[] actors;
    public GameObject dialogueBox;

    void StartDialogue1()
    {
        dialogueBox.GetComponent<BambooDialogManager4_5_6>().openDialogue(messages_1, actors);
    }

    

    void OnTriggerEnter(Collider other)
    {


        //��l���A�I����ĸ�
        if (other.gameObject.name == "XR Origin" )
        {
            Debug.Log("�I����ĸ�");
            dialogueBox.SetActive(true);
            StartDialogue1();
        }


    }
  
}

