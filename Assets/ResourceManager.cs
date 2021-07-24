using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct RECT
{
    public Vector2 LT;
    public Vector2 RB;
}

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance = null;
    public Vector2 size;
    public List<RECT> rects = new List<RECT>();
    AGrid grid;
    Resource[,] resources;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        grid = GameObject.Find("A*Manager").GetComponent<AGrid>();
        size.x = grid.gridWorldSize.x;
        size.y = grid.gridWorldSize.y;
        resources = new Resource[(int)size.x, (int)size.y];

        CreateRandomResources(ResourceKind.WOOD);
        CreateRandomResources(ResourceKind.WOOD);
        CreateRandomResources(ResourceKind.WOOD);
        CreateRandomResources(ResourceKind.WOOD);
        CreateRandomResources(ResourceKind.WOOD);
        CreateRandomResources(ResourceKind.WOOD);
        CreateRandomResources(ResourceKind.WOOD);
        CreateRandomResources(ResourceKind.WOOD);
        CreateRandomResources(ResourceKind.WOOD);
        CreateRandomResources(ResourceKind.WOOD);
    }

    public IEnumerator CCreateRandomResources(ResourceKind resourceKind)
    {
        StopCoroutine("DelayCall");
        StartCoroutine("DelayCall");
        yield return new WaitForSeconds(60);
        CreateRandomResources(resourceKind);
    }
    void CreateRandomResources(ResourceKind resourceKind)
    {
        Vector2 index = new Vector2(Random.Range(0, (int)size.x), Random.Range(0, (int)size.y));



        Resource resource = ObjectPool.Instance.GetObj(resourceKind);

        int i = 0;
        while (resources[(int)index.x, (int)index.y] != null)
        {
            ++i;
            index = new Vector2(Random.Range(0, (int)size.x), Random.Range(0, (int)size.y));
            if (i >= size.x * size.y)
            {
                print("±‰±ﬁ ≈ª√‚!");
                return;
            }
        }

        Vector2 pos = new Vector2(size.x / 2 * -1 + 0.5f, size.y / 2 * -1 + 0.5f);

        pos += index;

        print(pos);

        resource.transform.position = new Vector3(pos.x, pos.y);

        resources[(int)index.x, (int)index.y] = resource;
        print($"created index : {index}");
        StopCoroutine("DelayCall");
        StartCoroutine("DelayCall");
    }

    IEnumerator DelayCall()
    {
        yield return new WaitForSeconds(1);
        grid.CreateGrid();
    }
}
