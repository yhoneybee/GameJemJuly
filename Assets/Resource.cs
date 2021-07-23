using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ResourceKind
{
    WOOD,
    SEND,
    LEAF,
    CHICKEN,
    FLINTSTONE,
    IRON,
    GOLD,
    DIAMOND,
    TREASURE_BOX,
    URANIUM,
    FISH,
}

public enum CollectionSite
{
    ISLAND,
    CAVE,
    SEA,
}

public class Resource : MonoBehaviour
{
    public ResourceKind ResourceKind { get; set; }

    public CollectionSite CollectionSite { get; set; }

    //acquisition probability의 약자를 사용함 획득 확률
    public int Ap
    {
        get
        {
            return Ap;
        }
        set
        {
            Ap = Mathf.Min(101, Mathf.Max(-1, value));
            print($"Ap of {ResourceKind} is {Ap}");
        }
    }

    public void Collection()
    {
        if (GameManager.Instance.CollectionSite != CollectionSite)
        {
            print("CollectionSite is Not Equals");
            return;
        }

        int rand = Random.Range(0, 101);
        print($"rand value is [{rand}]");

        if (Ap > rand)
        {
            // 여기서 적절한 아이템을 반환 ( 현재 아이템의 대한 정보는 ResourceKind 변수에 저장되어 있음
        }
    }
}
