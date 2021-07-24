using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject invenUI;

    public void OpenCloseUI(GameObject _target)
    {
        if (!_target.activeInHierarchy)
        {
            _target.SetActive(true);
        }
        else
        {
            _target.SetActive(false);
        }
    }

    public void AddItemUI(GameObject _gameObject)
    {

    }
}
