using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum eItemType
    {
        EXPENDABLE,
        HOUSE,
    }

    public string itemName;
    public string description;
    public eItemType itemType;
    public int durability;
    public List<Resource> list_requiredResource;
}
