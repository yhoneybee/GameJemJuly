using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance = null;

    AGrid grid;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        grid = GameObject.Find("A*Manager").GetComponent<AGrid>();
        CreateRandomResource();
    }

    public void CreateRandomResource()
    {
        GameObject temp = new GameObject("temp");
        temp.AddComponent<SpriteRenderer>();
        temp.transform.localScale = Vector3.one;
        temp.transform.position = grid.grid[0, 0].worldPos;
    }
}
