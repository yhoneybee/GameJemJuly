using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum eItemType
    {
        EXPENDABLE,
        HOUSE,
        BOAT,
    }

    public string itemName;
    public string description;
    public eItemType itemType;
    public int durability = 0;
    public int value = 0;
    public int defense = 0;
    public List<Resource> list_requiredResource;
}
