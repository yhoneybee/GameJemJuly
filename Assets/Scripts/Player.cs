using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //이동속도
    public float _speed = 10.0f;
   
    //체력
    private int _hp = 100;
    public int Hp
    {
        get => _hp;
        set
        {
            if (value <= 0)
            {
                _hp = 0;
                Die();
            }
            else if (value > 100) _hp = 100;
            else _hp = value;
        }
    }

    //갈증
    private int _thirst = 100;

    public int Thirst
    {
        get => _thirst;
        set
        {
            if (value <= 0)
            {
                _thirst = 0;
                Die();
            }
            else if (value > 100) _thirst = 100;
            else _thirst = value;
        }
    }
    //체력, 목마름 감소주기
    private float _decreseTime = 1.0f;

    private Vector3 _targetPos;
    public Vector3 TargetPos
    {
        get => _targetPos;
        set 
        { 
            _targetPos = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _targetPos = transform.position;
        InvokeRepeating("DecreaseHpAndThirst", _decreseTime, _decreseTime);
    }

    // Update is called once per frame
    void Update()
    {
   
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 transPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            TargetPos = new Vector3(transPos.x, transPos.y, 0);
        }
        MoveToTarget();


    }

    void DecreaseHpAndThirst()
    {
        Hp--;
        Thirst--;
    }

    void Die()
    {
        
    }

<<<<<<< Updated upstream
=======

    public void Collect(Collider2D res)
    {

        if (GetComponent<CircleCollider2D>().IsTouching(res))
        {
            TargetPos = transform.position;
            StartCoroutine(CollectSomeThing(res.GetComponent<TargetResource>().targetResource.GetComponent<Resource>()));
        }
        
    }

    public void SetOffAnimation(PlayerState state)
    {
        if(state == PlayerState.MOVE)
        {
            playerAnimator.SetBool("IsWalk", false);
        }
        else if(state == PlayerState.COLLECT)
        {
            playerAnimator.SetBool("IsCollect", false);
        }
    }
    
    public void SetOnAnimation(PlayerState state)
    {
        if (state == PlayerState.MOVE)
        {
            playerAnimator.SetBool("IsWalk", true);
        }
        else if (state == PlayerState.COLLECT)
        {
            playerAnimator.SetBool("IsCollect", true);
        }

    }

    //무언가 채집할 때
    IEnumerator CollectSomeThing(Resource res)
    {
        //채집 애니메이션 재생.
        CurState = PlayerState.COLLECT;
        Debug.Log("collect something..");
        yield return new WaitForSeconds(collectDelay);
        res.Collection();
        CurState = PlayerState.IDLE;

    }

>>>>>>> Stashed changes
    void MoveToTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, TargetPos, Time.deltaTime * _speed);
    }
}
