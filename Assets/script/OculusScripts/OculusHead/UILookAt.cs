using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILookAt : MonoBehaviour
{
    public Transform head;    
        
    private void LateUpdate()
    {
        //transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.forward, Camera.main.transform.rotation * Vector3.up);
        transform.LookAt(new Vector3(head.position.x, transform.position.y, head.position.z)); //��canvas��ɭ������Y
        transform.forward *= -1;      //�W������{���|�ܤϪ��A�ҥHforward*-1��canvas�ॿ
    }

  
}
