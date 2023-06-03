using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogTrigger : MonoBehaviour
{
    public Message[] messages;
    public Actor[] actors;
    public GameObject dialogueBox;

    void StartDialogue() {
        FindObjectOfType<DialogManager>().openDialogue(messages, actors);
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player"){
            Debug.Log("hi");
            dialogueBox.SetActive(true);
            StartDialogue();
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