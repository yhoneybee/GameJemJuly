using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treasurebox_open_event : MonoBehaviour
{
    public List<GameObject> listRewards;
    // Start is called before the first frame update
    void Start()
    {
        listRewards.ForEach((ele) => ele.SetActive(false));
    }

    public void StartEvent()
    {
        StartCoroutine(OnEventStart());
    }

    IEnumerator OnEventStart()
    {
        yield return new WaitForFixedUpdate();
        float t = Time.deltaTime;
        int i = 0;
        while (true)
        {
            if (i >= listRewards.Count)
                break;
            t += Time.deltaTime;
            if (t > 1f)
            {
                listRewards[i].SetActive(true);
                t = 0;
                i++;
            }
            yield return new WaitForFixedUpdate();
        }
        yield return new WaitForSeconds(2);
        //  보상 추가 처리
        listRewards.ForEach((ele) => ele.SetActive(false));
    }
}
