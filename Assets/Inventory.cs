using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public int capacity = 36;    //최대 인벤 용량

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        if (list_MyResource == null)
            list_MyResource = new List<Resource>();

        if (list_MyItem == null)
            list_MyItem = new List<Item>();

    }

    public void RemoveResource()
    {
        list_MyResource.Clear();
    }
    public string ReSourceKindToString(ResourceKind kind)
    {
        string kindName = "";
        switch (kind)
        {
            case ResourceKind.WOOD:
                {
                    kindName = "wood";
                }
                break;
            case ResourceKind.SAND:
                {
                    kindName = "sand";

                }
                break;
            case ResourceKind.CHICKEN:
                {
                    kindName = "chicken";
                }
                break;
            case ResourceKind.FLINT:
                {
                    kindName = "flint";
                }
                break;
            case ResourceKind.IRON:
                {
                    kindName = "iron";
                }
                break;
            case ResourceKind.GOLD:
                {
                    kindName = "gold";
                }
                break;
            case ResourceKind.DIAMOND:
                {
                    kindName = "diamond";
                }
                break;
            case ResourceKind.TREASURE:
                {
                    kindName = "treasure";

                }
                break;
            case ResourceKind.URANIUM:
                {
                    kindName = "uranium";

                }
                break;
            case ResourceKind.FISH:
                {
                    kindName = "fish";

                }
                break;
        }
        return kindName;
    }
    public void AddResourceToInventory(Resource _resource)
    {
        print("ADDResourceToInven");
        if (list_MyResource.Count + list_MyItem.Count < capacity)
        {
            Resource matchResource = list_MyResource.Find(x => x.ResourceKind == _resource.ResourceKind);
       
            if (matchResource != null)
            {
                matchResource.count += 10;
                matchResource.UpadateCount();
            }
            else
            {
                _resource.count = 1;
                GameObject go = null;
                string kindName = ReSourceKindToString(_resource.ResourceKind);
                go = GameObject.Find("Prefabs").transform.Find(kindName).gameObject;
                Resource res;
                UIManager.instance.AddItemToInventoryUI(go,out res);
                list_MyResource.Add(res);
                res.UpadateCount();
            }
        }
    }
}
