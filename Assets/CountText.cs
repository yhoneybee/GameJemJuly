using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountText : MonoBehaviour
{
    TextMeshProUGUI tmpro;
    void Start()
    {
        tmpro = GetComponent<TextMeshProUGUI>();
    }

    public void SetCountOfItem()
    {
        if (transform.parent.GetComponent<Resource>() != null)
        {
            foreach (var item in Inventory.instance.list_MyResource)
            {
                if (transform.parent.GetComponent<Resource>().ResourceKind == item.ResourceKind)
                {
                    tmpro.text = item.count.ToString();
                }
            }
        }
        else if (transform.parent.GetComponent<Item>() != null)
        {
            foreach (var item in Inventory.instance.list_MyItem)
            {
                if (transform.parent.GetComponent<Item>().itemName == item.itemName)
                {
                    tmpro.text = item.count.ToString();
                }
            }
        }
    }
}
