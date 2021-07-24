using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOverUI : MonoBehaviour
{
    public GameObject descriptionUI;
    public RectTransform rect;

    public void OnPointerEnter()
    {
        if (descriptionUI.activeInHierarchy == false)
        {
            descriptionUI.SetActive(true);
            RectTransformUtility.ScreenPointToLocalPointInRectangle(rect, Input.mousePosition, Camera.main, out Vector2 anchoredPos);
            descriptionUI.GetComponent<RectTransform>().anchoredPosition = anchoredPos;
        }
    }
    
    public void OnPointerExit()
    {
        if (descriptionUI.activeInHierarchy)
        {
            descriptionUI.SetActive(false);
        }
    }
}
