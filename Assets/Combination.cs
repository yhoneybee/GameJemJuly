using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combination : MonoBehaviour
{
    Dictionary<string, List<Inventory.ResourceInfo>> dic_CombinationManual;     // 조합 관련 정보. json으로 받아옴

    // 조합 가능한지 체크
    public bool CheckCombination(string _itemName)
    {
        foreach (var requiredResoucreInfo in dic_CombinationManual[_itemName])
        {
            foreach (var resourceInfo in Inventory.instance.myInventory)
            {
                if(Inventory.instance.myInventory.Find(x => x == requiredResoucreInfo) == null ||
                    Inventory.instance.myInventory.Find(x => x == requiredResoucreInfo).count >= requiredResoucreInfo.count)
                {
                    return false;
                }
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