using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public GameObject PL, Objects;
  void OnTriggerEnter(Collider other)
  {
    if (gameObject.tag == "Hand"){
        Destroy(Objects);
        PL.tag = "PlayerWithSugar";
    }
  }
}
