using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BambooDialogManager4_5_6 : MonoBehaviour
{
    public UnityEngine.UI.Text actorName;
    public UnityEngine.UI.Text messageText;
    public RectTransform backgroundBox;
    public GameObject DB;
    
    // Mission2��b���}trigger��script�̭�


    public AudioSource[] typingSound_A;
    public AudioSource[] typingSound_B;
    private AudioSource[] currentSoundList;
    public bool _change_A_or_B_Sonud;   //true���ܡA����A��C���y���Ffalse���ܡA����B��C���y��


    Message2_2[] currentMessages;
    Actor2_2[] currentActors;
    int activeMessage = 0;

    private void Start()
    {
        _change_A_or_B_Sonud = true;
    }
    public void openDialogue(Message2_2[] messages, Actor2_2[] actors)
    {        
        currentActors = actors;
        currentMessages = messages;
        activeMessage = 0;                  //�C���}�@����ܡA�N�N���ʰT��"activeMessage"�]��0�A
        if (_change_A_or_B_Sonud == true)
        {
            currentSoundList = typingSound_A;           //��_change_A_or_B_Sonud��true�A��A LIST���y���ᤩ��currentSoundList�s�_��
            currentSoundList[activeMessage].Play();     //�åB��currentSoundList�����activeMessage�쪺�y���A�]�N�O��0�쪺�y���A�]��activeMessage�Q�]��0�F
        }
        else
        {
            currentSoundList = typingSound_B;           //��_change_A_or_B_Sonud��true�A��B LIST���y���ᤩ��currentSoundList�s�_��
            currentSoundList[activeMessage].Play();     //�åB��currentSoundList�����activeMessage�쪺�y���A�]�N�O��0�쪺�y���A�]��activeMessage�Q�]��0�F
        }
        //Debug.Log(activeMessage);

        Debug.Log("started conversation! loaded messages: " + messages.Length);
        displayMessage();
    }

    void displayMessage()
    {
        Debug.Log("display message");
        Message2_2 messageToDisplay = currentMessages[activeMessage];
        messageText.text = messageToDisplay.meassage;
        //Debug.Log(messageText.text);

        Actor2_2 actorToDisplay = currentActors[messageToDisplay.actorId];
        actorName.text = actorToDisplay.name;
        //Debug.Log(actorToDisplay.name);
        DB.SetActive(true);

    }

    public void NextMessage()
    {
        currentSoundList[activeMessage].Stop();     //���b�����y�y�A�]�����F�U�@�y�����s�A�ҥH���e�y�����_
        activeMessage++;                            //����activeMessage + 1�A����U�@�y�ܪ��y��
        if (activeMessage < currentMessages.Length)
        {
            displayMessage();
            currentSoundList[activeMessage].Play();

        }      
        else
        {
            DB.SetActive(false);                
        }
    }
 
    public void ClickNextMessage()
    {
        NextMessage();
    }

}
