using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance = null;
    public Vector2 size;
    AGrid grid;
    Resource[,] resources;

    public Sprite sprite;

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
        CreateRandomResources(ResourceKind.WOOD);
        CreateRandomResources(ResourceKind.WOOD);
        CreateRandomResources(ResourceKind.WOOD);
        CreateRandomResources(ResourceKind.WOOD);
    }

    public IEnumerator CCreateRandomResources(ResourceKind resourceKind)
    {
        yield return new WaitForSeconds(60);
        CreateRandomResources(resourceKind);
    }
    void CreateRandomResources(ResourceKind resourceKind)
    {
        GameObject obj = new GameObject($"{resourceKind}");

        Resource resource = obj.AddComponent<Resource>();

        obj.layer = 6;

        obj.GetComponent<SpriteRenderer>().sprite = sprite;

        obj.GetComponent<BoxCollider2D>().size = Vector2.one * 1.5f;

        obj.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;

        obj.transform.localScale = Vector3.one;

        Vector2 index = new Vector2(Random.Range(0, (int)size.x), Random.Range(0, (int)size.y));
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

        obj.transform.position = new Vector3(pos.x, pos.y);

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
