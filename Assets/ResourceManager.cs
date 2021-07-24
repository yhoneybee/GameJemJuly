using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance = null;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
    }

    IEnumerator CreateRandomResources(ResourceKind resourceKind)
    {
        yield return new WaitForSeconds(60);

    }
}
