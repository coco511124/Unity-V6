using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class PlaneTouchObject : MonoBehaviour
{
    public UnityEvent fallingSugarDestroy;              //�Ѧҩ�SugarTable>SugarSpawnSpot>minusAmount
    public UnityEvent fallingHuaiPaperDestroy;          //�Ѧҩ�TableMark>RespawnedHuaiPaper>spawnedHuaiPaper
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Sugar")
        {
            //other.gameObject.SetActive(false);
            Debug.Log("�I��ż��c");
            Destroy(other.gameObject, 0f);
            fallingSugarDestroy?.Invoke();            //�q��SugarSpawnSpot�}���A��Amount -1
        }
        if (other.tag == "huaiPaper")
        {
            Debug.Log("�I�쳢�h�@���F");
            Destroy(other.gameObject, 0f);
            fallingHuaiPaperDestroy?.Invoke();       //�q��RespawnedHuaiPaper�}���A�Ⳣ�h�@��󭫥�
        }
    }
}
