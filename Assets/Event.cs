using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public int Day; //진행 날짜
    public int windchance = 33; // 배 타고 바람불 확률
    public Player player;
    private float time;
    private int PriateDay;
    private bool mainisland;
    private bool ship;
    // Start is called before the first frame update
    void Start()
    {
        PriateDay = 7 + (Random.Range(1, 6) - 3);
    }

    // Update is called once per frame
    void Update()
    {
        if (time > 600)
        {
            Day++;
            time = 0;
            if (ship)
            {
                if (Random.Range(1, 101) > windchance)
                {
                    //여기는 배 시스템이 생겨야 만들수 있을듯 합니다.
                }
            }
            if (Day >= PriateDay)
            {
                PriateEvent();
                PriateDay = (Day + 10) + (Random.Range(1, 6) - 3);
            }
        }
        if (mainisland)
            time += Time.deltaTime;
        else if (ship)
        {
            time += Time.deltaTime * 10;
        }
    }
    void PriateEvent()
    {
        if (ship)
        {
            //이 부근은 전체적인 시스템이 만들어야 패널티를 부여할듯 합니다.
        }
        else
        {
            player.Invoke("Pirate", 0);
        }
    }
}
