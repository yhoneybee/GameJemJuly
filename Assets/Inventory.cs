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
    public int capacity = 36;    //최대 인벤 용량

    private void Start()
    {
        list_MyResource = new List<Resource>();

        list_MyItem = new List<Item>();
    }

    public void RemoveResource()
    {
        list_MyResource.Clear();
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
                //resource.tmpro.text = resource.count.ToString();
            }
            else
            {
                list_MyResource.Add(_resource);
                //resource.tmpro.text = _resource.count.ToString();
                GameObject go = null;

                switch (_resource.ResourceKind)
                {
                    case ResourceKind.WOOD:
                        {
                            //go = transform.Find("wood").gameObject;
                            go = GameObject.Find("Prefabs").transform.Find("wood").gameObject;
                        }
                        break;
                    case ResourceKind.SAND:
                        {
                            go = GameObject.Find("Prefabs").transform.Find("sand").gameObject;

                        }
                        break;
                    case ResourceKind.CHICKEN:
                        {
                            go = GameObject.Find("Prefabs").transform.Find("chicken").gameObject;

                        }
                        break;
                    case ResourceKind.FLINT:
                        {
                            go = GameObject.Find("Prefabs").transform.Find("flint").gameObject;

                        }
                        break;
                    case ResourceKind.IRON:
                        {
                            go = GameObject.Find("Prefabs").transform.Find("iron").gameObject;

                        }
                        break;
                    case ResourceKind.GOLD:
                        {
                            go = GameObject.Find("Prefabs").transform.Find("gold").gameObject;

                        }
                        break;
                    case ResourceKind.DIAMOND:
                        {
                            go = GameObject.Find("Prefabs").transform.Find("diamond").gameObject;

                        }
                        break;
                    case ResourceKind.TREASURE:
                        {
                            go = GameObject.Find("Prefabs").transform.Find("treasure").gameObject;

                        }
                        break;
                    case ResourceKind.URANIUM:
                        {
                            go = GameObject.Find("Prefabs").transform.Find("uranium").gameObject;

                        }
                        break;
                    case ResourceKind.FISH:
                        {
                            go = GameObject.Find("Prefabs").transform.Find("fish").gameObject;

                        }
                        break;
                }
                UIManager.instance.AddItemToInventoryUI(go);
            }
        }
    }
}
