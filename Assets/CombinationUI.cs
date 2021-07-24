using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinationUI : MonoBehaviour
{
    public GameObject targetItem;
    public Combination combination;

    void Start()
    {

    }

    bool ButtonIsInteractable()
    {
        if(combination.CheckCombination(targetItem.name))
        {
            return true;
        }
        return false;
    }
}
