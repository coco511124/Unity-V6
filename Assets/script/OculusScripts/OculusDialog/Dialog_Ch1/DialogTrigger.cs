using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.AI;

public class DialogTrigger : MonoBehaviour
{
    public Message2_2[] messages_1, messages_2;
    public Actor2_2[] actors;
    public GameObject dialogueBox;
    public AudioSource typingSound;


    
    [SerializeField] private GameObject ObjectTag;

    private void Start()
    {
        
    }

    void StartDialogue1()
    {   
        dialogueBox.GetComponent<DialogManager>().openDialogue(messages_1, actors);
    }

    void StartDialogue2() 
    {        
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
        //���콩�}��A������HA����
        else if (other.gameObject.tag == "PlayerWithSugar" && ObjectTag.tag == "people")
        {
            Debug.Log("���콩�}�I������HA");
            dialogueBox.SetActive(true);
            StartDialogue1();
            ObjectTag.GetComponent<RandomPathTrolling>().SetWalkFalse(); //�I�sRandomPathTrolling�}������k�A����NPC����
        }
        //���a��tag�٦b��l���q�ɡA�I��U�Ө����
        else if (other.gameObject.tag == "Player")
        {
            Debug.Log("�S�����}�I������H�B�άO�I����H");
            dialogueBox.SetActive(true);
            StartDialogue2();
            ObjectTag.GetComponent<RandomPathTrolling>().SetWalkFalse(); //�I�sRandomPathTrolling�}������k�A����NPC����
        }
        //������HA��ܧ���A���h�@���
        else if (other.gameObject.tag == "PlayerWithNerthland_A" && ObjectTag.tag == "huai")
        {
            Debug.Log("������HA��L�F");
            dialogueBox.SetActive(true);
            StartDialogue1();
            ObjectTag.GetComponent<RandomPathTrolling>().SetWalkFalse(); //�I�sRandomPathTrolling�}������k�A����NPC����
        }
        //���h�@��ܧ���A������HB���
        else if (other.gameObject.tag == "PlayerWithGou" && ObjectTag.tag == "People_Blue")
        {
            Debug.Log("���h�@��L�F");
            dialogueBox.SetActive(true);
            StartDialogue1();
            ObjectTag.GetComponent<RandomPathTrolling>().SetWalkFalse(); //�I�sRandomPathTrolling�}������k�A����NPC����
        }
        else if (other.gameObject.tag != "PlayerWithGou" && other.gameObject.tag != "PlayerWithNerthland_A" && other.gameObject.tag != "Player" && other.gameObject.tag != "PlayerWithSugar")
        {
            Debug.Log("���O���a�A�O�i�}��ܵ�");
        }
        else
        {
            Debug.Log("�I����H");
            dialogueBox.SetActive(true);
            StartDialogue2();
            ObjectTag.GetComponent<RandomPathTrolling>().SetWalkFalse(); //�I�sRandomPathTrolling�}������k�A����NPC����
        }
        
        
    }
    private void OnTriggerExit(Collider other)
    {
        //�]�P�_����
        //�I�sNPC_animate
        //dialogueBox.SetActive(false);
        ObjectTag.GetComponent<RandomPathTrolling>().SetWalkTrue();
        ObjectTag.GetComponent<NPC_animate>().BackAnimate();
    }
}

[System.Serializable]
public class Message2_2 {
    public int actorId;
    public string meassage;
}



[System.Serializable]
public class Actor2_2 {
    public string name;
}