using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combination : MonoBehaviour
{
    public Dictionary<string, List<Resource>> dic_CombinationManual = new Dictionary<string, List<Resource>>();

    void OnEnable()
    {
        for (int i = 0; i < DataManager.instance.list_itemInfo.Count; i++)
        {
            dic_CombinationManual.Add(DataManager.instance.list_itemInfo[i].itemName, DataManager.instance.list_itemInfo[i].list_requiredResource);
        }
    }

    // 조합 가능한지 체크
    public bool CheckCombination(string _itemName)
    {
        foreach (var requiredResource in dic_CombinationManual[_itemName])
        {
            Resource matchResource = Inventory.instance.list_MyResource.Find(x => x.ResourceKind == requiredResource.ResourceKind);

            if (matchResource != null && matchResource.count >= requiredResource.count)
            {
                return true;
            }
        }
        return false;
    }

    public void CombineResources(string _itemName)
    {
        if (CheckCombination(_itemName))
        {
            foreach (var requiredResource in dic_CombinationManual[_itemName])
            {
                Resource matchResource = Inventory.instance.list_MyResource.Find(x => x.ResourceKind == requiredResource.ResourceKind);

                if (matchResource != null)
                {
                    matchResource.count -= requiredResource.count;

                    UIManager.instance.AddItemToInventoryUI(GameObject.Find("Prefabs").transform.Find(_itemName).gameObject);
                }
            }
        }
    }
}