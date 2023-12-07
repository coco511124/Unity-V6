using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class _PlayCanvasAudio : MonoBehaviour
{
    [SerializeField] private AudioSource[] EndSound;   //�]�m�椸�`���Ϊ��y����C
    private int SoundIndex;                            //�]�m�P�_�Ϊ�index

    private void Start()
    {
        SoundIndex = 0;                                //�@�}�lindex�]��0
    }

    public void PlaySound()                            //�QUnityevent�q�����ɭԡA����PlaySound
    {
        SoundIndex = 0;       //index���s�]�m��0
        if (EndSound != null) //�p�G��C�������F�誺��
        {
            EndSound[SoundIndex].Play();  //�N�q0�}�l����
            float _time = EndSound[SoundIndex].clip.length;  //�]�m�ϰ��ܼơA���eindex����list���y������clip�M��P�_�X�y�����סA�A��y�����׽ᤩ��_time
            StartCoroutine(AudioPlay(_time));         //�����{�A�åB��_time��@�Ѽƥ�i�h
        }
    }

    private IEnumerator AudioPlay(float time)   //��{����_time���Ѽ�
    {
        yield return new WaitForSeconds(time);   //���ݸӻy�����ɶ�����
        PlayNextSound();       //��������A����U�@�ӻy��
    }

    private void PlayNextSound()     //�Q��{�I�s��A����PlayNextSound()
    {
        SoundIndex++;         //index �[1
        if (SoundIndex < EndSound.Count())  //�p�G��e��index�٤p��y����C������
        {
            EndSound[SoundIndex].Play();   //���N����Q+1�᪺index��list�����y��
            float _time = EndSound[SoundIndex].clip.length;  //�åB���"�Q+1�᪺index��list�����y��"���y�����סA�A��ɶ����׽ᤩ��_time
            StartCoroutine(AudioPlay(_time));  //�A���s�I�s��{�A�åB��_time�A�@���Ѽƥ�i�h
        }
        else
        {
            print("���槹�Ҧ��y���F");    //�p�Gindex�w�g"����"�y����C�����סA�N�N���񧹦��Ҧ��y��
        }
    }
}
