using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogTrigger : MonoBehaviour
{
    public Message[] messages_1, messages_2;
    public Actor[] actors;
    public GameObject dialogueBox;
    [SerializeField] private GameObject ObjectTag;

    void StartDialogue1() {
        //FindObjectOfType<DialogManager>().openDialogue(messages, actors);
        dialogueBox.GetComponent<DialogManager>().openDialogue(messages_1, actors);
    }

    void StartDialogue2() {
        //FindObjectOfType<DialogManager>().openDialogue(messages2, actors);
        dialogueBox.GetComponent<DialogManager>().openDialogue(messages_2, actors);
    }

    void OnTriggerEnter(Collider other) {
        //���콩�}��
        if(other.gameObject.tag == "PlayerWithSugar")
        {
            Debug.Log("sugar");
            dialogueBox.SetActive(true);
            StartDialogue1();
        }
        //���a��tag�٦b��l���q��
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("no sugar");
            dialogueBox.SetActive(true);
            StartDialogue2();
        }
        //������HA��ܧ���
        if (other.gameObject.tag == "PlayerWithNerthland_A" && ObjectTag.tag == "huai")
        {
            Debug.Log("������HA��L�F");
            dialogueBox.SetActive(true);
            StartDialogue1();
        };
        //���h�@��ܧ���
        if (other.gameObject.tag == "PlayerWithGou") 
        {
            Debug.Log("���h�@��L�F");
            dialogueBox.SetActive(true);
            StartDialogue1();
        };
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