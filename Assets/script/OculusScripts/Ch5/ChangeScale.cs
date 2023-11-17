using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScale : MonoBehaviour
{
    private Vector3 Scale;
    [SerializeField] private Transform NeedChangeObject;

    private bool allowToBack;

    void Awake()
    {
        Scale = NeedChangeObject.localScale;
        allowToBack = false;
    }
    // Start is called before the first frame update
    //void Awake()
    //{
       
    //}

    public void ChangeObjectScale()
    {
        if (allowToBack == false)
        {
            NeedChangeObject.localScale = new Vector3(5f, 5f, 5f);
            StartCoroutine(ChangeBoolToTrue());  //�ϥΨ�{�A��2��A�����L���ܬ�true
            Debug.Log("�ܴ���n");
        }
        else
        {
            NeedChangeObject.localScale = Scale;
            StartCoroutine(ChangeBoolToFalse()); // �ϥΨ�{�A��2��A�����L���ܬ�false
            Debug.Log("�٭�j�p");
        }

    }

    IEnumerator ChangeBoolToTrue()
    {
        yield return new WaitForSeconds(2);
        allowToBack = true;
    }
    IEnumerator ChangeBoolToFalse()
    {

        yield return new WaitForSeconds(2);
        allowToBack = false;
    }

}
