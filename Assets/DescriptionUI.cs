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

        if (hit.collider == null) return;

        Item item = hit.collider.GetComponent<CombinationUI>().targetItem.GetComponent<Item>();

        if (item != null)
        {
            transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = item.KoreanName;
            transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = item.description;

            switch (item.itemType)
            {
                case Item.eItemType.EXPENDABLE:
                    {
                        transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "내구도 : " + item.durability;
                    }
                    break;
                case Item.eItemType.HOUSE:
                    {
                        transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "초당 HP 회복 : " + item.value + "\n" + "방어 횟수 : " + item.defense;
                    }
                    break;
                case Item.eItemType.BOAT:
                    {
                        transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "탈출 소요 일수 : " + item.value + "\n" + "방어 횟수 : " + item.defense;
                    }
                    break;
                case Item.eItemType.WEAPON:
                    {
                        transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "공격력 : " + item.value;

                    }
                    break;
            }

            string str = "<필요 재료>";
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
