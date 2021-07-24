using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    static Inventory _instance;

    public GameObject Canvas;

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

        GameObject canvas;

        if (!GameObject.Find("Canvas Inven"))
        {
            canvas = Instantiate(Canvas);
            canvas.name = "Canvas Inven";
            canvas.GetComponent<Canvas>().worldCamera = Camera.main;
            canvas.transform.GetChild(1).GetComponent<Button>().onClick.AddListener(() =>
            {
                UIManager.instance.OpenCloseUI(canvas);
            });
        }
        else
        {
            canvas = GameObject.Find("Canvas Inven");
            canvas.GetComponent<Canvas>().worldCamera = Camera.main;
            canvas.transform.GetChild(1).GetComponent<Button>().onClick.AddListener(() =>
            {
                UIManager.instance.OpenCloseUI(canvas);
            });
        }
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
                _resource.count = 1000;
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
