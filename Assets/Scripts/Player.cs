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
        Hp = MaxHp;
        Thirst = MaxThirst;
        InvokeRepeating("DecreaseHpAndThirst", _decreseTime, _decreseTime);
        playerAnimator = GetComponent<Animator>();
        playerRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
        MoveToTarget();

    }

    private void DecreaseHpAndThirst()
    {
        Hp--;
        Thirst--;
    }

    void Die()
    {
        
    }

    //무언가 채집할 때
    public IEnumerator CollectSomeThing()
    {
        //채집 애니메이션 재생.

        yield return new WaitForSeconds(collectDelay);
        
    }

    void MoveToTarget()
    {
        if (transform.position == TargetPos)
        {
            playerAnimator.SetBool("IsWalk", false);
        }
        else
        {
            if (TargetPos.x > transform.position.x) playerRenderer.flipX = true;
            else playerRenderer.flipX = false;
            playerAnimator.SetBool("IsWalk", true);
            transform.position = Vector3.MoveTowards(transform.position, TargetPos, Time.deltaTime * _speed);
        }
    }
}
