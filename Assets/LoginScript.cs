using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;
using UnityEngine.UI;

public class LoginScript : MonoBehaviour
{
    
    SaveSystem saveSystem;
    SaveSystemCh2 saveSystemCh2;
    SaveSystemCh3 saveSystemCh3;
    [SerializeField] public TMP_Text text, text2;

    public string name;

    public TMP_Text welcomeText;
    
    public void Login()
    {
        name = text.text + text2.text;
        KeepData.loginName = name;

        welcomeText.text = name + "¡Aµn¤J¦¨¥\¡I";
        Debug.Log(name);

    }
}
