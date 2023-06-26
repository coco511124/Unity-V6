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

    //[SerializeField] private float spawnDialogBoxTimer;
    //[SerializeField] private float spawnDialogBoxTimerMax = 3f;
    //[SerializeField] bool spawnBool;
    [SerializeField] bool PlayerTagDontChange ;

    public void setPlayerTagDontChangeBool()
    {
        //將布林值調為TRUE，使玩家的tag維持現狀
        PlayerTagDontChange = true;
    }

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
        DB.SetActive(true);

    }

    public void NextMessage() {
        activeMessage++;
        if (activeMessage < currentMessages.Length){
            displayMessage();
        }
        //任務2完成訊息，執行在掛載在甘蔗上的PickUp腳本
        else {
            if (PL.tag == "Player")
            {
                DB.SetActive(false);
                //spawnBool = true;
                Mission1.text = "<color=green>1.前往黃色驚嘆號 ✓</color>";
                //Mission1.color = Color.green;
            }
            else if (PL.tag == "PlayerWithSugar")
            {
                DB.SetActive(false);
                PL.tag = "PlayerWithNerthland_A";
                Mission3.text = "<color=green>3.找到荷蘭人並繳交甘蔗 ✓</color>";
                //Mission3.color = Color.green;
            }
            else if (PL.tag == "PlayerWithNerthland_A")
            {
                //沒跟郭懷一拿到文件的話(tag未改變為PlayerWithGou)，就不調整玩家的tag
                if (PlayerTagDontChange)
                {
                    DB.SetActive(false);
                    PlayerTagDontChange = false;
                }
                else
                {
                    //拿完文件對話完才能tag為PlayerWithGou
                    DB.SetActive(false);
                    PL.tag = "PlayerWithGou";
                    Mission4.text = "<color=green>4.找到郭懷一對話獲取文件 ✓</color>";
                    //quest_3.text = "<color=green>3.找到荷蘭人並繳交甘蔗 ✓</color>";
                }
            }
            else if (PL.tag == "PlayerWithGou")
            {
                DB.SetActive(false);
                Mission5.text = "<color=green>5.尋找荷蘭人繳回紙本 ✓</color>";
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
        //if (spawnBool)
        //{
        //    spawnDialogBoxTimer += Time.deltaTime;
        //    if (spawnDialogBoxTimer > spawnDialogBoxTimerMax)
        //    {
        //        DB.SetActive(true);
        //        spawnBool = false;
        //    }
        //}
    }
}
