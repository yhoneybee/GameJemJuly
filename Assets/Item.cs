using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Item : MonoBehaviour
{
    public enum eItemType
    {
        EXPENDABLE,
        HOUSE,
        BOAT,
        WEAPON,
    }
    [HideInInspector]
    public TextMeshProUGUI tmpro;
    public int count = 1;
    public string itemName;
    public string KoreanName;
    public string description;
    public eItemType itemType; 
    public int durability = 0;
    public int value = 0;
    public int defense = 0;
    public List<Resource> list_requiredResource;

    public void Start()
    {
        for (int i = 0; i < DataManager.instance.list_itemInfo.Count; i++)
        {
            Item obj = DataManager.instance.list_itemInfo[i];

            if (obj.itemName == this.itemName)
            {
                InitializeItem(obj);
            }
        }
        //tmpro = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        //tmpro.text = count.ToString();
    }

    void InitializeItem(Item _item)
    {
        KoreanName = _item.KoreanName;
        itemType = _item.itemType;
        description = _item.description;
        durability = _item.durability;
        value = _item.value;
        defense = _item.defense;
        list_requiredResource = _item.list_requiredResource;
    }
}
