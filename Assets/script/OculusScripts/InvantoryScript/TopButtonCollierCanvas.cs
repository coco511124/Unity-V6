using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopButtonCollierCanvas : MonoBehaviour
{
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
        if (other.gameObject.tag == "Sugar" || other.gameObject.tag == "huaiPaper")   //�p�G����I��collider���ܡA�N�����骺MeshRenderer����
        {
            HuaiPaperCanvas.ShowCanvas = false;
            if (other.gameObject.GetComponent<MeshRenderer>() == true)
            {
                other.gameObject.GetComponent<MeshRenderer>().enabled = false;
            }
            else
            {
                List<Transform> children = GetChildren(other.gameObject.transform, true);
                foreach (Transform child in children)
                {
                    if (child.GetComponent<MeshRenderer>() == true)
                    {
                        child.GetComponent<MeshRenderer>().enabled = false;

                        if (child.GetComponent<Canvas>() == true)
                        {
                            child.GetComponent<Canvas>().enabled = false;
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
            }

            //other.gameObject.GetComponentInChildren<MeshRenderer>().enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Sugar" || other.gameObject.tag == "huaiPaper")   //�p�G�������}collider���ܡA�N�����骺MeshRenderer�}��
        {
            HuaiPaperCanvas.ShowCanvas = true;
            if (other.gameObject.GetComponent<MeshRenderer>() == true)
            {
                other.gameObject.GetComponent<MeshRenderer>().enabled = true;
            }
            else
            {
                List<Transform> children = GetChildren(other.gameObject.transform, true);
                foreach (Transform child in children)
                {
                    if (child.GetComponent<MeshRenderer>() == true)
                    {
                        child.GetComponent<MeshRenderer>().enabled = true;

                        if (child.GetComponent<Canvas>() == true)
                        {
                            child.GetComponent<Canvas>().enabled = true;
                        }
                    }
                    else
                    {
                        continue;
                    }

                }
            }

            //other.gameObject.GetComponentInChildren<MeshRenderer>().enabled = true;
        }
    }

    List<Transform> GetChildren(Transform parent, bool recursive)
    {
        List<Transform> children = new List<Transform>();
        foreach (Transform child in parent)
        {
            children.Add(child);
            if (recursive)
            {
                children.AddRange(GetChildren(child, true));
            }
        }
        return children;
    }
}
