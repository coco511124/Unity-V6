using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_animate : MonoBehaviour
{
    //�O�o���ܵ���referrence
    //[SerializeField]
    private Animator animator;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    public void ChangeAnimate()
    {
        Debug.Log("���ʵe�P");
        animator.SetInteger("stats", 1);  //���满�ܮɡA����
        //animator.Play("Take 001 0 0");   �S�������ʵe�����A�N���Ϊ��A���F
    }
    public void BackAnimate()
    {
        animator.SetInteger("stats", 0);  //���ܧ��A�ܦ^�ݾ����A
    }
}
