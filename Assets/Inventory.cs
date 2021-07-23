using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Resource> myInventory;
    public int capacity = 20;    //최대 인벤 용량

    private void Start()
    {
        myInventory = new List<Resource>();
    }
}
