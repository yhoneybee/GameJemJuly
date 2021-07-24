using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prefabs : MonoBehaviour
{
    static Prefabs _instance;
    public static Prefabs instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<Prefabs>();
            }
            return _instance;
        }
    }

    public Resource wood;
    public Resource sand;
    public Resource chicken;
    public Resource flint;
    public Resource iron;
    public Resource gold;
    public Resource diamond;
    public Resource treasure;
    public Resource uranium;
    public Resource fish;
    public Item fishing_rod;
    public Item wood_knife;
    public Item knife;
    public Item bonfire;
    public Item fish_dishes;
    public Item roasted_chicken;
    public Item bottle;
    public Item wood_house;
    public Item iron_house;
    public Item gold_house;
    public Item wooden_boat;
    public Item boat;
    public Item ship;
    public Item cruise;
    public Item nuclear;
    public Item ring;
    public Item chicken_dishes;
}
