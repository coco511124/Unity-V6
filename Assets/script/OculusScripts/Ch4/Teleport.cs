using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject player, lin;
    public float x, y, z;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (player.CompareTag("gotolin"))
        {
            
            lin.GetComponent<RandomAgent>().enabled = true;
            lin.GetComponent<NPCwalk>().enabled = true;
            lin.GetComponent<FieldOfView>().enabled = true;
            Debug.Log("�Ұ�");
        }
        player.transform.position = new Vector3(x, y, z);
        this.gameObject.SetActive(false);
        
    }
}
