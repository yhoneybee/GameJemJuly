using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject invenUI;

    public void OpenUI(GameObject _target)
    {
        if (!_target.activeInHierarchy)
        {
            _target.SetActive(true);
        }
    }
}
