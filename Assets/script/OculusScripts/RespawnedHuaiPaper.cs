using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnedHuaiPaper : MonoBehaviour
{
    [SerializeField] Transform respawnedSpot;                   //����ͦ���m�A�bHierarchy>ThingGroup>TableMark>RespawnedSpot
    [SerializeField] GameObject huaiPaperPrefab;                //������h�@���Prefab�Areferrence�bassets>Prefabs>HuaiPaper
   public void spawnedHauiPaper()
    {
        GameObject hauiPaper = Instantiate(huaiPaperPrefab, respawnedSpot);                //�ͦ����A���h��m��respawnedSpot
    }
}
