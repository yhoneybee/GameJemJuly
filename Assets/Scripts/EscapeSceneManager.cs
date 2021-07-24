using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EscapeSceneManager : MonoBehaviour
{
    public Scrollbar scrollBar;
    public TMPro.TMP_Text txtDay;
    public GameObject AttackFromPirate, AttackFromWind;
    public GameObject BtnRetry;
    [HideInInspector] public int DayCount = 5;

    private float day_guage_time_discounter_sec = 0f;
    private int checkLastDay = 0;
    private bool bFinish = false;

    void Start()
    {
        Time.timeScale = 3.0f;
        AttackFromPirate.SetActive(false);
        AttackFromWind.SetActive(false);
        BtnRetry.SetActive(false);
        scrollBar.value = 0;
        day_guage_time_discounter_sec = ((float)1 / (float)DayCount) * 0.1f;
        txtDay.text = "Day 1";
    }

    public void OnEvent_Retry()
    {
        Time.timeScale = 1.0f;
        //  게임 시작 씬 로딩하기 - 지금은 그냥 리로딩 하기
        UnityEngine.SceneManagement.SceneManager.LoadScene(gameObject.scene.name);
    }

    // Update is called once per frame
    void Update()
    {
        if (bFinish == true)
            return;

        if (GameManager.Instance.isPlaying == false)
        {
            bFinish = true;
            StartCoroutine(DoGameOver());
            return;
        }
        if(scrollBar.value>= 1)
        {
            ++checkLastDay;
            bFinish = true;
            StartCoroutine(DoGameOver());
            return;
        }
        scrollBar.value += day_guage_time_discounter_sec * Time.deltaTime;
        int now = Mathf.RoundToInt(scrollBar.value / day_guage_time_discounter_sec * 0.1f);
        txtDay.text = "Day " + now.ToString();
        if(now != checkLastDay)
        {
            checkLastDay = now;
            StartCoroutine(DoEvent());
        }
    }

    IEnumerator DoGameOver()
    {
        Time.timeScale = 1.0f;
        BtnRetry.SetActive(true);
        yield return new WaitForFixedUpdate();
    }
    IEnumerator DoEvent()
    {
        yield return new WaitForFixedUpdate();
        if (checkLastDay > DayCount)
        {
            //  should be game over
            BtnRetry.SetActive(true);
        }
        else
        {
            float value = Random.Range(0.0f, 1.0f);
            if (value > 0.9f)
            {
                //  해적의 공격
                AttackFromPirate.SetActive(true);
            } else if (value < 0.1f)
            {
                //  바람이 분다.
                AttackFromWind.SetActive(true);
            }
            else
            {
                AttackFromWind.SetActive(false);
            } 
        }
    }
}
