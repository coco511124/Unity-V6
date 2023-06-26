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
        //拿到蔗糖後
        if(other.gameObject.tag == "PlayerWithSugar")
        {
            Debug.Log("sugar");
            dialogueBox.SetActive(true);
            StartDialogue1();
        }
        //玩家的tag還在初始階段時
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("no sugar");
            dialogueBox.SetActive(true);
            StartDialogue2();
        }
        //跟荷蘭人A對話完後
        if (other.gameObject.tag == "PlayerWithNerthland_A" && ObjectTag.tag == "huai")
        {
            Debug.Log("跟荷蘭人A聊過了");
            dialogueBox.SetActive(true);
            StartDialogue1();
        };
        //跟郭懷一對話完後
        if (other.gameObject.tag == "PlayerWithGou") 
        {
            Debug.Log("跟郭懷一聊過了");
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