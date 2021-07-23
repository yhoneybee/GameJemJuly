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

    //acquisition probabilityÀÇ ¾àÀÚ¸¦ »ç¿ëÇÔ È¹µæ È®·ü
    public int Ap
    {
        get
        {
            return Ap;
        }
        set
        {
            Ap = Mathf.Min(101, Mathf.Max(-1, value));
        }
    }

    public void Collection()
    {
        int rand = Random.Range(1, 101);
        print($"rand value is [{rand}]");
        if (Ap >= rand)
        {

        }
    }
}
