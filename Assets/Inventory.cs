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

    public List<Resource> list_MyResource = new List<Resource>();
    public List<Item> list_MyItem = new List<Item>();
    [SerializeField]
    private List<simpleItem> sItems = new List<simpleItem>();
    [SerializeField]
    private List<simpleResource> sResources = new List<simpleResource>();
    public int capacity = 36;    //최대 인벤 용량

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

/*    private void Start()
    {
        if (list_MyResource == null)
            list_MyResource = new List<Resource>();

        if (list_MyItem == null)
            list_MyItem = new List<Item>();

    }*/

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
    

    struct simpleItem
    {
        public string name;
        public int count;
    }
    struct simpleResource
    {
        public ResourceKind kind;
        public int count;
    }

    public void SaveInventory()
    {
        sItems.Clear();
        for (int i = 0; i < list_MyItem.Count; i++)
        {
            simpleItem item;
            item.name = list_MyItem[i].name;
            item.count = list_MyItem[i].count;
            sItems.Add(item);
        }
        sResources.Clear();
        for (int i = 0; i < list_MyResource.Count; i++)
        {
            simpleResource temp;
            temp.kind = list_MyResource[i].ResourceKind;
            temp.count = list_MyResource[i].count;
            sResources.Add(temp);
        }

        list_MyResource.Clear();
        list_MyItem.Clear();
        
    }
    public void ResetInventory()
    {
        list_MyItem.Clear();
        list_MyResource.Clear();
        sItems.Clear();
        sResources.Clear();
    }
    public void ReloadInvetory()
    {
        for(int i = 0; i < sItems.Count;i++)
        {
            Item temp;
            UIManager.instance.AddItemToInventoryUI(GameObject.Find("Prefabs").transform.Find(sItems[i].name).gameObject, out temp);
            list_MyItem.Add(temp);
            temp.count = sItems[i].count;
        }
        for(int i = 0; i < sResources.Count; i++)
        {
            Resource temp;
            string kindName = ReSourceKindToString(sResources[i].kind);
            GameObject go = GameObject.Find("Prefabs").transform.Find(kindName).gameObject;
            UIManager.instance.AddItemToInventoryUI(go, out temp);
            list_MyResource.Add(temp);
            temp.count = sResources[i].count;
            temp.UpadateCount();
        }
    }

    public void AddResourceToInventory(Resource _resource)
    {
        print("ADDResourceToInven");
        if (list_MyResource.Count + list_MyItem.Count < capacity)
        {
            Resource matchResource = list_MyResource.Find(x => x.ResourceKind == _resource.ResourceKind);
       
            if (matchResource != null)
            {
                matchResource.count += 100;
                matchResource.UpadateCount();
            }
            else
            {
                _resource.count = 100;
                GameObject go = null;
                string kindName = ReSourceKindToString(_resource.ResourceKind);
                go = GameObject.Find("Prefabs").transform.Find(kindName).gameObject;
                Resource res;
                UIManager.instance.AddItemToInventoryUI(go,out res);
                res.count = 100;
                list_MyResource.Add(res);
                res.UpadateCount();
            }
        }
    }
}
