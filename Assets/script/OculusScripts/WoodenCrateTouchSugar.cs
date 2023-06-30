using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WoodenCrateTouchSugar : MonoBehaviour
{
    public UnityEvent queueChange;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Sugar")
        {
            other.gameObject.SetActive(false);

            queueChange?.Invoke();
        }
    }
}
