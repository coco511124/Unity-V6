using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogManager2_1 : MonoBehaviour
{
    public UnityEngine.UI.Text actorName;
    public UnityEngine.UI.Text messageText;
    public RectTransform backgroundBox;
    public GameObject DB;//, PL, endPanel;
    //public UnityEngine.UI.Text Mission1, Mission3, Mission4, Mission5;
    public GameObject porTal;


    public AudioSource typingSound;

    Message2_1[] currentMessages;
    Actor2_1[] currentActors;
    int activeMessage = 0;


    //[SerializeField] private GameObject CallObjectAnimatorOrCallMethodOrCheckTag;


    public void openDialogue(Message2_1[] messages, Actor2_1[] actors)
    {
        Debug.Log("here");
        typingSound.Play();
        //CallObjectAnimatorOrCallMethodOrCheckTag.GetComponent<NPC_animate>().ChangeAnimate(); //�I�s���w����令��ܤ��ʵe����k
        currentActors = actors;
        currentMessages = messages;
        activeMessage = 0;
        //Debug.Log(activeMessage);

        Debug.Log("started conversation! loaded messages: " + messages.Length);
        displayMessage();
    }

    void displayMessage()
    {
        Debug.Log("display message");
        Message2_1 messageToDisplay = currentMessages[activeMessage];
        messageText.text = messageToDisplay.meassage2_1;
        //Debug.Log(messageText.text);

        Actor2_1 actorToDisplay = currentActors[messageToDisplay.actorId2_1];
        actorName.text = actorToDisplay.name2_1;
        //Debug.Log(actorToDisplay.name);
        DB.SetActive(true);

    }

    public void NextMessage()
    {
        activeMessage++;
        if (activeMessage < currentMessages.Length)
        {
            displayMessage();
            typingSound.Play();

        }
        //����2�����T���A����b�����b�̽��W��PickUp�}��
        else
        {
            //CallObjectAnimatorOrCallMethodOrCheckTag.GetComponent<NPC_animate>().BackAnimate(); //�I�s���w�����^�ݾ��ʵe����k
            //CallObjectAnimatorOrCallMethodOrCheckTag.GetComponent<RandomPathTrolling>().SetWalkTrue(); //�I�sRandomPathTrolling�}������k�A���\NPC����

            DB.SetActive(false);
            porTal.SetActive(true);

            //if (PL.tag == "Player")
            //{
            //    DB.SetActive(false);
            //    Mission1.text = "<color=green>1.�e��������ĸ� ?</color>";
            //}
        }
    }

    public void ClickNextMessage()
    {
        NextMessage();
    }

}
