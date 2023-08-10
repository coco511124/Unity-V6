using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogTrigger2_3 : MonoBehaviour
{
    
    public Message2_3[] message2_3;
    public Actor2_3[] actor2_3;
    public GameObject dialogBox;

    public void StratDialog1()
    {
        //dialogBox.GetComponent<Dia>
    }
    
}
[System.Serializable]
public class Message2_3
{
    public int actorId;
    public string message;
}

[System.Serializable]
public class Actor2_3
{
    public string name;
}
