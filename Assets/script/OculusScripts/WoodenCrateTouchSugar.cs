using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class WoodenCrateTouchSugar : MonoBehaviour
{
    public UnityEvent sugarSpawnedAmountChange;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Sugar")
        {
            //other.gameObject.SetActive(false);
            Debug.Log("�I��ż��c");
            Destroy(other.gameObject,0f);
            sugarSpawnedAmountChange?.Invoke();            //�q��SugarSpawnSpot�}���A��Amount -1
        }
    }
}
