using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CraftingSystem_Ch6 : MonoBehaviour
{

    [SerializeField] private BoxCollider placeItemsAreaBoxCollider;
    [SerializeField] private List<CraftingRecipeSO> craftingRecipeSOList;
    [SerializeField] private Transform itemSpawnPoint;
    //[SerializeField] private Transform vfxSpawnItem;�o�ӬO�S��

    private CraftingRecipeSO craftingRecipeSO;

    public List<string> recipeContent;
    public TMP_Text recipeContentText;

    [SerializeField] string type;
    public GameObject table, portal;
    int index;

    public UnityEngine.UI.Text Mission;
    [SerializeField] private string MissionContent;
    private int CraftCount;
    private bool First_close;
    private bool Second_close;
    [SerializeField] private bool IsIn6_3;

    private void Awake()
    {
        NextRecipe();
        CraftCount = 0;
        First_close = true;
        Second_close = true;
    }
    public void NextRecipe()
    {
        if (craftingRecipeSOList == null)
        {
            craftingRecipeSO = craftingRecipeSOList[0]; //List�q�Y�}�l
            recipeContentText.text = recipeContent[0].ToString();//�Nlist�����e�ഫ��string�A�A�Ǩ�canvas�W��recipecontentText
            Debug.Log("Restart recipe list");
        }
        else
        {
            index = craftingRecipeSOList.IndexOf(craftingRecipeSO); //���o�ثelist��index
            index = (index + 1) % craftingRecipeSOList.Count;
            craftingRecipeSO = craftingRecipeSOList[index];
            recipeContentText.text = recipeContent[index].ToString();
            Debug.Log("Next recipe");
        }
    }

    public void Craft()
    {
        //Debug.Log("craft");
        Collider[] colliderArray = Physics.OverlapBox(transform.position + placeItemsAreaBoxCollider.center, placeItemsAreaBoxCollider.size, placeItemsAreaBoxCollider.transform.rotation);

        List<ItemSO> inputItemList = new List<ItemSO>(craftingRecipeSO.inputItemSOList);
        List<GameObject> consumeItemGameObjectList = new List<GameObject>();

        foreach (Collider collider in colliderArray)
        {
            Debug.Log(collider);
            if (collider.TryGetComponent(out RecipeSOHolder recipeSOHolder))
            {
                //Debug.Log(recipeSOHolder);
                if (inputItemList.Contains(recipeSOHolder.SOinfo))
                {
                    //Debug.Log(inputItemList);
                    inputItemList.Remove(recipeSOHolder.SOinfo);
                    consumeItemGameObjectList.Add(collider.gameObject);
                }

            }
        }

        if (inputItemList.Count == 0)
        {
            type = "�X�����\";
            Debug.Log("yes");
            Transform spawnedItemTransform = Instantiate(craftingRecipeSO.outputItemSO.prefab.transform, itemSpawnPoint.position, itemSpawnPoint.rotation);

            foreach (GameObject consumeItemGameObject in consumeItemGameObjectList)
            {
                Destroy(consumeItemGameObject);
            }
            
            //���F�קK�椸5�B6�ALOG���2�椸�AXROrigin�]�ݭn��SaveSystemCh2�}������
            table.GetComponent<SaveSystemCh2>().type = "�X�����\";
            table.GetComponent<SaveSystemCh2>().Save();

            if(IsIn6_3 == false)   //�p�G�{�b���������b6-3�A�N����6-1���P�_
            {
                if (index == 0 && First_close == true)  //�{�b�p�G�O�X����P�ݪ��ܡA�NCraftCount++;
                {
                    CraftCount++;
                    First_close = false;
                }
                if (index == 1 && Second_close == true) //�{�b�p�G�O�X������ժ��P���ܡA�NCraftCount++;
                {
                    CraftCount++;
                    Second_close = false;
                }
                if (CraftCount == 2)  //��CraftCount�O2���ɭԡA�N�}�Ҷǰe���M�ܴ����ȴy�z���C��
                {
                    portal.SetActive(true);
                    Mission.text = MissionContent;
                }
            }
            else   //�p�G�{�b�������O�b6-3(�b�s�边�̭��İ_IsIn6_3�o�ӥ��L��)�A�N��������6-3���{���X�A�]��6-3�ثe�u�ݭn�X���X1�Ӫ���A�ҥH�����ܴ����ȴy�z�M�C��Y�i�C
            {
                //portal.SetActive(true);
                Mission.text = MissionContent;
            }
            
        }
        else
        {
            //table.GetComponent<SaveSystemCh2>().type = "�X������";
            //table.GetComponent<SaveSystemCh2>().Save();
        }

    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))//���ե�
        {
            Craft();
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            NextRecipe();
        }
    }
}
