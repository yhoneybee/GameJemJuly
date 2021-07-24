using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DescriptionUI : MonoBehaviour
{

    void OnEnable()
    {
        Ray2D ray = new Ray2D(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, 10, 1 << 8);

        Item item = hit.collider.GetComponent<CombinationUI>().targetItem.GetComponent<Item>();
        if (item != null)
        {
            transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = item.KoreanName;
            transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = item.description;

            switch (item.itemType)
            {
                case Item.eItemType.EXPENDABLE:
                    {
                        transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "������ : " + item.durability;
                    }
                    break;
                case Item.eItemType.HOUSE:
                    {

                    }
                    break;
                case Item.eItemType.BOAT:
                    {

                    }
                    break;
                case Item.eItemType.WEAPON:
                    {

                    }
                    break;
            }

            string str = "<�ʿ� ���>";
            for (int i = 0; i < item.list_requiredResource.Count; i++)
            {
                str += "\n" + item.list_requiredResource[i].ResourceKind.ToString() + " : " + item.list_requiredResource[i].count;
            }
            transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = str;
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}