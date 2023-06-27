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
        //��l���A�I����ĸ�
        if (other.gameObject.tag == "Player" && ObjectTag.tag == "thing")
        {
            Debug.Log("�I����ĸ�");
            dialogueBox.SetActive(true);
            StartDialogue1();
        }
        //���콩�}��
        else if (other.gameObject.tag == "PlayerWithSugar"  && ObjectTag.tag == "people")
        {
            Debug.Log("���콩�}�I������HA");
            dialogueBox.SetActive(true);
            StartDialogue1();
        }
        //���a��tag�٦b��l���q��
        else if (other.gameObject.tag == "Player")
        {
            Debug.Log("�S�����}�I������H");
            dialogueBox.SetActive(true);
            StartDialogue2();
        }
        //������HA��ܧ���
        else if (other.gameObject.tag == "PlayerWithNerthland_A" && ObjectTag.tag == "huai")
        {
            Debug.Log("������HA��L�F");
            dialogueBox.SetActive(true);
            StartDialogue1();
        }
        //���h�@��ܧ���
        else if (other.gameObject.tag == "PlayerWithGou" && ObjectTag.tag == "People_Blue") 
        {
            Debug.Log("���h�@��L�F");
            dialogueBox.SetActive(true);
            StartDialogue1();
        }
        else if (other.gameObject.tag != "PlayerWithGou" && other.gameObject.tag != "PlayerWithNerthland_A" && other.gameObject.tag != "Player" && other.gameObject.tag != "PlayerWithSugar")
        {
            Debug.Log("���O���a");
        }
        else
        {
            Debug.Log("���p�G");
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