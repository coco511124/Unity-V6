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
        Debug.Log("�ǹL�ӤF");
        changeTagOrMissionText?.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        spawnSugarTimer += Time.deltaTime;         //�p�ɾ��C��+1
        if ( spawnSugarTimer > spawnSugarTimerMax) //��p�ɾ��W�L3��ɡA�k�s�p�ɾ�
        {
            spawnSugarTimer = 0f;

            if (queue.Count < sugarSpawnedAmountMax) //�p�G��e�̽��ƧC��W����3���ܡA�W�[�̽���
            {
                //sugarSpawnedAmount++;
                //sugarSpawned();
                queue.Enqueue(preparedObject(tableTopPoint.position));

                //changeTagOrMissionText?.Invoke();
            }
        }
    }

    GameObject Copy()    //�ͦ�����
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
    //    Debug.Log("�����̽�~");
    //}

    public void minusQueue()     //��ż��c�A�|�q��minusQueue�A��queue�֤@�Ӫ���
    {
        queue.Dequeue();
    }
}
