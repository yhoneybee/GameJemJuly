using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    Player player;

    private int RescoureLayer; // 자원
    private int FishingLayer; // 낚시 
    private int BonfireLayer; // 모닥불

    // Start is called before the first frame update
    void Start()
    {
        RescoureLayer = LayerMask.NameToLayer("Resource");
        player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 마우스 클릭시
        {

            Vector3 transPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            RaycastHit2D hit = Physics2D.Raycast(transPos, transform.forward);
            if (hit)
            {
                int hitLayer = hit.transform.gameObject.layer;

                if (hitLayer == RescoureLayer)
                {
                    StartCoroutine(player.CollectSomeThing());
                }
                else if (hitLayer == FishingLayer)
                {

                }
                else if (hitLayer == BonfireLayer)
                {

                }

            }


            player.TargetPos = new Vector3(transPos.x, transPos.y, 0);
        }

    }
}
