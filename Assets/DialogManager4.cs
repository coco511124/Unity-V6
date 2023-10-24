using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogManager4 : MonoBehaviour
{
    public UnityEngine.UI.Text actorName;
    public UnityEngine.UI.Text messageText;
    public RectTransform backgroundBox;
    public GameObject DB, XR, endPanel;
    //public UnityEngine.UI.Text Mission1,Mission2, Mission3, Mission4, Mission5;未來再處理這邊

    public GameObject portal, toLinPortal;



    public AudioSource typingSound;

    Message4[] currentMessages;
    Actor4[] currentActors;
    int activeMessage = 0;



    public void openDialogue(Message4[] messages, Actor4[] actors)
    {
        typingSound.Play();
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
        Message4 messageToDisplay = currentMessages[activeMessage];
        messageText.text = messageToDisplay.meassage;
        //Debug.Log(messageText.text);

        Actor4 actorToDisplay = currentActors[messageToDisplay.actorId];
        actorName.text = actorToDisplay.name;
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

        else
        {
            DB.SetActive(false);
            if (XR.gameObject.CompareTag("Player"))
            {
                portal.SetActive(true);
            }
            else if (XR.gameObject.CompareTag("pick")||XR.gameObject.CompareTag("gotolin"))
            {
                toLinPortal.SetActive(true);
                XR.gameObject.tag = "gotolin";
            }
            else if (XR.gameObject.CompareTag("hit"))
            {
                endPanel.SetActive(true);
                endPanel.GetComponent<EndCanvasManagerCh2>().ShowEndCanvas();
            }
        }
    }

    public void ClickNextMessage()
    {
        NextMessage();
    }

}
