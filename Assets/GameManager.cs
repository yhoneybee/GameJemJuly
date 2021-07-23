using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;
    public CollectionSite CollectionSite { get; private set; }
    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        // 플레이어가 밝고 있는 땅을 확인하여 CollectionSite를 변경함
    }
}
