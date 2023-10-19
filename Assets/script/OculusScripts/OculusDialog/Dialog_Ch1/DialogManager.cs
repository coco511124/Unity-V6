using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogManager : MonoBehaviour
{
    public UnityEngine.UI.Text actorName;
    public UnityEngine.UI.Text messageText;
    public RectTransform backgroundBox;
    public GameObject DB, PL, endPanel;
    public UnityEngine.UI.Text Mission1, Mission3, Mission4, Mission5;
    // Mission2放在蔗糖trigger的script裡面

    
    public AudioSource typingSound;

    Message2_2[] currentMessages;
    Actor2_2[] currentActors;
    int activeMessage = 0;

    
    [SerializeField] private GameObject CallObjectAnimatorOrCallMethodOrCheckTag;
    
    
    public void openDialogue(Message2_2[] messages, Actor2_2[] actors) {
        typingSound.Play();
        CallObjectAnimatorOrCallMethodOrCheckTag.GetComponent<NPC_animate>().ChangeAnimate(); //呼叫指定物件改成對話中動畫的方法
        currentActors = actors;
        currentMessages = messages;
        activeMessage = 0;
        //Debug.Log(activeMessage);

        Debug.Log("started conversation! loaded messages: " +  messages.Length);
        displayMessage();
    }
    
    void displayMessage() {
        Debug.Log("display message");
        Message2_2 messageToDisplay = currentMessages[activeMessage];
        messageText.text = messageToDisplay.meassage;
        //Debug.Log(messageText.text);

        Actor2_2 actorToDisplay = currentActors[messageToDisplay.actorId];
        actorName.text = actorToDisplay.name;
        //Debug.Log(actorToDisplay.name);
        DB.SetActive(true);

    }

    public void NextMessage() {
        activeMessage++;
        if (activeMessage < currentMessages.Length){
            displayMessage();
            typingSound.Play();

        }
        //任務2完成訊息，執行在掛載在甘蔗上的PickUp腳本
        else {
            CallObjectAnimatorOrCallMethodOrCheckTag.GetComponent<NPC_animate>().BackAnimate(); //呼叫指定物件改回待機動畫的方法
            CallObjectAnimatorOrCallMethodOrCheckTag.GetComponent<RandomPathTrolling>().SetWalkTrue(); //呼叫RandomPathTrolling腳本的方法，允許NPC移動

            if (PL.tag == "Player")
            {
                DB.SetActive(false);
                //spawnBool = true;
                Mission1.text = "<color=green>1.認識抗荷的背景(前往黃色驚嘆號) ✓</color>";
                //Mission1.color = Color.green;
            }
            else if (PL.tag == "PlayerWithSugar")
            {
                if (CallObjectAnimatorOrCallMethodOrCheckTag.tag != "people")   //拿到蔗糖後，碰到的人如果不是荷蘭人A的話，就關閉對話框就好
                {
                    DB.SetActive(false);
                }
                else   //拿到蔗糖後，確定碰到的人是荷蘭人A的話，就關閉對話窗+改變玩家的Tag+更新任務清單
                {
                    DB.SetActive(false);
                    PL.tag = "PlayerWithNerthland_A";
                    Mission3.text = "<color=green>3.蔗糖是荷蘭人重要的經濟來源(找到荷蘭人並繳交甘蔗) ✓</color>";
                }
            }
            else if (PL.tag == "PlayerWithNerthland_A")
            {
                //跟荷蘭人A對話後，碰到的人如果不是郭懷一的話，對話完就把對話窗關閉
                if (CallObjectAnimatorOrCallMethodOrCheckTag.tag != "huai")
                {
                    DB.SetActive(false);
                    //PlayerTagDontChange = false;
                }
                else
                {
                    //碰到的人如果是郭懷一的話，對話窗關閉+改變玩家的Tag+更新任務清單+顯示出文件
                    DB.SetActive(false);
                    PL.tag = "PlayerWithGou";
                    Mission4.text = "<color=green>4.認識郭懷一擔任使節的原由、郭懷一抗荷蘭的成因(獲得文件) ✓</color>";
                    CallObjectAnimatorOrCallMethodOrCheckTag.GetComponent<HuaiGivePaper>().SetPaperActive();
                }
            }
            else if (PL.tag == "PlayerWithGou")
            {
                //跟郭懷一對話後，碰到的人如果不是荷蘭人B的話，對話完就把對話窗關閉
                if (CallObjectAnimatorOrCallMethodOrCheckTag.tag != "People_Blue")
                {
                    DB.SetActive(false);
                }
                else
                {
                    //碰到的人如果是荷蘭人B的話，對話窗關閉+更新任務清單+隔兩秒顯示出單元總結畫面
                    DB.SetActive(false);
                    Mission5.text = "<color=green>5.荷蘭如何治理與處置反抗民眾(找藍色衣服荷蘭人的對話)\r\n ✓</color>";
                    EndCanvasManager.EndCanvas();
                }
            }
        }
    }
    //void ShowEndCanvas()
    //{
    //    Vector3 forward = PL.transform.forward;
    //    forward.y = 1;
    //    Vector3 x = PL.transform.forward;
    //    x.y = 0;
    //    endPanel.transform.position = PL.transform.position + forward * 3;
    //    endPanel.transform.rotation = Quaternion.LookRotation(x,Vector3.up);
        
    //    pldata = FileHandler.ReadFromJSON<PlayerData>(filename); //讀取json的內容
    //    //pldata10 = pldata.GetRange(pldata.Count - 10, 10);
    //    Debug.Log(pldata10);
    //    if (pldata.Count >= 10)
    //    {
    //        foreach (var item in pldata.GetRange(pldata.Count - 10, 10))
    //        {
    //            logText.text += item.playerName + " " + item.playerTime + " " + item.playerActionType + "\n"; //列出log紀錄
    //        }
    //    }
    //    else
    //    {
    //        foreach (var item in pldata.GetRange(0, pldata.Count))
    //        {
    //            logText.text += item.playerName + " " + item.playerTime + " " + item.playerActionType + "\n"; //列出log紀錄
    //        }
    //    }
        
    //    Debug.Log(logText.text);

    //    endPanel.SetActive(true);
    //}

    public void ClickNextMessage(){
        NextMessage();
    }
    
}
