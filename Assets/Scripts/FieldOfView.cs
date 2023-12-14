using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public float radius;
    [Range(0, 360)]
    public float angle;

    public GameObject playerRef, xrOrigin, originFuf, finalFuf, taskPanel;
    public TMP_Text taskText;

    public LayerMask targetMask;
    public LayerMask obstructionMask;

    public bool canSeePlayer;

    private void Start()
    {
        //playerRef = GameObject.Find("XR Origin (XR Rig)");
        StartCoroutine(FOVRoutine());
    }

    private IEnumerator FOVRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }

    private void FieldOfViewCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask); //���L�n��]�m�@��OverlapSphere�˴��O�_������
        //             OverlapSphere�]�m�b�L�n�媺�y�ФW�B�b�|�i�H�b�s�边�]�w��50�BOverlapSphere�˴��ؼЪ�layer

        if (rangeChecks.Length != 0)  //OverlapSphere�̭����F�誺��
        {
            Transform target = rangeChecks[0].transform;  //�N�⨺�F�誺transform�ᤩ��target
            Vector3 directionToTarget = (target.position - transform.position).normalized;  //�Ntarget���y�ЩM�L�n�媺�y�Х�normalized��X�s���ƭȡA�ᤩ��directionToTarget

            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2) //�p�G�q�L�����e�y�Ш�directionToTarget���y�СA�p��angle/2�A�]�N�O73��/2
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position); //��X�L�n��M���a���Z���A�ᤩ��distanceToTarget

                //�g�u�_�l��m�]�b�L�n��y�СBdirectionToTarget�M�w�˴���V�BdistanceToTarget�M�w�˴��g�u���̤j�Z���BobstructionMask�M�w�n������layer����
                bool hit = Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask);
                if (!hit) //��L�n��S�˴��������hit = false�A�]�N�O�˴��쪱�a�F�C�]���bif�P�_���P�_�p�G!hit = !false = true���ɭԡA�N�N������U������k�F�C
                {
                    Debug.Log(hit);
                    canSeePlayer = true;
                    Debug.Log("������F�A���ȥ���!!");
                    xrOrigin.transform.position = new Vector3((float)-108.8, 0, (float)18.8);
                    taskPanel.SetActive(true);
                    this.GetComponent<NPCwalk>().enabled = false;
                    this.GetComponent<RandomAgent>().enabled = false;
                    //this.gameObject.transform.position = new Vector3(-113, 0, 185);
                    taskText.text = "���ȥ��ѡA�Э��s�����L�n��";
                }
                else
                {
                    canSeePlayer = false;
                }
            }
            else
                canSeePlayer = false;
        }
        else if (canSeePlayer)
            canSeePlayer = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Stick" || other.gameObject.name == "Stick(Clone)")
        {
            xrOrigin.transform.position = new Vector3((float)-108.8, 0, (float)18.8);
            originFuf.SetActive(false);
            finalFuf.SetActive(true);
            Debug.Log("hit");
            xrOrigin.gameObject.tag = "hit";
            taskPanel.SetActive(true);
            taskText.text = "���Ȧ��\�A�и�ֱd�w�i����";
        }
    }
    public void CloseTaskPanel()
    {
        taskPanel.SetActive(false);
    }
}
