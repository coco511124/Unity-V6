using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.Events;

public class SugarSpawnSpot : MonoBehaviour
{
    public UnityEvent changeTagOrMissionText;

    [SerializeField] private Transform tableTopPoint;
    [SerializeField] private GameObject sugarPrefab;

    //[SerializeField] private GameObject Sugar;

    private float spawnSugarTimer;
    private float spawnSugarTimerMax = 3f;
    //private int sugarSpawnedAmount;
    private int sugarSpawnedAmountMax = 3;

    Queue<GameObject> queue;

    private void Awake()
    {
        queue = new Queue<GameObject>();

        for ( var i =0; i < sugarSpawnedAmountMax; i++)
        {
            queue.Enqueue(Copy());
        }

        PickUp pickUp = GetComponentInChildren<PickUp>();
        pickUp.sugarHover += PickUp_sugarHover;
        //sugarSpawnedAmount = 3;

    }

    private void PickUp_sugarHover(object sender, EventArgs e)
    {
        Debug.Log("傳過來了");
        changeTagOrMissionText?.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        spawnSugarTimer += Time.deltaTime;         //計時器每秒+1
        if ( spawnSugarTimer > spawnSugarTimerMax) //當計時器超過3秒時，歸零計時器
        {
            spawnSugarTimer = 0f;

            if (queue.Count < sugarSpawnedAmountMax) //如果當前甘蔗數低於上限數3的話，增加甘蔗數
            {
                //sugarSpawnedAmount++;
                //sugarSpawned();
                queue.Enqueue(preparedObject(tableTopPoint.position));

                //changeTagOrMissionText?.Invoke();
            }
        }
    }

    GameObject Copy()    //生成物件
    {
        GameObject sugar = Instantiate(sugarPrefab, tableTopPoint);

        return sugar;
    }


    GameObject AvaliableObject()
    {
        GameObject sugarPrefab = null;
        queue.Enqueue(sugarPrefab);
        
        return sugarPrefab;
    }

    GameObject preparedObject(Vector3 position)
    {
        GameObject preparedSugar = AvaliableObject();
        preparedSugar.transform.position = position;
        preparedSugar.SetActive(true);
        return preparedSugar;
    }

    //void sugarSpawned()
    //{
    //    Transform sugarPrefabTrasform =  Instantiate(sugarPrefab, tableTopPoint);
    //    Debug.Log("收成甘蔗~");
    //}

    public void minusQueue()     //骯髒木箱，會通知minusQueue，讓queue少一個物件
    {
        queue.Dequeue();
    }
}
