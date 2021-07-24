using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance = null;
    public Vector2Int size;
    Resource[,] resources;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        resources = new Resource[size.x, size.y];
    }

    public IEnumerator CCreateRandomResources(ResourceKind resourceKind)
    {
        yield return new WaitForSeconds(60);
        CreateRandomResources(resourceKind);
    }
    void CreateRandomResources(ResourceKind resourceKind)
    {
        AGrid grid = GameObject.Find("A*Manager").GetComponent<AGrid>();

        //grid.gridWorldSize의 절반의 양의 정수와 음의 정수
        //grid.gridWorldSize의 x가 20이고 y도 20이라면, x는 -10,10 그리고 y도 -10, 10의 범위를 가진다

        Resource resource = new Resource();

        Vector2Int pos = new Vector2Int(Random.Range(0, size.x), Random.Range(0, size.y));

        //일단 이유없이 pos의 x,y를 0.5씩 더하고 뺴자 ㅋㅋ
        //그러면 -9.5 ~ 9.5까지의 범위를 가지죠

        resource.transform.position = new Vector3(pos.x, pos.y);

        resources[pos.x, pos.y] = resource;
    }
}
