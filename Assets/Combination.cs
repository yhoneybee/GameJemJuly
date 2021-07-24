using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combination : MonoBehaviour
{
    public Dictionary<string, List<Resource>> dic_CombinationManual = new Dictionary<string, List<Resource>>();

    void Start()
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
            Resource matchResource = Inventory.instance.myInven.Find(x => x.ResourceKind == requiredResource.ResourceKind);

            if (matchResource == null || matchResource.count < requiredResource.count)
            {
                return false;
            }
        }
        return true;
    }

    public void CombineResources(string _itemName)
    {
        if(CheckCombination(_itemName))
        {
            //조합가능할경우 실제 조합 구현 코드
        }
    }
}