using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum ResourceKind
{
    WOOD,
    SAND,
    FLINT,
    IRON,
    GOLD,
    DIAMOND,
    URANIUM,
    CHICKEN,
    FISH,
    TREASURE,
}

public enum CollectionSite
{
    ISLAND,
    CAVE,
    SEA,
}

/// <summary>
/// 아마 Collection함수 실행은 RayCast로 마우스 클릭 감지하여 하지 않을까
/// </summary>
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Resource : MonoBehaviour
{
    public ResourceKind ResourceKind;
    public CollectionSite CollectionSite { get; set; }

    public int count = 1;
    public string KoreanName;
    Sprite sprite;
    [HideInInspector]
    public TextMeshProUGUI tmpro;


    //acquisition probability의 약자를 사용함 획득 확률
    int _Ap;
    public int Ap
    {
        get
        {
            return _Ap;
        }
        set
        {
            _Ap = Mathf.Min(101, Mathf.Max(-1, value));
        }
    }

    public void Start()
    {
        for (int i = 0; i < DataManager.instance.list_resourceInfo.Count; i++)
        {
            Resource obj = DataManager.instance.list_resourceInfo[i];

            if (obj.ResourceKind == this.ResourceKind)
            {
                InitializeResource(obj);
            }
        }

        //tmpro = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        //tmpro.text = count.ToString();
    }

    void InitializeResource(Resource _resource)
    {
        KoreanName = _resource.KoreanName;
        count = _resource.count;
        Ap = _resource.Ap;
    }

    public bool Collection()
    {
        if (GameManager.Instance.CollectionSite != CollectionSite)
        {
            print("CollectionSite is Not Equals");
            return false;
        }

        int rand = Random.Range(0, 101);
        print($"rand value is [{rand}]");

        if (Ap > rand)
        {
            Inventory.instance.AddResourceToInventory(this);
            StartCoroutine(ResourceManager.Instance.CCreateRandomResources(ResourceKind));
            print("1분뒤 다시 생성되고 지금 obj는 ObjectPool로 돌아감");
            ObjectPool.Instance.ReleaseObj(this);
            return true;
        }

        return false;
    }
}
