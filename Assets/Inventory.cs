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

    public List<ResourceInfo> myInventory;
    public int capacity = 20;    //최대 인벤 용량

    private void Start()
    {
        myInventory = new List<ResourceInfo>();
    }

    public class ResourceInfo
    {
        public Resource resource;
        public int count;

        public ResourceInfo(Resource _resource, int _count)
        {
            resource = _resource;
            count = _count;
        }

    }
}
