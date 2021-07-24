using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shark : MonoBehaviour
{
    public List<GameObject> positionList;

    private float ai_update_time;
    private Vector3 nextPos;

    // Update is called once per frame
    void Update()
    {
        ai_update_time -= Time.deltaTime;
        transform.position -= new Vector3(
            (transform.position.x -nextPos.x)*Time.deltaTime,
            (transform.position.y - nextPos.y) * Time.deltaTime,
            0);
        if (ai_update_time > 0)
            return;

        ai_update_time = Random.Range(2,5);
        int nextTarget = Random.Range(0, positionList.Count);
        nextPos = positionList[nextTarget].transform.position;
    }
}
