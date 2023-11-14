using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger_Ch3 : MonoBehaviour
{
    public MessageCh3[] messages_1, messages_2;
    public ActorCh3[] actors;
    public GameObject dialogueBox;
    public AudioSource typingSound;

    [SerializeField] private GameObject ObjectTag;



    void StartDialogue1()
    {
        dialogueBox.GetComponent<DialogManager_Ch3>().openDialogue(messages_1, actors);
    }

    void StartDialogue2()
    {
        dialogueBox.GetComponent<DialogManager_Ch3>().openDialogue(messages_2, actors);
    }

    void OnTriggerEnter(Collider other)
    {
        //��l���A�I����ĸ�
        if (other.gameObject.tag == "Player" && ObjectTag.tag == "thing")
        {
            Debug.Log("�I����ĸ�");
            dialogueBox.SetActive(true);
            StartDialogue1();
        }
        //�Ĥ@����G���\��ܪ���
        else if (other.gameObject.tag == "Player" && ObjectTag.tag == "zenhe")
        {
            Debug.Log("�Ĥ@����G���\���");
            dialogueBox.SetActive(true);
            StartDialogue1();
            //ObjectTag.GetComponent<RandomPathTrolling>().SetWalkFalse(); //�I�sRandomPathTrolling�}������k�A����NPC����
        }
        //���a��tag�٦b��l���q�ɡA�I��U�Ө����
        else if (other.gameObject.tag == "Player")
        {
            Debug.Log("�S�����}�I������H�B�άO�I����H");
            //dialogueBox.SetActive(true);
            //StartDialogue2();
            //ObjectTag.GetComponent<RandomPathTrolling>().SetWalkFalse(); //�I�sRandomPathTrolling�}������k�A����NPC����
        }
        //�Ĥ@������y��ܪ���
        else if (other.gameObject.tag == "PlayerWithZen" && ObjectTag.tag == "shougun")
        {
            Debug.Log("�Ĥ@������y���");
            dialogueBox.SetActive(true);
            StartDialogue1();
            //ObjectTag.GetComponent<RandomPathTrolling>().SetWalkFalse(); //�I�sRandomPathTrolling�}������k�A����NPC����
        }
        //�ĤG����G���\��ܪ���
        else if (other.gameObject.tag == "PlayerWithShou" && ObjectTag.tag == "zenhe")
        {
            Debug.Log("�ĤG����G���\���");
            dialogueBox.SetActive(true);
            StartDialogue2();
            //ObjectTag.GetComponent<RandomPathTrolling>().SetWalkFalse(); //�I�sRandomPathTrolling�}������k�A����NPC����
        }
        //�ĤG������y��ܪ���
        else if (other.gameObject.tag == "PlayerWithZenTwice" && ObjectTag.tag == "shougun")
        {
            Debug.Log("�ĤG������y���");
            dialogueBox.SetActive(true);
            StartDialogue2();
            //ObjectTag.GetComponent<RandomPathTrolling>().SetWalkFalse(); //�I�sRandomPathTrolling�}������k�A����NPC����
        }
        else if (other.gameObject.tag != "Player" && other.gameObject.tag != "PlayerWithZen" && other.gameObject.tag != "PlayerWithShou" && other.gameObject.tag != "PlayerWithZenTwice")
        {
            Debug.Log("���O���a�A�O�i�}��ܵ�");
        }
        else
        {
            Debug.Log("�I����H");
            //dialogueBox.SetActive(true);
            //StartDialogue2();
            //ObjectTag.GetComponent<RandomPathTrolling>().SetWalkFalse(); //�I�sRandomPathTrolling�}������k�A����NPC����
        }
    }
    private void OnTriggerExit(Collider other)
    {
        //�]�P�_����
        //�I�sNPC_animate
        //dialogueBox.SetActive(false);
        //ObjectTag.GetComponent<RandomPathTrolling>().SetWalkTrue();
        //ObjectTag.GetComponent<NPC_animate>().BackAnimate();
    }
}

[System.Serializable]
public class MessageCh3
{
    public int actorId;
    public string meassage;
}



[System.Serializable]
public class ActorCh3
{
    public string name;
}