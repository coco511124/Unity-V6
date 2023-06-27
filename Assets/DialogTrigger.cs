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
        //初始狀態碰到驚嘆號
        if (other.gameObject.tag == "Player" && ObjectTag.tag == "thing")
        {
            Debug.Log("碰到驚嘆號");
            dialogueBox.SetActive(true);
            StartDialogue1();
        }
        //拿到蔗糖後
        else if (other.gameObject.tag == "PlayerWithSugar"  && ObjectTag.tag == "people")
        {
            Debug.Log("拿到蔗糖碰到荷蘭人A");
            dialogueBox.SetActive(true);
            StartDialogue1();
        }
        //玩家的tag還在初始階段時
        else if (other.gameObject.tag == "Player")
        {
            Debug.Log("沒拿蔗糖碰到荷蘭人");
            dialogueBox.SetActive(true);
            StartDialogue2();
        }
        //跟荷蘭人A對話完後
        else if (other.gameObject.tag == "PlayerWithNerthland_A" && ObjectTag.tag == "huai")
        {
            Debug.Log("跟荷蘭人A聊過了");
            dialogueBox.SetActive(true);
            StartDialogue1();
        }
        //跟郭懷一對話完後
        else if (other.gameObject.tag == "PlayerWithGou" && ObjectTag.tag == "People_Blue") 
        {
            Debug.Log("跟郭懷一聊過了");
            dialogueBox.SetActive(true);
            StartDialogue1();
        }
        else if (other.gameObject.tag != "PlayerWithGou" && other.gameObject.tag != "PlayerWithNerthland_A" && other.gameObject.tag != "Player" && other.gameObject.tag != "PlayerWithSugar")
        {
            Debug.Log("不是玩家");
        }
        else
        {
            Debug.Log("情況二");
            dialogueBox.GetComponent<DialogManager>().setPlayerTagDontChangeBool();
            dialogueBox.SetActive(true);
            StartDialogue2();
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