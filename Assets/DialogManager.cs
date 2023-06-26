using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class DialogManager : MonoBehaviour
{
    public Text actorName;
    public Text messageText;
    public RectTransform backgroundBox;
    public GameObject DB, PL;
    public Text Mission1, Mission2, Mission3, Mission4, Mission5;

    Message[] currentMessages;
    Actor[] currentActors;
    int activeMessage = 0;

    public void openDialogue(Message[] messages, Actor[] actors) {
        currentActors = actors;
        currentMessages = messages;
        activeMessage = 0;
        //Debug.Log(activeMessage);

        Debug.Log("started conversation! loaded messages: " +  messages.Length);
        displayMessage();
    }
    
    void displayMessage() {
        Debug.Log("display message");
        Message messageToDisplay = currentMessages[activeMessage];
        messageText.text = messageToDisplay.meassage;
        //Debug.Log(messageText.text);

        Actor actorToDisplay = currentActors[messageToDisplay.actorId];
        actorName.text = actorToDisplay.name;
        //Debug.Log(actorToDisplay.name);

    }

    public void NextMessage() {
        activeMessage++;
        if (activeMessage < currentMessages.Length){
            displayMessage();
        }
        else {
            if (PL.tag == "Player"){
                Destroy(DB);
                Mission1.text = "1.前往黃色驚嘆號 √";
                Mission1.color = Color.green;
            }
            else if (PL.tag == "PlayerWithSugar"){
                Destroy(DB);
                Mission3.text = "3.找到荷蘭人並繳交甘蔗 √";
                Mission3.color = Color.green;
            }
        }
    }

    public void ClickNextMessage(){
        NextMessage();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
            NextMessage();
        }
    }
}
