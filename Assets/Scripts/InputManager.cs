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
        FishingLayer = LayerMask.NameToLayer("Fish");
        player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1)) // 마우스 클릭시
        {

            Vector3 transPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (player.CanCatchFish)
            {
                player.CatchFish();
                return;
            }
            player.SetPlayerFilp(transPos);
      

            RaycastHit2D hit = Physics2D.Raycast(transPos, transform.forward);

            player.TargetPos = new Vector3(transPos.x, transPos.y, 0);
            if (hit)
            {
                int hitLayer = hit.transform.gameObject.layer;

                if (hitLayer == RescoureLayer)
                {
                   // Debug.Log("resource click");
                    player.Collect(hit.collider);
                }
                else if (hitLayer == FishingLayer)
                {
                    Vector2 dir = new Vector2(transPos.x - transform.position.x, transPos.y - transform.position.y);
                    RaycastHit2D fishHit = Physics2D.Raycast(transform.position, dir, 1, 1 << LayerMask.NameToLayer("Fish"));
                    // Debug.Log("fish click");
                    player.Fising();
                }
                else if (hitLayer == BonfireLayer)
                {

                }

            }
          
        }

    }

}
