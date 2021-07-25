using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDON : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
