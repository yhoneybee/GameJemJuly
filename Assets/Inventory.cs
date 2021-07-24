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

    public void AddResourceToInventory(Resource _resource)
    {
        if (list_MyResource.Count + list_MyItem.Count < capacity)
        {
            Resource matchResource = list_MyResource.Find(x => x.ResourceKind == _resource.ResourceKind);

            if (matchResource != null)
            {
                matchResource.count ++;
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
                            go = transform.Find("wood").gameObject;
                        }
                        break;
                    case ResourceKind.SAND:
                        {

                        }
                        break;
                    case ResourceKind.LEAF:
                        {

                        }
                        break;
                    case ResourceKind.CHICKEN:
                        {

                        }
                        break;
                    case ResourceKind.FLINT:
                        {

                        }
                        break;
                    case ResourceKind.IRON:
                        {

                        }
                        break;
                    case ResourceKind.GOLD:
                        {

                        }
                        break;
                    case ResourceKind.DIAMOND:
                        {

                        }
                        break;
                    case ResourceKind.TREASURE:
                        {

                        }
                        break;
                    case ResourceKind.URANIUM:
                        {

                        }
                        break;
                    case ResourceKind.FISH:
                        {

                        }
                        break;
                    case ResourceKind.BOTTLE:
                        {

                        }
                        break;
                    default:
                        break;
                }
                UIManager.instance.AddItemToInventoryUI(go);
            }
        }
    }
}
