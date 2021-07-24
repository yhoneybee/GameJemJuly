using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    Image HpGage;
    [SerializeField]
    Image ThirstGage;

    Animator playerAnimator;
    SpriteRenderer playerRenderer;

    public enum PlayerState
    {
        IDLE,
        MOVE,
        COLLECT,
        FISHING,
        FISHING_CATCH,
        DIE,
        SWIMING,
        SWIMING_CLLECT,
        SWIMING_DIE,
    }


    //이동속도
    public float _speed = 10.0f;
    [SerializeField]
    private int MaxHp = 100;
    [SerializeField]
    private int MaxThirst = 100;
    //체력
    private int _hp;

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
         
            HpGage.fillAmount = (float)(_hp) / (float)(MaxHp);
        }
    }

    //갈증
    private int _thirst;

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
            ThirstGage.fillAmount = (float)(_thirst) / (float)(MaxThirst);
        }
    }

    [SerializeField]
    //체력, 목마름 감소주기
    private float _decreseTime = 1.0f;

    [SerializeField]
    private float collectDelay = 1.0f;

    PlayerState _curState;
    public PlayerState CurState
    {
        get => _curState;
        set
        {
            if(_curState == value)
            {
                return;
            }
            else
            {
                SetOffAnimation(_curState);
                SetOnAnimation(value);
                _curState = value;
            }
        }
    }


    private Vector3 _targetPos;
    public Vector3 TargetPos
    {
        get => _targetPos;
        set 
        { 
            _targetPos = value;
        }
    }
    private bool _isCollecting = false;


    // Start is called before the first frame update
    void Start()
    {
        _targetPos = transform.position;
        Hp = MaxHp;
        Thirst = MaxThirst;
        InvokeRepeating("DecreaseHpAndThirst", _decreseTime, _decreseTime);
        playerAnimator = GetComponent<Animator>();
        playerRenderer = GetComponent<SpriteRenderer>();
    }

    private Vector3 _prePosition;
    private float _dx = 0;
    private float _dy = 0; 
    // Update is called once per frame
    void Update()
    {
        _dx = transform.position.x - _prePosition.x;
        _dy = transform.position.y - _prePosition.y;
        if(_dx != 0 || _dy != 0)
        {
            if(CurState != PlayerState.MOVE && CurState != PlayerState.IDLE) // 다른 행동중에 이동했으므로 캔슬.
            {
                StopAllCoroutines();
            }
            CurState = PlayerState.MOVE;
            
        }
        else
        {
            if(CurState == PlayerState.MOVE) CurState = PlayerState.IDLE;
        }

        _prePosition = transform.position;
        MoveToTarget();

    }
    public bool CanCatchFish { get; set; }
    public void SetPlayerFilp(Vector3 tarPos)
    {
        playerRenderer.flipX = tarPos.x > transform.position.x ? true : false;
    }

    private void DecreaseHpAndThirst()
    {
        Hp--;
        Thirst--;
    }

    void Die()
    {
        
    }

    void StopMove()
    {
        GetComponent<Unit>().StopMove();
    }


    public void Collect(Collider2D res)
    {

        if (GetComponent<CircleCollider2D>().IsTouching(res))
        {
            print("IsTouching res");
            TargetPos = transform.position;
            //StopMove();
            StartCoroutine(CollectSomeThing(res.GetComponent<Resource>()));
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
        else if (state == PlayerState.FISHING)
        {
            playerAnimator.SetBool("Fising",false);
        }
        else if (state == PlayerState.FISHING_CATCH)
        {
            playerAnimator.SetBool("CatchingFish", false);
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
        else if (state == PlayerState.FISHING)
        {
            playerAnimator.SetBool("Fising",true);
        }
        else if (state == PlayerState.FISHING_CATCH)
        {
            playerAnimator.SetBool("CatchingFish", true);
        }
        
    }

    //무언가 채집할 때
    IEnumerator CollectSomeThing(Resource res)
    {
        //채집 애니메이션 재생.
        CurState = PlayerState.COLLECT;
        Debug.Log("collect something..");
        yield return new WaitForSeconds(collectDelay);
        Debug.Log($"collect something finished : time ({collectDelay})");
        res.Collection();
        CurState = PlayerState.IDLE;

    }

    public void Fising()
    {
     
            Debug.Log("fish!");
            TargetPos = transform.position;
            //StopMove();
            CanCatchFish = false;
            CurState = PlayerState.FISHING;
        
    }

    public void SuccessSomeThing()
    {
        playerAnimator.SetBool("Success", true);
    }
    public void FailSomeThing()
    {
        playerAnimator.SetBool("Fail", true);
    }
    public void CatchFish()
    {
        CanCatchFish = false;
        CurState = PlayerState.FISHING_CATCH;
        transform.GetChild(0).GetComponent<Fishing>().Catch();
    }

    public void FishingEnd(bool success)
    {
        if (success)
        {
            SuccessSomeThing();
        }
        else FailSomeThing();

        CurState = PlayerState.IDLE;
    }

    void MoveToTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, TargetPos, Time.deltaTime * _speed);
    }


}
