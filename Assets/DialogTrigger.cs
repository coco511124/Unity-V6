using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogTrigger : MonoBehaviour
{
    public Message[] messages, messages2;
    public Actor[] actors;
    public GameObject dialogueBox;

    void StartDialogue1() {
        FindObjectOfType<DialogManager>().openDialogue(messages, actors);
    }

    void StartDialogue2() {
        FindObjectOfType<DialogManager>().openDialogue(messages2, actors);
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "PlayerWithSugar"){
            Debug.Log("sugar");
            dialogueBox.SetActive(true);
            StartDialogue2();
        }
        else if (other.gameObject.tag == "Player"){
            Debug.Log("no sugar");
            dialogueBox.SetActive(true);
            StartDialogue1();
        }
    }
}

[System.Serializable]
public class Message {
    public int actorId;
    public string meassage;
}



[System.Serializable]
public class Actor {
    public string name;
}