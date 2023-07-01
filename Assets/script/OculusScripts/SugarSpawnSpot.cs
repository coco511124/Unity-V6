using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.Events;

public class SugarSpawnSpot : MonoBehaviour
{
    public static bool SugarCallChangeTagAndColor =false;


    public event EventHandler changeTag;
    public event EventHandler changeColor;
    //[SerializeField ]public static UnityEvent changeTagOrMissionText;

    [SerializeField] private Transform tableTopPoint;
    [SerializeField] private GameObject sugarPrefab;

    //[SerializeField] private GameObject Sugar;

    //private float spawnSugarTimer;
    //private float spawnSugarTimerMax = 1f;
    private int sugarSpawnedAmount;
    private int sugarSpawnedAmountMax = 3;

    //Queue<GameObject> queue;

    private void Awake()
    {
        //queue = new Queue<GameObject>();

        for ( var i =0; i < sugarSpawnedAmountMax; i++)
        {
            sugarSpawned();
        }

        //PickUp pickUp = GetComponentInChildren<PickUp>();
        //PickUp pickUp = GameObject.FindObjectOfType <PickUp>();
        //pickUp.sugarHover += PickUp_sugarHover;               //�q�\PickUp�}����Event
        sugarSpawnedAmount = 3;

    }

    public static void PickUp_sugarHover()  //�̽��Q���_�Ӫ��ɭԡA�|�q���L��
    {
        Debug.Log("�ǹL�ӤF");
        SugarCallChangeTagAndColor = true;
        //changeTagOrMissionText?.Invoke();
    }

  

    // Update is called once per frame
    void Update()
    {
        if (sugarSpawnedAmount < sugarSpawnedAmountMax) //�p�G��e�̽��ƧC��W����3���ܡA�W�[�̽���
        {
            sugarSpawnedAmount++;
            sugarSpawned();
            //queue.Enqueue(preparedObject(tableTopPoint.position));

            //changeTagOrMissionText?.Invoke();
        }
        if (SugarCallChangeTagAndColor)
        {
            changeTag?.Invoke(this, EventArgs.Empty);
            changeColor?.Invoke(this, EventArgs.Empty);
            SugarCallChangeTagAndColor = false;
        }
        //spawnSugarTimer += Time.deltaTime;         //�p�ɾ��C��+1
        //if ( spawnSugarTimer > spawnSugarTimerMax) //��p�ɾ��W�L3��ɡA�k�s�p�ɾ�
        //{
        //    spawnSugarTimer = 0f;

            
        //}
    }
    
    void sugarSpawned()
    {
        GameObject sugarPrefabTrasform = Instantiate(sugarPrefab, tableTopPoint);
        Debug.Log("�ͦ��̽�~");
    }

    public void minusAmount()     //��ż��c�A�|�q��minusAmount�A��Amount�֤@�Ӫ���
    {
        sugarSpawnedAmount = sugarSpawnedAmount - 1;
        
    }




    //������ƥΤ�k
    //GameObject Copy()    //�ͦ�����
    //{
    //    GameObject sugar = Instantiate(sugarPrefab, tableTopPoint);

    //    return sugar;
    //}


    //GameObject AvaliableObject()
    //{
    //    GameObject sugarPrefabLocal = null;
    //    sugarPrefabLocal = queue.Dequeue();
    //    //queue.Enqueue(sugarPrefabLocal);

    //    return sugarPrefabLocal;
    //}

    //GameObject preparedObject(Vector3 position)
    //{
    //    GameObject preparedSugar = AvaliableObject();
    //    preparedSugar.transform.position = position;
    //    preparedSugar.SetActive(true);
    //    return preparedSugar;
    //}
}
