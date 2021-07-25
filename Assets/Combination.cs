using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combination : MonoBehaviour
{
    public Dictionary<string, List<Resource>> dic_CombinationManual = new Dictionary<string, List<Resource>>();

    public GameObject ship1;
    public GameObject ship2;
    public GameObject ship3;
    
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


                    Item itemToMake = Inventory.instance.list_MyItem.Find(x => x.itemName == _itemName);

                    if (itemToMake != null)
                    {
                        itemToMake.count++;
                    }
                    else
                    {
                        //Inventory.instance.list_MyItem.Add(DataManager.instance.list_itemInfo.Find(x => x.itemName == _itemName));
                        Item item;
                        UIManager.instance.AddItemToInventoryUI(GameObject.Find("Prefabs").transform.Find(_itemName).gameObject,out item);
                        if (item.itemType == Item.eItemType.BOAT)
                        {
                            print("ship!!");
                            if (item.name == "boat")
                            {
                                ship1.SetActive(true);
                            }
                            else if (item.name == "ship")
                            {
                                ship2.SetActive(true);
                            }
                            else
                            {
                                ship3.SetActive(true);
                            }
                            GameManager.Instance.boatName = item.name;
                        }
                        Inventory.instance.list_MyItem.Add(item);
                    }

                }
            }
        }
    }
}