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
        if (transform.parent.GetComponent<Resource>() != null)
        {
            foreach (var item in Inventory.instance.list_MyResource)
            {
                tmpro.text = item.count.ToString();
            }
            
        }
        else if(transform.parent.GetComponent<Item>() != null)
        {
            foreach (var item in Inventory.instance.list_MyItem)
            {
                tmpro.text = item.count.ToString();
            }
        }
    }
}
