using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    Player player;
    
    Vector3 target;
    public float speed = 20;
    Vector3[] path;
    int targetIndex = 0;

    public int RescoureLayer { get; private set; } // 자원
    private int FishingLayer; // 낚시 
    private int BonfireLayer; // 모닥불
    private int UILayer;

    // Start is called before the first frame update
    void Start()
    {
        RescoureLayer = LayerMask.NameToLayer("Resource");
        FishingLayer = LayerMask.NameToLayer("Fish");
        UILayer = LayerMask.NameToLayer("UI");
        player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1)) // 마우스 클릭시
        {

            Vector3 transPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            bool isNeedMove = true;
            if (player.CanCatchFish)
            {
                player.CatchFish();
                return;
            }
            player.SetPlayerFilp(transPos);
      

            RaycastHit2D hit = Physics2D.Raycast(transPos, transform.forward);
            Debug.DrawRay(transPos, Vector3.forward, Color.blue, 1);

            player.TargetPos = new Vector3(transPos.x, transPos.y, 0);
            if (hit)
            {
                int hitLayer = hit.transform.gameObject.layer;

                if (hitLayer == RescoureLayer)
                {
                    if (Vector3.Distance(hit.collider.transform.position,player.transform.position) < 2.0f)
                    {
                        player.Collect(hit.collider);
                        isNeedMove = false;
                    } 
            
                   
                }
                else if (hitLayer == FishingLayer)
                {
                    Vector2 dir = new Vector2(transPos.x - transform.position.x, transPos.y - transform.position.y);
                    RaycastHit2D fishHit = Physics2D.Raycast(transform.position, dir, 1.5f, 1 << LayerMask.NameToLayer("Fish"));
                    if (fishHit)
                    {
                        isNeedMove = false;
                        player.Fising();
                    }
                 
                }
                else if (hitLayer == BonfireLayer)
                {

                }
                else if(hitLayer == UILayer)
                {
                    isNeedMove = false;
                   // UIManager.instance.OpenCloseUI()
                }
            }
            if(isNeedMove) PathRequestManager.ReqeustPath(transform.position, transPos, OnPathFound);
        }

    }
    public void OnPathFound(Vector3[] newPath, bool pathSuccessful)
    {
        if (pathSuccessful)
        {
            path = newPath;
            StopCoroutine("FollowPath");
            StartCoroutine("FollowPath");
        }
    }

    IEnumerator FollowPath()
    {
        if (path.Length == 0) yield break;
        Vector3 currentWayPoint = path[0];

        targetIndex = 0;

        while (true)
        {
            if (transform.position == currentWayPoint)
            {
                ++targetIndex;
                if (targetIndex >= path.Length)
                    yield break;
                currentWayPoint = path[targetIndex];
            }

            transform.position = Vector3.MoveTowards(transform.position, currentWayPoint, speed * Time.deltaTime);
            yield return null;
        }
    }

}
