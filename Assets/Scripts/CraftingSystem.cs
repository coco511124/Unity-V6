using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CraftingSystem : MonoBehaviour
{
    [SerializeField] private BoxCollider placeItemsAreaBoxCollider;
    [SerializeField] private List<CraftingRecipeSO> craftingRecipeSOList;
    [SerializeField] private Transform itemSpawnPoint;
    //[SerializeField] private Transform vfxSpawnItem;這個是特效

    private CraftingRecipeSO craftingRecipeSO;
   public void Craft()
    {
        //CraftingRecipeSO
        //itemSOHolder = _SOHolder
        //ItemSO = LessonTwoSO
        //itenSO = SOinfo;
        Debug.Log("craft");
        Collider[] colliderArray = Physics.OverlapBox(transform.position + placeItemsAreaBoxCollider.center, placeItemsAreaBoxCollider.size, placeItemsAreaBoxCollider.transform.rotation);

        List<LessonTwoSO> inputItemList = new List<LessonTwoSO>(craftingRecipeSO.inputItemSOList);
        List<GameObject> consumeItemGameObjectList = new List<GameObject>();

        foreach (Collider collider in colliderArray)
        {  
            if (collider.TryGetComponent(out _SOHolder _SOHolder))
            {
                if (inputItemList.Contains(_SOHolder.SOinfo))
                {
                    inputItemList.Remove(_SOHolder.SOinfo);
                    consumeItemGameObjectList.Add(collider.gameObject);
                }
                
            }
        }

        if (inputItemList.Count == 0)
        {
            Debug.Log("yes");
            Transform spawnedItemTransform = Instantiate(craftingRecipeSO.outputItemSO.prefab.transform, itemSpawnPoint.position, itemSpawnPoint.rotation);
            
            foreach (GameObject consumeItemGameObject in consumeItemGameObjectList)
            {
                Destroy(consumeItemGameObject);
            }
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        { 
            Craft();
        }
    }
}
