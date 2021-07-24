using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Inventory.instance.AddResourceToInventory(Prefabs.instance.wood);
            Debug.Log("asdasdasd");
        }
    }
}
