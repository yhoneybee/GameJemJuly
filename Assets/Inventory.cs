using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    static Inventory _instance;
    public static Inventory instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<Inventory>();
            }
            return _instance;
        }
    }

    public List<Resource> list_MyResource;
    public List<Item> list_MyItem;
    public int capacity = 20;    //최대 인벤 용량

    private void Start()
    {
        list_MyResource = new List<Resource>();
        list_MyItem = new List<Item>();
    }

    public void AddResourceToInventory(Resource _resource)
    {
        if (list_MyResource.Count + list_MyItem.Count < capacity)
        {
            foreach (var resource in list_MyResource)
            {
                if (resource.ResourceKind == _resource.ResourceKind)
                {
                    resource.count += _resource.count;
                    resource.tmpro.text = resource.count.ToString();
                }
                else
                {
                    list_MyResource.Add(_resource);
                    resource.tmpro.text = _resource.count.ToString();
                    //todo 인벤UI에 새로운 리소스 UI 추가
                }
            }
        }
    }
}
