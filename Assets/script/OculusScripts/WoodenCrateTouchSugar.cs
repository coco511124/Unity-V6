using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodenCrateTouchSugar : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Sugar")
        {
            other.gameObject.SetActive(false);
        }
    }
}
