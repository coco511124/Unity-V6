using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogManager2_2 : MonoBehaviour
{
    public UnityEngine.UI.Text actorName;
    public UnityEngine.UI.Text messageText;
    public RectTransform backgroundBox;
    public GameObject DB, XrOrigin, map;//, endPanel;
    //public UnityEngine.UI.Text Mission1, Mission3, Mission4, Mission5;
    //public GameObject porTal;


    public AudioSource typingSound;

    Message2_2_[] currentMessages;
    Actor2_2_[] currentActors;
    int activeMessage = 0;


    //[SerializeField] private GameObject CallObjectAnimatorOrCallMethodOrCheckTag;

    public void openDialogue(Message2_2_[] messages, Actor2_2_[] actors)
    {
        Debug.Log("here");
        typingSound.Play();
        //CallObjectAnimatorOrCallMethodOrCheckTag.GetComponent<NPC_animate>().ChangeAnimate(); //呼叫指定物件改成對話中動畫的方法
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
        Message2_2_ messageToDisplay = currentMessages[activeMessage];
        messageText.text = messageToDisplay.meassage2_2;
        //Debug.Log(messageText.text);

        Actor2_2_ actorToDisplay = currentActors[messageToDisplay.actorId2_2];
        actorName.text = actorToDisplay.name2_2;
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
        //任務2完成訊息，執行在掛載在甘蔗上的PickUp腳本
        else
        {
            //CallObjectAnimatorOrCallMethodOrCheckTag.GetComponent<NPC_animate>().BackAnimate(); //呼叫指定物件改回待機動畫的方法
            //CallObjectAnimatorOrCallMethodOrCheckTag.GetComponent<RandomPathTrolling>().SetWalkTrue(); //呼叫RandomPathTrolling腳本的方法，允許NPC移動

            DB.SetActive(false);
            if (XrOrigin.tag == "TalkedToA")
            {
                map.SetActive(true);
            }
            else 
            {
                XrOrigin.tag = "TalkedToA";
            }
            
            
            //porTal.SetActive(true);

            //if (PL.tag == "Player")
            //{
            //    DB.SetActive(false);
            //    Mission1.text = "<color=green>1.前往黃色驚嘆號 ?</color>";
            //}
            
        }
    }

    public void ClickNextMessage()
    {
        NextMessage();
    }

}
