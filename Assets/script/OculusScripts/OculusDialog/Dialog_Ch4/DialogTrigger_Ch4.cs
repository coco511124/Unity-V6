using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.AI;

public class DialogTrigger_Ch4 : MonoBehaviour
{
    public Message4[] messages_1, messages_2;
    public Actor4[] actors;
    public GameObject dialogueBox, dialogCanvas;
    public AudioSource typingSound;



    //[SerializeField] private GameObject ObjectTag;

    private void Start()
    {

    }

    void StartDialogue1()
    {
        dialogCanvas.GetComponent<DialogManager4>().openDialogue(messages_1, actors);
    }

    void StartDialogue2()
    {
        dialogCanvas.GetComponent<DialogManager4>().openDialogue(messages_2, actors);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartDialogue1();
        }
        else
        {
            StartDialogue2();
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        //³]§PÂ_±ø¥ó
        //©I¥sNPC_animate
        dialogueBox.SetActive(false);
        //ObjectTag.GetComponent<RandomPathTrolling>().SetWalkTrue();
        //ObjectTag.GetComponent<NPC_animate>().BackAnimate();
    }
}

[System.Serializable]
public class Message4
{
    public int actorId;
    public string meassage;
}



[System.Serializable]
public class Actor4
{
    public string name;
}
   