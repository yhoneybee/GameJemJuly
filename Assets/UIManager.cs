using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    static UIManager _instance;
    public static UIManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<UIManager>();
            }
            return _instance;
        }
    }

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

    public void AddItemToInventoryUI<T>(T _gameObject)
    {
        GameObject go = _gameObject as GameObject;
        go.transform.SetParent(GameObject.Find("InventoryUI").transform.GetChild(0));
    }
}
